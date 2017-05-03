﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAltis.Forms
{
    public partial class frmOptions : Form
    {
        public frmOptions()
        {
            InitializeComponent();
            versionLabel.Text = typeof(Program).Assembly.GetName().Version.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.wantsCursor = chkCursor.Checked;
            Properties.Settings.Default.wantsGameDebug = chkDebugWindow.Checked;
            Properties.Settings.Default.wantsClickSounds = chkClickSounds.Checked;
            Properties.Settings.Default.wantsRandomBg = chkRandomBackgrounds.Checked;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            chkCursor.Checked = Properties.Settings.Default.wantsCursor;
            chkDebugWindow.Checked = Properties.Settings.Default.wantsGameDebug;
            chkClickSounds.Checked = Properties.Settings.Default.wantsClickSounds;
            chkRandomBackgrounds.Checked = Properties.Settings.Default.wantsRandomBg;
        }

		private void button1_Click(object sender, EventArgs e)
		{
			Log.TryOpenUrl(Path.Combine(Directory.GetCurrentDirectory(), "Logs"));
		}
	}
}
