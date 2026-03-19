using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace USBtoCAN_GUI_V2
{
    public partial class Blacklist : Form
    {
        public SerialPort serialPort1;

        public Blacklist(SerialPort serialPort1)
        {
            InitializeComponent();
            this.serialPort1 = serialPort1;
        }

        private void blacklistAdd_Click(object sender, EventArgs e)
        {
            // add entry to blacklist
            string textboxText = blacklistTextbox.Text;
            if (blacklistEntries.Items.Count < 5 && textboxText.Length == 3)
            {
                blacklistEntries.Items.Add(textboxText);
                blacklistEntries.Items[0].Selected = true;
            }
        }

        private void blacklistDelete_Click(object sender, EventArgs e)
        {
            // delete entry from blacklist
            if (blacklistEntries.SelectedIndices.Count > 0) // Check if an item is actually selected
            {
                blacklistEntries.Items.RemoveAt(blacklistEntries.SelectedIndices[0]);
            }
            if (blacklistEntries.Items.Count != 0)
            {
                blacklistEntries.Items[0].Selected = true;
            }
        }

        private async void blackWriteButton_Click(object sender, EventArgs e)
        {
            // write blacklist to arduino
            await serialPort1.BaseStream.WriteAsync(Encoding.ASCII.GetBytes("x<"));
            for (int i = 0; i < blacklistEntries.Items.Count; i++)
            {
                string item = blacklistEntries.Items[i].Text;
                await serialPort1.BaseStream.WriteAsync(Encoding.ASCII.GetBytes(item));
            }
            await serialPort1.BaseStream.WriteAsync(Encoding.ASCII.GetBytes(">"));
        }

        private async void blackReadButton_Click(object sender, EventArgs e)
        {
            // read blacklist from arduino
            await serialPort1.BaseStream.WriteAsync(Encoding.ASCII.GetBytes("y"));

            serialPort1.DtrEnable = true;
            blacklistEntries.Items.Clear();

            string? receivedData = await ReadToAsync(serialPort1, ">", 2000);
            serialPort1.DtrEnable = false;

            if (receivedData == null)
            {
                MessageBox.Show("Timeout: No response from device.", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // split receivedData by '*' chars
            char separator = '*';
            string[] words = receivedData.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                blacklistEntries.Items.Add(word);
            }
            if (blacklistEntries.Items.Count != 0)
            {
                blacklistEntries.Items[0].Selected = true;
            }
        }

        private async void blackBurnButton_Click(object sender, EventArgs e)
        {
            // burn blacklist to arduino
            await serialPort1.BaseStream.WriteAsync(Encoding.ASCII.GetBytes("z\r\n"));
        }

        private async Task<string?> ReadToAsync(SerialPort port, string delimiter, int timeoutMs)
        {
            var buffer = new List<byte>();
            var stream = port.BaseStream;
            var cts = new CancellationTokenSource(timeoutMs);
            try
            {
                while (true)
                {
                    var readBuffer = new byte[1];
                    int bytesRead = await stream.ReadAsync(readBuffer, 0, 1, cts.Token);
                    if (bytesRead == 0)
                        break;
                    if (readBuffer[0] == (byte)delimiter[0])
                        break;
                    buffer.Add(readBuffer[0]);
                }
                return Encoding.ASCII.GetString(buffer.ToArray());
            }
            catch
            {
                return null;
            }
        }
    }
}
