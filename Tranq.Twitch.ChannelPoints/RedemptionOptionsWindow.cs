using System;
using System.ComponentModel;
using System.Windows.Forms;
using Tranq.Twitch.ChannelPoints.Core;
using Tranq.Twitch.ChannelPoints.Core.Model;

namespace Tranq.Twitch.ChannelPoints
{
    public partial class RedemptionOptionsWindow : Form
    {
        private readonly IChannelPointsService channelPointsService;

        public RedemptionOptionsWindow(IChannelPointsService channelPointsService)
        {
            InitializeComponent();
            this.channelPointsService = channelPointsService;
            comboBox1.DataSource = Enum.GetValues(typeof(OptionAction));
        }

        private void RedemptionOptionsWindow_Load(object sender, EventArgs e)
        {
            LoadOptions();
        }

        RedemptionOption ActiveSelection = null;

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox source = (ListBox)sender;
            ActiveSelection = (RedemptionOption)source.SelectedItem;

            if (ActiveSelection != null)
            {
                textBox_redemptionName.Text = ActiveSelection.RewardName;
                comboBox1.SelectedIndex = (int)ActiveSelection.OptionAction;

                if (ActiveSelection.OptionAction == OptionAction.AudioCommand)
                    EnableAudioCommandFields();
                else if (ActiveSelection.OptionAction == OptionAction.TwitchCommand)
                    EnableTwitchCommandFields();

                button_save.Enabled = true;
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            var actionOption = (OptionAction)comboBox1.SelectedIndex;

            switch (actionOption)
            {
                case OptionAction.NoAction:
                    channelPointsService.UpdateRedemptionOption(ActiveSelection, actionOption);
                    break;
                case OptionAction.TwitchCommand:
                    channelPointsService.UpdateRedemptionOption(ActiveSelection, actionOption, textBox_CommandText.Text, checkBox_UsesInput.Checked, checkBox_ExecuteOnRedeemer.Checked, checkBox_SendResponse.Checked, textBox_Response.Text);
                    break;
                case OptionAction.AudioCommand:
                    channelPointsService.UpdateRedemptionOption(ActiveSelection, actionOption, textBox_SelectSound.Text);
                    break;
                default:
                    // Hmm this should never happen.
                    throw new NotImplementedException();
            }

            LoadOptions();
        }

        private void LoadOptions()
        {
            listBox1.ClearSelected();
            listBox1.Items.Clear();
            foreach (var option in channelPointsService.GetOptions())
                listBox1.Items.Add(option);

            button_save.Enabled = false;
            groupBox_SoundSettings.Visible = false;
            groupBox_CommandSettings.Visible = false;
            groupBox_ResponseSettings.Visible = false;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var result = (FileDialog)sender;
            textBox_SelectSound.Text = result.FileName;
        }

        private void button_selectSound_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetWindow();

            var actionOption = (OptionAction)comboBox1.SelectedIndex;
            switch (actionOption)
            {
                case OptionAction.TwitchCommand:
                    EnableTwitchCommandFields();
                    break;
                case OptionAction.AudioCommand:
                    EnableAudioCommandFields();
                    break;
            }
        }

        private void ResetWindow()
        {
            groupBox_SoundSettings.Visible = false;
            groupBox_CommandSettings.Visible = false;
            groupBox_ResponseSettings.Visible = false;
        }

        private void EnableAudioCommandFields()
        {
            groupBox_SoundSettings.Visible = true;
            groupBox_CommandSettings.Visible = false;

            if (ActiveSelection != null)
            {
                textBox_SelectSound.Text = ActiveSelection.AudioFile;
            }
        }

        private void EnableTwitchCommandFields()
        {
            groupBox_SoundSettings.Visible = false;
            groupBox_CommandSettings.Visible = true;

            groupBox_ResponseSettings.Visible = false;
            if (ActiveSelection != null)
            {
                textBox_CommandText.Text = ActiveSelection.ChatCommand;
                checkBox_UsesInput.Checked = ActiveSelection.UsesInput;
                checkBox_SendResponse.Checked = ActiveSelection.RespondInChat;
                checkBox_ExecuteOnRedeemer.Checked = ActiveSelection.ExecuteOnRedeemer;
                textBox_Response.Text = ActiveSelection.ChatResponse;

                if (ActiveSelection.ExecuteOnRedeemer)
                {
                    checkBox_UsesInput.Checked = false;
                    checkBox_UsesInput.Enabled = false;
                }

                if (ActiveSelection.RespondInChat)
                {
                    groupBox_ResponseSettings.Visible = true;
                }
            }
        }

        private void checkBox_SendResponse_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = (CheckBox)sender;
            if (checkBox.Checked)
            {
                groupBox_ResponseSettings.Visible = true;
            }
            else
            {
                groupBox_ResponseSettings.Visible = false;
            }
        }

        private void checkBox_ExecuteOnRedeemer_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ExecuteOnRedeemer.Checked)
            {
                checkBox_UsesInput.Checked = false;
                checkBox_UsesInput.Enabled = false;
            }
            else
            {
                checkBox_UsesInput.Enabled = true;
            }
        }
    }
}
