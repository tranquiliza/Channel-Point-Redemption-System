namespace Tranq.Twitch.ChannelPoints
{
    partial class RedemptionOptionsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RedemptionOptionsWindow));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox_redemptionName = new System.Windows.Forms.TextBox();
            this.button_save = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button_selectSound = new System.Windows.Forms.Button();
            this.textBox_SelectSound = new System.Windows.Forms.TextBox();
            this.label_CommandType = new System.Windows.Forms.Label();
            this.groupBox_SoundSettings = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_CommandSettings = new System.Windows.Forms.GroupBox();
            this.checkBox_SendResponse = new System.Windows.Forms.CheckBox();
            this.textBox_Response = new System.Windows.Forms.TextBox();
            this.checkBox_UsesInput = new System.Windows.Forms.CheckBox();
            this.textBox_CommandText = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox_ResponseSettings = new System.Windows.Forms.GroupBox();
            this.checkBox_ExecuteOnRedeemer = new System.Windows.Forms.CheckBox();
            this.groupBox_SoundSettings.SuspendLayout();
            this.groupBox_CommandSettings.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox_ResponseSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(303, 342);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(322, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(214, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox_redemptionName
            // 
            this.textBox_redemptionName.Enabled = false;
            this.textBox_redemptionName.Location = new System.Drawing.Point(322, 69);
            this.textBox_redemptionName.Name = "textBox_redemptionName";
            this.textBox_redemptionName.Size = new System.Drawing.Size(389, 20);
            this.textBox_redemptionName.TabIndex = 2;
            // 
            // button_save
            // 
            this.button_save.Enabled = false;
            this.button_save.Location = new System.Drawing.Point(3, 220);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 3;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button_selectSound
            // 
            this.button_selectSound.Location = new System.Drawing.Point(6, 19);
            this.button_selectSound.Name = "button_selectSound";
            this.button_selectSound.Size = new System.Drawing.Size(75, 23);
            this.button_selectSound.TabIndex = 4;
            this.button_selectSound.Text = "Select Sound";
            this.button_selectSound.UseVisualStyleBackColor = true;
            this.button_selectSound.Click += new System.EventHandler(this.button_selectSound_Click);
            // 
            // textBox_SelectSound
            // 
            this.textBox_SelectSound.Enabled = false;
            this.textBox_SelectSound.Location = new System.Drawing.Point(87, 21);
            this.textBox_SelectSound.Name = "textBox_SelectSound";
            this.textBox_SelectSound.Size = new System.Drawing.Size(308, 20);
            this.textBox_SelectSound.TabIndex = 5;
            // 
            // label_CommandType
            // 
            this.label_CommandType.AutoSize = true;
            this.label_CommandType.Location = new System.Drawing.Point(322, 9);
            this.label_CommandType.Name = "label_CommandType";
            this.label_CommandType.Size = new System.Drawing.Size(81, 13);
            this.label_CommandType.TabIndex = 6;
            this.label_CommandType.Text = "Command Type";
            // 
            // groupBox_SoundSettings
            // 
            this.groupBox_SoundSettings.Controls.Add(this.button_selectSound);
            this.groupBox_SoundSettings.Controls.Add(this.textBox_SelectSound);
            this.groupBox_SoundSettings.Location = new System.Drawing.Point(3, 3);
            this.groupBox_SoundSettings.Name = "groupBox_SoundSettings";
            this.groupBox_SoundSettings.Size = new System.Drawing.Size(412, 62);
            this.groupBox_SoundSettings.TabIndex = 7;
            this.groupBox_SoundSettings.TabStop = false;
            this.groupBox_SoundSettings.Text = "Sound Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(322, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Redemption Name";
            // 
            // groupBox_CommandSettings
            // 
            this.groupBox_CommandSettings.Controls.Add(this.checkBox_ExecuteOnRedeemer);
            this.groupBox_CommandSettings.Controls.Add(this.checkBox_UsesInput);
            this.groupBox_CommandSettings.Controls.Add(this.textBox_CommandText);
            this.groupBox_CommandSettings.Controls.Add(this.checkBox_SendResponse);
            this.groupBox_CommandSettings.Location = new System.Drawing.Point(3, 71);
            this.groupBox_CommandSettings.Name = "groupBox_CommandSettings";
            this.groupBox_CommandSettings.Size = new System.Drawing.Size(412, 82);
            this.groupBox_CommandSettings.TabIndex = 9;
            this.groupBox_CommandSettings.TabStop = false;
            this.groupBox_CommandSettings.Text = "Command Settings";
            // 
            // checkBox_SendResponse
            // 
            this.checkBox_SendResponse.AutoSize = true;
            this.checkBox_SendResponse.Location = new System.Drawing.Point(87, 46);
            this.checkBox_SendResponse.Name = "checkBox_SendResponse";
            this.checkBox_SendResponse.Size = new System.Drawing.Size(102, 17);
            this.checkBox_SendResponse.TabIndex = 3;
            this.checkBox_SendResponse.Text = "Send Response";
            this.checkBox_SendResponse.UseVisualStyleBackColor = true;
            this.checkBox_SendResponse.CheckedChanged += new System.EventHandler(this.checkBox_SendResponse_CheckedChanged);
            // 
            // textBox_Response
            // 
            this.textBox_Response.Location = new System.Drawing.Point(7, 19);
            this.textBox_Response.Name = "textBox_Response";
            this.textBox_Response.Size = new System.Drawing.Size(382, 20);
            this.textBox_Response.TabIndex = 2;
            // 
            // checkBox_UsesInput
            // 
            this.checkBox_UsesInput.AutoSize = true;
            this.checkBox_UsesInput.Location = new System.Drawing.Point(7, 46);
            this.checkBox_UsesInput.Name = "checkBox_UsesInput";
            this.checkBox_UsesInput.Size = new System.Drawing.Size(77, 17);
            this.checkBox_UsesInput.TabIndex = 1;
            this.checkBox_UsesInput.Text = "Uses Input";
            this.checkBox_UsesInput.UseVisualStyleBackColor = true;
            // 
            // textBox_CommandText
            // 
            this.textBox_CommandText.Location = new System.Drawing.Point(7, 20);
            this.textBox_CommandText.Name = "textBox_CommandText";
            this.textBox_CommandText.Size = new System.Drawing.Size(382, 20);
            this.textBox_CommandText.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox_SoundSettings);
            this.flowLayoutPanel1.Controls.Add(this.groupBox_CommandSettings);
            this.flowLayoutPanel1.Controls.Add(this.groupBox_ResponseSettings);
            this.flowLayoutPanel1.Controls.Add(this.button_save);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(322, 95);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(449, 256);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // groupBox_ResponseSettings
            // 
            this.groupBox_ResponseSettings.Controls.Add(this.textBox_Response);
            this.groupBox_ResponseSettings.Location = new System.Drawing.Point(3, 159);
            this.groupBox_ResponseSettings.Name = "groupBox_ResponseSettings";
            this.groupBox_ResponseSettings.Size = new System.Drawing.Size(412, 55);
            this.groupBox_ResponseSettings.TabIndex = 11;
            this.groupBox_ResponseSettings.TabStop = false;
            this.groupBox_ResponseSettings.Text = "Response Settings";
            // 
            // checkBox_ExecuteOnRedeemer
            // 
            this.checkBox_ExecuteOnRedeemer.AutoSize = true;
            this.checkBox_ExecuteOnRedeemer.Location = new System.Drawing.Point(195, 46);
            this.checkBox_ExecuteOnRedeemer.Name = "checkBox_ExecuteOnRedeemer";
            this.checkBox_ExecuteOnRedeemer.Size = new System.Drawing.Size(132, 17);
            this.checkBox_ExecuteOnRedeemer.TabIndex = 4;
            this.checkBox_ExecuteOnRedeemer.Text = "Execute on Redeemer";
            this.checkBox_ExecuteOnRedeemer.UseVisualStyleBackColor = true;
            this.checkBox_ExecuteOnRedeemer.CheckedChanged += new System.EventHandler(this.checkBox_ExecuteOnRedeemer_CheckedChanged);
            // 
            // RedemptionOptionsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 360);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_CommandType);
            this.Controls.Add(this.textBox_redemptionName);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RedemptionOptionsWindow";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.RedemptionOptionsWindow_Load);
            this.groupBox_SoundSettings.ResumeLayout(false);
            this.groupBox_SoundSettings.PerformLayout();
            this.groupBox_CommandSettings.ResumeLayout(false);
            this.groupBox_CommandSettings.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox_ResponseSettings.ResumeLayout(false);
            this.groupBox_ResponseSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox_redemptionName;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button_selectSound;
        private System.Windows.Forms.TextBox textBox_SelectSound;
        private System.Windows.Forms.Label label_CommandType;
        private System.Windows.Forms.GroupBox groupBox_SoundSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox_CommandSettings;
        private System.Windows.Forms.CheckBox checkBox_UsesInput;
        private System.Windows.Forms.TextBox textBox_CommandText;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBox_SendResponse;
        private System.Windows.Forms.TextBox textBox_Response;
        private System.Windows.Forms.GroupBox groupBox_ResponseSettings;
        private System.Windows.Forms.CheckBox checkBox_ExecuteOnRedeemer;
    }
}