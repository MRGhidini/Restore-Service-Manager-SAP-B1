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

namespace ServiceManagerDisabledSAPB1
{
    public partial class ServiceManagerDisabled : Form
    {
        public ServiceManagerDisabled()
        {
            InitializeComponent();
        }

        private void btnrestore_Click(object sender, EventArgs e)
        {
            string pathOrin = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\AppData\Local\SAP\SAP Business One";
            string arcCreate = Properties.Resources.b1_current_user;

            if (Directory.Exists(pathOrin))
            {
                try
                {
                   if(File.Exists(pathOrin + @"\b1-current-user.xml")) File.Delete(pathOrin + @"\b1-current-user.xml");
                    CreateFileWrite(pathOrin + @"\b1-current-user.xml", Properties.Resources.b1_current_user);

                    MessageBox.Show("Services successfully restored, restart your computer. ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch(Exception err)
                {
                    MessageBox.Show("Erro: " + err, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }else
            {
                MessageBox.Show("SAP path does not exist on this machine or user: \n " + pathOrin, "Warning" ,MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static void CreateFileWrite(string path, string text)
        {

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(text);
                }
            }

        }
    }
}
