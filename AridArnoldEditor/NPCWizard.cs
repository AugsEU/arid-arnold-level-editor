using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AridArnoldEditor
{
	public partial class NPCWizard : Form
	{
		public string NPCName { get; set; }
		public string TalkID { get; set; }
		public string HeckleID { get; set; }

		public NPCWizard()
		{
			InitializeComponent();
		}

		private void wOKBtn_Click(object sender, EventArgs e)
		{
			NPCName = wNameTxb.Text;
			TalkID = wTalkTxb.Text;
			HeckleID = wHeckleTxb.Text;

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void wCancelBtn_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
