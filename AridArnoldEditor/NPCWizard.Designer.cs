namespace AridArnoldEditor
{
	partial class NPCWizard
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
			wOKBtn = new Button();
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			wNameTxb = new TextBox();
			wTalkTxb = new TextBox();
			wHeckleTxb = new TextBox();
			wCancelBtn = new Button();
			SuspendLayout();
			// 
			// wOKBtn
			// 
			wOKBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			wOKBtn.Location = new Point(166, 98);
			wOKBtn.Name = "wOKBtn";
			wOKBtn.Size = new Size(75, 23);
			wOKBtn.TabIndex = 0;
			wOKBtn.Text = "OK";
			wOKBtn.UseVisualStyleBackColor = true;
			wOKBtn.Click += wOKBtn_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 9);
			label1.Name = "label1";
			label1.Size = new Size(69, 15);
			label1.TabIndex = 1;
			label1.Text = "NPC Name:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(37, 38);
			label2.Name = "label2";
			label2.Size = new Size(44, 15);
			label2.TabIndex = 2;
			label2.Text = "Talk ID:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(21, 67);
			label3.Name = "label3";
			label3.Size = new Size(60, 15);
			label3.TabIndex = 3;
			label3.Text = "Heckle ID:";
			// 
			// wNameTxb
			// 
			wNameTxb.Location = new Point(87, 6);
			wNameTxb.Name = "wNameTxb";
			wNameTxb.Size = new Size(242, 23);
			wNameTxb.TabIndex = 4;
			// 
			// wTalkTxb
			// 
			wTalkTxb.Location = new Point(87, 35);
			wTalkTxb.Name = "wTalkTxb";
			wTalkTxb.Size = new Size(242, 23);
			wTalkTxb.TabIndex = 5;
			// 
			// wHeckleTxb
			// 
			wHeckleTxb.Location = new Point(87, 64);
			wHeckleTxb.Name = "wHeckleTxb";
			wHeckleTxb.Size = new Size(242, 23);
			wHeckleTxb.TabIndex = 6;
			// 
			// wCancelBtn
			// 
			wCancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			wCancelBtn.Location = new Point(254, 98);
			wCancelBtn.Name = "wCancelBtn";
			wCancelBtn.Size = new Size(75, 23);
			wCancelBtn.TabIndex = 7;
			wCancelBtn.Text = "Cancel";
			wCancelBtn.UseVisualStyleBackColor = true;
			wCancelBtn.Click += wCancelBtn_Click;
			// 
			// NPCWizard
			// 
			AcceptButton = wOKBtn;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(341, 133);
			Controls.Add(wCancelBtn);
			Controls.Add(wHeckleTxb);
			Controls.Add(wTalkTxb);
			Controls.Add(wNameTxb);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(wOKBtn);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "NPCWizard";
			Text = "NPC Wizard";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button wOKBtn;
		private Label label1;
		private Label label2;
		private Label label3;
		private TextBox wNameTxb;
		private TextBox wTalkTxb;
		private TextBox wHeckleTxb;
		private Button wCancelBtn;
	}
}