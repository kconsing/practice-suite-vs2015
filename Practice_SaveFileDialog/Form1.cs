using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice_SaveFileDialog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = " Text File|*.txt"; // Specify allowed file types
            sfd.FileName = "My Text File";
            sfd.Title = "Save File";

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK) // Make sure they don't hit cancel or close Save Dialog
            {
                rtb1.SaveFile(sfd.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            //enter key is down
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult dialog = MessageBox.Show("Save?", "Save File", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes) button1.PerformClick();
            }
        }
    }
}
