namespace USBtoCAN_GUI_V2
{
    partial class Whitelist
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            whitelistDelete = new Button();
            whitelistAdd = new Button();
            whitelistEntries = new ListView();
            filter = new ColumnHeader();
            whitelistTextbox = new TextBox();
            whiteWriteButton = new Button();
            whiteReadButton = new Button();
            whiteBurnButton = new Button();
            SuspendLayout();
            // 
            // whitelistDelete
            // 
            whitelistDelete.Location = new Point(400, 70);
            whitelistDelete.Name = "whitelistDelete";
            whitelistDelete.Size = new Size(84, 23);
            whitelistDelete.TabIndex = 5;
            whitelistDelete.Text = "Delete Entry";
            whitelistDelete.UseVisualStyleBackColor = true;
            whitelistDelete.Click += whitelistDelete_Click;
            // 
            // whitelistAdd
            // 
            whitelistAdd.Location = new Point(400, 41);
            whitelistAdd.Name = "whitelistAdd";
            whitelistAdd.Size = new Size(84, 23);
            whitelistAdd.TabIndex = 4;
            whitelistAdd.Text = "Add Entry";
            whitelistAdd.UseVisualStyleBackColor = true;
            whitelistAdd.Click += whitelistAdd_Click;
            // 
            // whitelistEntries
            // 
            whitelistEntries.Columns.AddRange(new ColumnHeader[] { filter });
            whitelistEntries.Location = new Point(12, 12);
            whitelistEntries.MultiSelect = false;
            whitelistEntries.Name = "whitelistEntries";
            whitelistEntries.Size = new Size(382, 168);
            whitelistEntries.TabIndex = 3;
            whitelistEntries.UseCompatibleStateImageBehavior = false;
            whitelistEntries.View = View.Details;
            // 
            // filter
            // 
            filter.Text = "Filters";
            // 
            // whitelistTextbox
            // 
            whitelistTextbox.Location = new Point(400, 12);
            whitelistTextbox.Name = "whitelistTextbox";
            whitelistTextbox.Size = new Size(84, 23);
            whitelistTextbox.TabIndex = 6;
            // 
            // whiteWriteButton
            // 
            whiteWriteButton.Location = new Point(400, 99);
            whiteWriteButton.Name = "whiteWriteButton";
            whiteWriteButton.Size = new Size(84, 23);
            whiteWriteButton.TabIndex = 7;
            whiteWriteButton.Text = "Write";
            whiteWriteButton.UseVisualStyleBackColor = true;
            whiteWriteButton.Click += whiteWriteButton_Click;
            // 
            // whiteReadButton
            // 
            whiteReadButton.Location = new Point(400, 128);
            whiteReadButton.Name = "whiteReadButton";
            whiteReadButton.Size = new Size(84, 23);
            whiteReadButton.TabIndex = 8;
            whiteReadButton.Text = "Read";
            whiteReadButton.UseVisualStyleBackColor = true;
            whiteReadButton.Click += whiteReadButton_Click;
            // 
            // whiteBurnButton
            // 
            whiteBurnButton.Location = new Point(400, 157);
            whiteBurnButton.Name = "whiteBurnButton";
            whiteBurnButton.Size = new Size(84, 23);
            whiteBurnButton.TabIndex = 9;
            whiteBurnButton.Text = "Burn";
            whiteBurnButton.UseVisualStyleBackColor = true;
            whiteBurnButton.Click += whiteBurnButton_Click;
            // 
            // Whitelist
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(493, 192);
            Controls.Add(whiteBurnButton);
            Controls.Add(whiteReadButton);
            Controls.Add(whiteWriteButton);
            Controls.Add(whitelistTextbox);
            Controls.Add(whitelistDelete);
            Controls.Add(whitelistAdd);
            Controls.Add(whitelistEntries);
            Name = "Whitelist";
            Text = "Whitelist";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button whitelistDelete;
        private Button whitelistAdd;
        private ListView whitelistEntries;
        private ColumnHeader filter;
        private TextBox whitelistTextbox;
        private Button whiteWriteButton;
        private Button whiteReadButton;
        private Button whiteBurnButton;
    }
}