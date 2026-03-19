#include <Adafruit_NeoPixel.h>
#include <Arduino_CAN.h>
#include <EEPROM.h>
#include <RTC.h>
#include <SD.h>

// Neopixel variables
#define PIN 3
#define NUMPIXELS 5
Adafruit_NeoPixel pixels(NUMPIXELS, PIN, NEO_GRB + NEO_KHZ800);

// Serial input variables
boolean newData = false;
const byte numChars = 32;
char receivedChars[numChars];

// White/blacklist variables
boolean filter = 0;
boolean whitelistOn = 0;
const int numRows = 5;
const int numCols = 3;
char whitelist[numRows][numCols] = {};
char blacklist[numRows][numCols] = {};

// Timer variables
RTCTime currentTime;
unsigned long millisTime;
unsigned long delayTime = 0;

// SD card variables
int fileCount;
int fileNum = 0;
const int chipSelect = 10;

// EEPROM variables
int fileNumIndex = 0;
int CANSpeedIndex = 1;
int filterIndex = 2;
int whitelistOnIndex = 3;
int whitelistIndex = 4;
int blacklistIndex = whitelistIndex + numRows*numCols - 1;

// CANSpeed variables
int CANSpeed;
int CANSpeedArray[4] = {125000, 250000, 500000, 1000000};

void setup() {
  // Start serial, SD, and CAN communication
  Serial.begin(115200);
  SD.begin(chipSelect);
  CAN.begin(1000000);

  // Read and update EEPROM
  fileCount = EEPROM.read(fileNumIndex) + 1;
  EEPROM.update(filterIndex, fileCount);
  CANSpeed = EEPROM.read(CANSpeedIndex);
  filter = EEPROM.read(filterIndex);
  whitelistOn = EEPROM.read(whitelistOnIndex);

  updateList(whitelist, whitelistIndex);
  updateList(blacklist, blacklistIndex);

  // Start the 'real time' clock
  RTC.begin();
  RTCTime startTime(01, Month::JANUARY, 2026, 10, 15, 00, DayOfWeek::THURSDAY, SaveLight::SAVING_TIME_ACTIVE);
  RTC.setTime(startTime);

  // Turn the NeoPixels on
  pixels.begin();
  pixels.setBrightness(25);
}

void loop() {
  //logCAN();
  if(Serial.available()){
    char input = Serial.read();
    switch(input){
      case 'm':
        Serial.print(EEPROM.read(CANSpeedIndex));
        Serial.print(EEPROM.read(filterIndex));
        Serial.print(EEPROM.read(whitelistOnIndex));
        Serial.print(">");
        break;
      case 'n':
        CANSpeed = 0;
        updateCANSpeed();
        break;
      case 'o':
        CANSpeed = 1;
        updateCANSpeed();
        break;
      case 'p':
        CANSpeed = 2;
        updateCANSpeed();
        break;
      case 'q':
        CANSpeed = 3;
        updateCANSpeed();
        break;
      case 'r':
        filter = true;
        break;
      case 's':
        whitelistOn = false;
        break;
      case 't':
        whitelistOn = true;
        break;
      case 'u':
        readList(whitelist);
        break;
      case 'v':
        writeList(whitelist);
        break;
      case 'w':
        burnList(whitelist, whitelistIndex);
        break;
      case 'x':
        readList(blacklist);
        break;
      case 'y':
        writeList(blacklist);
        break;
      case 'z':
        burnList(blacklist, blacklistIndex);
        break;
      case '1':
        updateList(whitelist, whitelistIndex);
        break;
      case '2':
        updateList(blacklist, blacklistIndex);
        break;
      default:
        break;
    }
  }

  // Get the current time
  RTC.getTime(currentTime);
  millisTime = millis();
  
  // Update the Neopixels
  if(millisTime - delayTime > 1000){
    pixels.show();
    delayTime = millis();
  }
}

// Update the CANBus speed
void updateCANSpeed(){
  CAN.begin(CANSpeedArray[int(CANSpeed)]);
  EEPROM.update(CANSpeedIndex, byte(CANSpeed));
}

