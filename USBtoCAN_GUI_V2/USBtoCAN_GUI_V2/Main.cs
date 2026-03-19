using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace USBtoCAN_GUI_V2
{
    public partial class Main : Form
    {
        public SerialPort serialPort1 = new SerialPort("COM4", 115200);
        public Main()
        {
            InitializeComponent();

            CANSpeed.Enabled = false;
            filterSettings.Enabled = false;
            COMPortDropdown.Items.Clear();

            string[] ports = SerialPort.GetPortNames();
            COMPortDropdown.Items.AddRange(ports);
        }

        private async void speed125_CheckedChanged(object sender, EventArgs e)
        {
            await serialPort1.BaseStream.WriteAsync(Encoding.ASCII.GetBytes("n"));
        }

        private async void speed250_CheckedChanged(object sender, EventArgs e)
        {
            await serialPort1.BaseStream.WriteAsync(Encoding.ASCII.GetBytes("o"));
        }

        private async void speed500_CheckedChanged(object sender, EventArgs e)
        {
            await serialPort1.BaseStream.WriteAsync(Encoding.ASCII.GetBytes("p"));
        }

        private async void speed1000_CheckedChanged(object sender, EventArgs e)
        {
            await serialPort1.BaseStream.WriteAsync(Encoding.ASCII.GetBytes("q"));
        }

        private async void FilterCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            await serialPort1.BaseStream.WriteAsync(Encoding.ASCII.GetBytes("r"));
            if (FilterCheckbox.Checked)
            {
                blacklistOn.Enabled = true;
                whitelistOn.Enabled = true;
            }
            else
            {
                blacklistOn.Enabled = false;
                whitelistOn.Enabled = false;
                blacklistOn.Checked = false;
                whitelistOn.Checked = false;
            }
        }

        private async void blacklistOn_CheckedChanged(object sender, EventArgs e)
        {
            await serialPort1.BaseStream.WriteAsync(Encoding.ASCII.GetBytes("s"));
        }

        private async void whitelistOn_CheckedChanged(object sender, EventArgs e)
        {
            await serialPort1.BaseStream.WriteAsync(Encoding.ASCII.GetBytes("t"));
        }

        private void blacklistEntries_Click(object sender, EventArgs e)
        {
            var secondForm = new Blacklist(serialPort1);
            secondForm.Show();
        }

        private void whitelistEntries_Click(object sender, EventArgs e)
        {
            var thirdForm = new Whitelist(serialPort1);
            thirdForm.Show();
        }

        private async void connectButton_Click(object sender, EventArgs e)
        {
            if (COMPortDropdown.Items.Count > 0)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                serialPort1 = new SerialPort(COMPortDropdown.Text, 115200);
                serialPort1.Open();

                CANSpeed.Enabled = true;
                filterSettings.Enabled = true;
                blacklistOn.Enabled = false;
                whitelistOn.Enabled = false;

                await serialPort1.BaseStream.WriteAsync(Encoding.ASCII.GetBytes("m"));

                serialPort1.DtrEnable = true;
                string? receivedData = await ReadToAsync(serialPort1, ">", 2000);
                serialPort1.DtrEnable = false;

                if (receivedData == null)
                {
                    MessageBox.Show("Timeout or error reading from device.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int speed = receivedData[0];
                int filter = receivedData[1];
                int listType = receivedData[2];

                switch (speed)
                {
                    case 0:
                        speed125.Checked = true;
                        break;
                    case 1:
                        speed250.Checked = true;
                        break;
                    case 2:
                        speed500.Checked = true;
                        break;
                    case 3:
                        speed1000.Checked = true;
                        break;
                    default:
                        speed1000.Checked = true;
                        break;
                }

                FilterCheckbox.Checked = filter != 0;
                if (listType == 0)
                {
                    blacklistOn.Checked = true;
                }
                else
                {
                    whitelistOn.Checked = true;
                }
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            COMPortDropdown.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            COMPortDropdown.Items.AddRange(ports);
            if (COMPortDropdown.Items.Count > 0)
            {
                COMPortDropdown.SelectedIndex = 0;
            }
        }

        // Helper for async read to delimiter
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

        private async void testButton_Click(object sender, EventArgs e)
        {
            await serialPort1.BaseStream.WriteAsync(Encoding.ASCII.GetBytes("l"));
        }
    }
}
