using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdfPasswordRemover
{
    public partial class PwdWindow : Form
    {
        private readonly PwdManager _pwdManager;

        public PwdWindow()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            _pwdManager = PwdManager.Instance;
        }

        protected override void OnLoad(EventArgs e)
        {
            if(_pwdManager.isPasswordSet)
            {
                PwdTxt.Text = _pwdManager.Password;
            }
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            _pwdManager.SetPassword(PwdTxt.Text);
            Close();
        }
    }
}
