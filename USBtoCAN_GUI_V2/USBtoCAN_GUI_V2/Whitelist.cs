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
    public partial class Whitelist : Form
    {
        public SerialPort serialPort1;

        public Whitelist(SerialPort serialPort1)
        {
            InitializeComponent();
            this.serialPort1 = serialPort1;
        }

        private void whitelistAdd_Click(object sender, EventArgs e)
        {
            string textboxText = whitelistTextbox.Text;
            if (whitelistEntries.Items.Count < 5 && textboxText.Length == 3)
            {
                whitelistEntries.Items.Add(textboxText);
                whitelistEntries.Items[0].Selected = true;
            }
        }

        private void whitelistDelete_Click(object sender, EventArgs e)
        {
            if (whitelistEntries.SelectedIndices.Count > 0)
            {
                whitelistEntries.Items.RemoveAt(whitelistEntries.SelectedIndices[0]);
            }
            if (whitelistEntries.Items.Count != 0)
            {
                whitelistEntries.Items[0].Selected = true;
            }
        }

        private async void whiteWriteButton_Click(object sender, EventArgs e)
        {
            await serialPort1.BaseStream.WriteAsync(Encoding.ASCII.GetBytes("u<"));
            for (int i = 0; i < whitelistEntries.Items.Count; i++)
            {
                string item = whitelistEntries.Items[i].Text;
                await serialPort1.BaseStream.WriteAsync(Encoding.ASCII.GetBytes(item));
            }
            await serialPort1.BaseStream.WriteAsync(Encoding.ASCII.GetBytes(">"));
        }

        private async void whiteReadButton_Click(object sender, EventArgs e)
        {
            await serialPort1.BaseStream.WriteAsync(Encoding.ASCII.GetBytes("v"));

            serialPort1.DtrEnable = true;
            whitelistEntries.Items.Clear();

            string? receivedData = await ReadToAsync(serialPort1, ">", 5000);
            serialPort1.DtrEnable = false;

            if (receivedData == null)
            {
                MessageBox.Show("Timeout: No response from device.", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            char separator = '*';
            string[] words = receivedData.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                whitelistEntries.Items.Add(word);
            }
            if (whitelistEntries.Items.Count != 0)
            {
                whitelistEntries.Items[0].Selected = true;
            }
        }

        private async void whiteBurnButton_Click(object sender, EventArgs e)
        {
            await serialPort1.BaseStream.WriteAsync(Encoding.ASCII.GetBytes("w\r\n"));
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