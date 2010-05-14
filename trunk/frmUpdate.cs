using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using System.Diagnostics;

namespace JarrettVance.ChapterTools
{
    public partial class frmUpdate : Form
    {
        public frmUpdate()
        {
            InitializeComponent();
        }

        public string Info { get { return lblInfo.Text; } set { lblInfo.Text = value; } }
        public string MoreInfoLink { get; set; }
        public XDocument Manifest { get; set; }
        public string ManifestFile { get; protected set; }

        private void linkInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkInfo.LinkVisited = true;
            System.Diagnostics.Process.Start(MoreInfoLink);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ManifestFile = Application.ExecutablePath.Replace(".EXE", ".exe").Replace(".exe", ".manifest");
                Manifest.Save(ManifestFile);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                MessageBox.Show("Could not save updated manifest.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }
    }
}