// Log CAN message to datalogger
void logCAN() {
  // Creates/updates the current file
  String tempFileName = String(fileCount) + "_" + String(fileNum) + ".txt";
  File dataFile = SD.open(tempFileName, FILE_WRITE);
  if(dataFile.size() == 0){
    dataFile.println("Time Stamp,ID,Extended,Dir,Bus,LEN,D1,D2,D3,D4,D5,D6,D7,D8");
  }

  // Adds the CAN message to the datalog
  if (CAN.available())
  {
    CanMsg const msg = CAN.read();

    // Checks whether the msg passes the filters
    bool whitelistPass = true;
    bool blacklistPass = true;

  /*
    if (filter) {
      whitelistPass = false;
      blacklistPass = true;
      char msgIdStr[numCols + 1];
      snprintf(msgIdStr, sizeof(msgIdStr), "%03X", msg.id); // Format ID as 3 hex chars

      // Check whitelist
      for (int i = 0; i < numRows; i++) {
        if (strncmp(msgIdStr, whitelist[i], numCols) == 0) {
          whitelistPass = true;
          break;
        }
      }

      // Check blacklist
      for (int i = 0; i < numRows; i++) {
        if (strncmp(msgIdStr, blacklist[i], numCols) == 0) {
          blacklistPass = false;
          break;
        }
      }

      // If whitelistOn, only allow whitelisted IDs
      if (whitelistOn) {
        blacklistPass = true;
      } else {
        whitelistPass = true;
      }
    }
  */

    whitelistPass = true;
    blacklistPass = true;

    if (dataFile && blacklistPass && whitelistPass) {
      // Print time (HH/MM/SS)
      dataFile.print(currentTime.getUnixTime());
      dataFile.print(millisTime);
      dataFile.print(",");
      // Print ID
      dataFile.print(msg.id, HEX);
      dataFile.print(",");
      // Print Extended
      dataFile.print(msg.isExtendedId());
      dataFile.print(",");
      // Print Dir
      dataFile.print("Rx");
      dataFile.print(",");
      // Print Bus
      dataFile.print("0");
      dataFile.print(",");
      // Print Length
      dataFile.print(msg.data_length, HEX);
      dataFile.print(",");
      // Print Data
      for(int i = 0; i < byte(msg.data_length); i++){
        if(byte(msg.data[i]) < 0x10){
          dataFile.print(0);
        }
        dataFile.print(msg.data[i], HEX);
        dataFile.print(",");
      }
      if(dataFile.size() > 100000000)
      {
        fileNum++;
      }
      dataFile.print("\r");
      dataFile.print("\n");
      dataFile.close();
    } else {
      if (!SD.begin(chipSelect))
      {/*
        Serial.println("SD.begin(...) failed.");
        for (;;) {}*/
      }
    }
  }
}

/*
// Set the neopixel colour
void setLEDColour(int pin, int colour){
  if(colour == red){
    pixels.setPixelColor(pin, pixels.Color(150, 0, 0));
  }
  if(colour == green){
    pixels.setPixelColor(pin, pixels.Color(0, 150, 0));
  }
}*/

// Read the white/blacklist from the serial monitor
void readList(char list[numRows][numCols]){
  int serialIndex = 0;
  recvWithStartEndMarkers();
  for(int i = 0; i < numRows; i++){
    for(int j = 0; j < numCols; j++){
      list[i][j] = receivedChars[serialIndex];
      serialIndex++;
    }
  }
}

// Write the white/blacklist to the serial monitor
void writeList(char list[numRows][numCols]){
  //Serial.print("<");
  for(int i = 0; i < numRows; i++){
    for(int j = 0; j < numCols; j++){
      Serial.print(list[i][j]);
    }
    Serial.print("*");
  }
  Serial.print(">");
}

// Burn the white/blacklist to the EEPROM
void burnList(char list[numRows][numCols], int index){
  for(int i = 0; i < numRows; i++){
    for(int j = 0; j < numCols; j++){
      //EEPROM.update(index, list[i][j]);
      index++;
    }
    index = index + numCols;
  } 
  //updateList(list, index);
}

// Update the white/blacklist from the EEPROM
void updateList(char list[numRows][numCols], int index){
  for(int i = 0; i < numRows; i++){
    for(int j = 0; j < numCols; j++){
      list[i][j] = EEPROM.read(index);
      index++;
    }
    index = index + numCols;
  }
}

// Receive data from the serial monitor bracketed by '<>'
// Credit: https://forum.arduino.cc/t/serial-input-basics-updated/382007
void recvWithStartEndMarkers() {
  static boolean recvInProgress = false;
  static byte ndx = 0;
  char startMarker = '<';
  char endMarker = '>';
  char rc;
 
  while (Serial.available() > 0 && newData == false) {
    rc = Serial.read();
    if (recvInProgress == true) {
      if (rc != endMarker) {
        receivedChars[ndx] = rc;
        ndx++;
        if (ndx >= numChars) {
          ndx = numChars - 1;
        }
      }
      else {
        receivedChars[ndx] = '\0'; // terminate the string
        recvInProgress = false;
        ndx = 0;
        newData = true;
      }
    }
    else if (rc == startMarker) {
      recvInProgress = true;
    }
  }
  newData = false;
}