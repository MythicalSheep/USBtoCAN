namespace USBtoCAN_GUI_V2
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            speed125 = new RadioButton();
            CANSpeed = new GroupBox();
            speed1000 = new RadioButton();
            speed500 = new RadioButton();
            speed250 = new RadioButton();
            filterSettings = new GroupBox();
            FilterCheckbox = new CheckBox();
            whitelistOn = new RadioButton();
            whitelistEntries = new Button();
            blacklistOn = new RadioButton();
            blacklistEntries = new Button();
            connectButton = new Button();
            refreshButton = new Button();
            groupBox1 = new GroupBox();
            COMPortDropdown = new ComboBox();
            testButton = new Button();
            CANSpeed.SuspendLayout();
            filterSettings.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // speed125
            // 
            speed125.AutoSize = true;
            speed125.Location = new Point(6, 22);
            speed125.Name = "speed125";
            speed125.Size = new Size(71, 19);
            speed125.TabIndex = 0;
            speed125.TabStop = true;
            speed125.Text = "125 kbps";
            speed125.UseVisualStyleBackColor = true;
            speed125.CheckedChanged += speed125_CheckedChanged;
            // 
            // CANSpeed
            // 
            CANSpeed.Controls.Add(speed1000);
            CANSpeed.Controls.Add(speed500);
            CANSpeed.Controls.Add(speed125);
            CANSpeed.Controls.Add(speed250);
            CANSpeed.Location = new Point(12, 12);
            CANSpeed.Name = "CANSpeed";
            CANSpeed.Size = new Size(175, 124);
            CANSpeed.TabIndex = 1;
            CANSpeed.TabStop = false;
            CANSpeed.Text = "CAN Speed";
            // 
            // speed1000
            // 
            speed1000.AutoSize = true;
            speed1000.Location = new Point(6, 97);
            speed1000.Name = "speed1000";
            speed1000.Size = new Size(77, 19);
            speed1000.TabIndex = 2;
            speed1000.TabStop = true;
            speed1000.Text = "1000 kbps";
            speed1000.UseVisualStyleBackColor = true;
            speed1000.CheckedChanged += speed1000_CheckedChanged;
            // 
            // speed500
            // 
            speed500.AutoSize = true;
            speed500.Location = new Point(6, 72);
            speed500.Name = "speed500";
            speed500.Size = new Size(71, 19);
            speed500.TabIndex = 1;
            speed500.TabStop = true;
            speed500.Text = "500 kbps";
            speed500.UseVisualStyleBackColor = true;
            speed500.CheckedChanged += speed500_CheckedChanged;
            // 
            // speed250
            // 
            speed250.AutoSize = true;
            speed250.Location = new Point(6, 47);
            speed250.Name = "speed250";
            speed250.Size = new Size(71, 19);
            speed250.TabIndex = 2;
            speed250.TabStop = true;
            speed250.Text = "250 kbps";
            speed250.UseVisualStyleBackColor = true;
            speed250.CheckedChanged += speed250_CheckedChanged;
            // 
            // filterSettings
            // 
            filterSettings.Controls.Add(FilterCheckbox);
            filterSettings.Controls.Add(whitelistOn);
            filterSettings.Controls.Add(whitelistEntries);
            filterSettings.Controls.Add(blacklistOn);
            filterSettings.Controls.Add(blacklistEntries);
            filterSettings.Location = new Point(193, 12);
            filterSettings.Name = "filterSettings";
            filterSettings.Size = new Size(165, 124);
            filterSettings.TabIndex = 3;
            filterSettings.TabStop = false;
            filterSettings.Text = "Filter Settings";
            // 
            // FilterCheckbox
            // 
            FilterCheckbox.AutoSize = true;
            FilterCheckbox.Location = new Point(6, 23);
            FilterCheckbox.Name = "FilterCheckbox";
            FilterCheckbox.Size = new Size(52, 19);
            FilterCheckbox.TabIndex = 4;
            FilterCheckbox.Text = "Filter";
            FilterCheckbox.UseVisualStyleBackColor = true;
            FilterCheckbox.CheckedChanged += FilterCheckbox_CheckedChanged;
            // 
            // whitelistOn
            // 
            whitelistOn.AutoSize = true;
            whitelistOn.Location = new Point(6, 73);
            whitelistOn.Name = "whitelistOn";
            whitelistOn.Size = new Size(71, 19);
            whitelistOn.TabIndex = 4;
            whitelistOn.TabStop = true;
            whitelistOn.Text = "Whitelist";
            whitelistOn.UseVisualStyleBackColor = true;
            whitelistOn.CheckedChanged += whitelistOn_CheckedChanged;
            // 
            // whitelistEntries
            // 
            whitelistEntries.Location = new Point(80, 72);
            whitelistEntries.Name = "whitelistEntries";
            whitelistEntries.Size = new Size(75, 23);
            whitelistEntries.TabIndex = 5;
            whitelistEntries.Text = "Whitelist";
            whitelistEntries.UseVisualStyleBackColor = true;
            whitelistEntries.Click += whitelistEntries_Click;
            // 
            // blacklistOn
            // 
            blacklistOn.AutoSize = true;
            blacklistOn.Location = new Point(6, 48);
            blacklistOn.Name = "blacklistOn";
            blacklistOn.Size = new Size(68, 19);
            blacklistOn.TabIndex = 4;
            blacklistOn.TabStop = true;
            blacklistOn.Text = "Blacklist";
            blacklistOn.UseVisualStyleBackColor = true;
            blacklistOn.CheckedChanged += blacklistOn_CheckedChanged;
            // 
            // blacklistEntries
            // 
            blacklistEntries.Location = new Point(80, 48);
            blacklistEntries.Name = "blacklistEntries";
            blacklistEntries.Size = new Size(75, 23);
            blacklistEntries.TabIndex = 4;
            blacklistEntries.Text = "Blacklist";
            blacklistEntries.UseVisualStyleBackColor = true;
            blacklistEntries.Click += blacklistEntries_Click;
            // 
            // connectButton
            // 
            connectButton.Location = new Point(8, 22);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(75, 23);
            connectButton.TabIndex = 5;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(89, 22);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(75, 23);
            refreshButton.TabIndex = 6;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(testButton);
            groupBox1.Controls.Add(COMPortDropdown);
            groupBox1.Controls.Add(connectButton);
            groupBox1.Controls.Add(refreshButton);
            groupBox1.Location = new Point(12, 142);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(346, 83);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Device Selection";
            // 
            // COMPortDropdown
            // 
            COMPortDropdown.FormattingEnabled = true;
            COMPortDropdown.Location = new Point(6, 51);
            COMPortDropdown.Name = "COMPortDropdown";
            COMPortDropdown.Size = new Size(330, 23);
            COMPortDropdown.TabIndex = 4;
            // 
            // testButton
            // 
            testButton.Location = new Point(170, 22);
            testButton.Name = "testButton";
            testButton.Size = new Size(75, 23);
            testButton.TabIndex = 7;
            testButton.Text = "test";
            testButton.UseVisualStyleBackColor = true;
            testButton.Click += testButton_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(373, 244);
            Controls.Add(groupBox1);
            Controls.Add(filterSettings);
            Controls.Add(CANSpeed);
            Name = "Main";
            Text = "Main";
            CANSpeed.ResumeLayout(false);
            CANSpeed.PerformLayout();
            filterSettings.ResumeLayout(false);
            filterSettings.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private RadioButton speed125;
        private GroupBox CANSpeed;
        private RadioButton speed1000;
        private RadioButton speed500;
        private RadioButton speed250;
        private GroupBox filterSettings;
        private RadioButton whitelistOn;
        private RadioButton blacklistOn;
        private Button blacklistEntries;
        private Button whitelistEntries;
        private CheckBox FilterCheckbox;
        private Button connectButton;
        private Button refreshButton;
        private GroupBox groupBox1;
        private ComboBox COMPortDropdown;
        private Button testButton;
    }
}
