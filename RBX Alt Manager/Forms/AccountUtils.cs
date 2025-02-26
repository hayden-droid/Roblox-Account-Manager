﻿using System;
using System.Windows.Forms;

namespace RBX_Alt_Manager
{
    public partial class AccountUtils : Form
    {
        // sorry i got lazy with this part of code and didnt name any elemennts

        public AccountUtils()
        {
            InitializeComponent();
        }

        private void AccountUtils_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void WhoFollow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AccountManager.SelectedAccount == null) return;

            AccountManager.SelectedAccount.SetFollowPrivacy(WhoFollow.SelectedIndex);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (AccountManager.SelectedAccount == null) return;

            DialogResult result = MessageBox.Show($"Are you sure you want sign out of all other sessions?", "Account Utilities", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
                AccountManager.SelectedAccount.LogOutOfOtherSessions();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (AccountManager.SelectedAccount == null) return;

            AccountManager.SelectedAccount.UnlockPin(textBox5.Text);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (AccountManager.SelectedAccount == null) return;

            if (e.KeyChar == (char)Keys.Enter)
            {
                AccountManager.SelectedAccount.UnlockPin(textBox5.Text);
                button7.Focus();

                return;
            }

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AccountManager.SelectedAccount == null) return;

            AccountManager.SelectedAccount.ChangePassword(textBox1.Text, textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (AccountManager.SelectedAccount == null) return;

            AccountManager.SelectedAccount.ChangeEmail(textBox1.Text, textBox3.Text);
        }

        private void Block_Click(object sender, EventArgs e)
        {
            if (AccountManager.SelectedAccount == null) return;

            AccountManager.SelectedAccount.BlockPlayer(Username.Text);
        }

        private void SetDisplayName_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To set your display name, click 'Open App', go to settings, account info, then change your display name there");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (AccountManager.SelectedAccount == null) return;

            AccountManager.SelectedAccount.SendFriendRequest(Username.Text);
        }
    }
}
