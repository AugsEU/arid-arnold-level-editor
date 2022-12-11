namespace AridArnoldEditor
{
	partial class LevelEditor
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.wMenuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.railToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.linearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.wImageArea = new System.Windows.Forms.Panel();
			this.wRailPanel = new System.Windows.Forms.Panel();
			this.wNode = new System.Windows.Forms.Label();
			this.wNodeFlagsIn = new System.Windows.Forms.NumericUpDown();
			this.wNodeFlags = new System.Windows.Forms.Label();
			this.wFlagsLbl = new System.Windows.Forms.Label();
			this.wRailFlagsIn = new System.Windows.Forms.NumericUpDown();
			this.wRailWaitIn = new System.Windows.Forms.NumericUpDown();
			this.wWaitTimeLbl = new System.Windows.Forms.Label();
			this.wRailSizeIn = new System.Windows.Forms.NumericUpDown();
			this.wRailSizeLbl = new System.Windows.Forms.Label();
			this.wRemoveNodeBtn = new System.Windows.Forms.Button();
			this.wRailSpeedIn = new System.Windows.Forms.NumericUpDown();
			this.wRailSpeedLbl = new System.Windows.Forms.Label();
			this.wMoveNodeBtn = new System.Windows.Forms.Button();
			this.wAddNode = new System.Windows.Forms.Button();
			this.wRailLbl = new System.Windows.Forms.Label();
			this.wStatusPanel = new System.Windows.Forms.Panel();
			this.wStatusText = new System.Windows.Forms.Label();
			this.wMenuStrip.SuspendLayout();
			this.wRailPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.wNodeFlagsIn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.wRailFlagsIn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.wRailWaitIn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.wRailSizeIn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.wRailSpeedIn)).BeginInit();
			this.wStatusPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// wMenuStrip
			// 
			this.wMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.addToolStripMenuItem});
			this.wMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.wMenuStrip.Name = "wMenuStrip";
			this.wMenuStrip.Size = new System.Drawing.Size(1190, 24);
			this.wMenuStrip.TabIndex = 0;
			this.wMenuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.ToolTipText = "Save file";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// addToolStripMenuItem
			// 
			this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.railToolStripMenuItem});
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.addToolStripMenuItem.Text = "Add";
			// 
			// railToolStripMenuItem
			// 
			this.railToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linearToolStripMenuItem});
			this.railToolStripMenuItem.Name = "railToolStripMenuItem";
			this.railToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
			this.railToolStripMenuItem.Text = "Rail";
			// 
			// linearToolStripMenuItem
			// 
			this.linearToolStripMenuItem.Name = "linearToolStripMenuItem";
			this.linearToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
			this.linearToolStripMenuItem.Text = "Linear";
			this.linearToolStripMenuItem.Click += new System.EventHandler(this.linearToolStripMenuItem_Click);
			// 
			// wImageArea
			// 
			this.wImageArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.wImageArea.Location = new System.Drawing.Point(12, 27);
			this.wImageArea.Name = "wImageArea";
			this.wImageArea.Size = new System.Drawing.Size(517, 517);
			this.wImageArea.TabIndex = 1;
			// 
			// wRailPanel
			// 
			this.wRailPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.wRailPanel.Controls.Add(this.wNode);
			this.wRailPanel.Controls.Add(this.wNodeFlagsIn);
			this.wRailPanel.Controls.Add(this.wNodeFlags);
			this.wRailPanel.Controls.Add(this.wFlagsLbl);
			this.wRailPanel.Controls.Add(this.wRailFlagsIn);
			this.wRailPanel.Controls.Add(this.wRailWaitIn);
			this.wRailPanel.Controls.Add(this.wWaitTimeLbl);
			this.wRailPanel.Controls.Add(this.wRailSizeIn);
			this.wRailPanel.Controls.Add(this.wRailSizeLbl);
			this.wRailPanel.Controls.Add(this.wRemoveNodeBtn);
			this.wRailPanel.Controls.Add(this.wRailSpeedIn);
			this.wRailPanel.Controls.Add(this.wRailSpeedLbl);
			this.wRailPanel.Controls.Add(this.wMoveNodeBtn);
			this.wRailPanel.Controls.Add(this.wAddNode);
			this.wRailPanel.Controls.Add(this.wRailLbl);
			this.wRailPanel.Location = new System.Drawing.Point(535, 27);
			this.wRailPanel.Name = "wRailPanel";
			this.wRailPanel.Size = new System.Drawing.Size(246, 246);
			this.wRailPanel.TabIndex = 2;
			// 
			// wNode
			// 
			this.wNode.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.wNode.Location = new System.Drawing.Point(-1, 90);
			this.wNode.Name = "wNode";
			this.wNode.Size = new System.Drawing.Size(248, 32);
			this.wNode.TabIndex = 16;
			this.wNode.Text = "Node";
			this.wNode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// wNodeFlagsIn
			// 
			this.wNodeFlagsIn.Location = new System.Drawing.Point(50, 183);
			this.wNodeFlagsIn.Name = "wNodeFlagsIn";
			this.wNodeFlagsIn.Size = new System.Drawing.Size(120, 23);
			this.wNodeFlagsIn.TabIndex = 15;
			this.wNodeFlagsIn.ValueChanged += new System.EventHandler(this.wNodeFlagsIn_ValueChanged);
			// 
			// wNodeFlags
			// 
			this.wNodeFlags.AutoSize = true;
			this.wNodeFlags.Location = new System.Drawing.Point(10, 185);
			this.wNodeFlags.Name = "wNodeFlags";
			this.wNodeFlags.Size = new System.Drawing.Size(37, 15);
			this.wNodeFlags.TabIndex = 14;
			this.wNodeFlags.Text = "Flags:";
			// 
			// wFlagsLbl
			// 
			this.wFlagsLbl.AutoSize = true;
			this.wFlagsLbl.Location = new System.Drawing.Point(7, 64);
			this.wFlagsLbl.Name = "wFlagsLbl";
			this.wFlagsLbl.Size = new System.Drawing.Size(37, 15);
			this.wFlagsLbl.TabIndex = 13;
			this.wFlagsLbl.Text = "Flags:";
			// 
			// wRailFlagsIn
			// 
			this.wRailFlagsIn.Hexadecimal = true;
			this.wRailFlagsIn.Location = new System.Drawing.Point(50, 64);
			this.wRailFlagsIn.Name = "wRailFlagsIn";
			this.wRailFlagsIn.Size = new System.Drawing.Size(120, 23);
			this.wRailFlagsIn.TabIndex = 12;
			this.wRailFlagsIn.ValueChanged += new System.EventHandler(this.wRailFlagsIn_ValueChanged);
			// 
			// wRailWaitIn
			// 
			this.wRailWaitIn.Location = new System.Drawing.Point(50, 154);
			this.wRailWaitIn.Name = "wRailWaitIn";
			this.wRailWaitIn.Size = new System.Drawing.Size(120, 23);
			this.wRailWaitIn.TabIndex = 11;
			this.wRailWaitIn.ValueChanged += new System.EventHandler(this.wRailWaitIn_ValueChanged);
			// 
			// wWaitTimeLbl
			// 
			this.wWaitTimeLbl.AutoSize = true;
			this.wWaitTimeLbl.Location = new System.Drawing.Point(10, 156);
			this.wWaitTimeLbl.Name = "wWaitTimeLbl";
			this.wWaitTimeLbl.Size = new System.Drawing.Size(34, 15);
			this.wWaitTimeLbl.TabIndex = 10;
			this.wWaitTimeLbl.Text = "Wait:";
			// 
			// wRailSizeIn
			// 
			this.wRailSizeIn.Location = new System.Drawing.Point(50, 35);
			this.wRailSizeIn.Name = "wRailSizeIn";
			this.wRailSizeIn.Size = new System.Drawing.Size(120, 23);
			this.wRailSizeIn.TabIndex = 7;
			this.wRailSizeIn.ValueChanged += new System.EventHandler(this.wRailSizeIn_ValueChanged);
			// 
			// wRailSizeLbl
			// 
			this.wRailSizeLbl.AutoSize = true;
			this.wRailSizeLbl.Location = new System.Drawing.Point(14, 37);
			this.wRailSizeLbl.Name = "wRailSizeLbl";
			this.wRailSizeLbl.Size = new System.Drawing.Size(30, 15);
			this.wRailSizeLbl.TabIndex = 6;
			this.wRailSizeLbl.Text = "Size:";
			// 
			// wRemoveNodeBtn
			// 
			this.wRemoveNodeBtn.Location = new System.Drawing.Point(3, 212);
			this.wRemoveNodeBtn.Name = "wRemoveNodeBtn";
			this.wRemoveNodeBtn.Size = new System.Drawing.Size(75, 23);
			this.wRemoveNodeBtn.TabIndex = 5;
			this.wRemoveNodeBtn.Text = "Remove";
			this.wRemoveNodeBtn.UseVisualStyleBackColor = true;
			this.wRemoveNodeBtn.Click += new System.EventHandler(this.wRemoveNodeBtn_Click);
			// 
			// wRailSpeedIn
			// 
			this.wRailSpeedIn.Location = new System.Drawing.Point(50, 125);
			this.wRailSpeedIn.Name = "wRailSpeedIn";
			this.wRailSpeedIn.Size = new System.Drawing.Size(120, 23);
			this.wRailSpeedIn.TabIndex = 4;
			this.wRailSpeedIn.ValueChanged += new System.EventHandler(this.wRailSpeedIn_ValueChanged);
			// 
			// wRailSpeedLbl
			// 
			this.wRailSpeedLbl.AutoSize = true;
			this.wRailSpeedLbl.Location = new System.Drawing.Point(3, 127);
			this.wRailSpeedLbl.Name = "wRailSpeedLbl";
			this.wRailSpeedLbl.Size = new System.Drawing.Size(42, 15);
			this.wRailSpeedLbl.TabIndex = 3;
			this.wRailSpeedLbl.Text = "Speed:";
			// 
			// wMoveNodeBtn
			// 
			this.wMoveNodeBtn.Location = new System.Drawing.Point(84, 212);
			this.wMoveNodeBtn.Name = "wMoveNodeBtn";
			this.wMoveNodeBtn.Size = new System.Drawing.Size(75, 23);
			this.wMoveNodeBtn.TabIndex = 2;
			this.wMoveNodeBtn.Text = "Move";
			this.wMoveNodeBtn.UseVisualStyleBackColor = true;
			this.wMoveNodeBtn.Click += new System.EventHandler(this.wMoveNodeBtn_Click);
			// 
			// wAddNode
			// 
			this.wAddNode.Location = new System.Drawing.Point(165, 212);
			this.wAddNode.Name = "wAddNode";
			this.wAddNode.Size = new System.Drawing.Size(75, 23);
			this.wAddNode.TabIndex = 1;
			this.wAddNode.Text = "Add Node";
			this.wAddNode.UseVisualStyleBackColor = true;
			this.wAddNode.Click += new System.EventHandler(this.wAddNode_Click);
			// 
			// wRailLbl
			// 
			this.wRailLbl.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.wRailLbl.Location = new System.Drawing.Point(3, 0);
			this.wRailLbl.Name = "wRailLbl";
			this.wRailLbl.Size = new System.Drawing.Size(248, 32);
			this.wRailLbl.TabIndex = 0;
			this.wRailLbl.Text = "Rail";
			this.wRailLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// wStatusPanel
			// 
			this.wStatusPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.wStatusPanel.Controls.Add(this.wStatusText);
			this.wStatusPanel.Location = new System.Drawing.Point(12, 669);
			this.wStatusPanel.Name = "wStatusPanel";
			this.wStatusPanel.Size = new System.Drawing.Size(1166, 54);
			this.wStatusPanel.TabIndex = 3;
			// 
			// wStatusText
			// 
			this.wStatusText.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.wStatusText.Location = new System.Drawing.Point(3, -2);
			this.wStatusText.Name = "wStatusText";
			this.wStatusText.Size = new System.Drawing.Size(1160, 52);
			this.wStatusText.TabIndex = 1;
			this.wStatusText.Text = "Status:";
			this.wStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LevelEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1190, 735);
			this.Controls.Add(this.wStatusPanel);
			this.Controls.Add(this.wRailPanel);
			this.Controls.Add(this.wImageArea);
			this.Controls.Add(this.wMenuStrip);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MainMenuStrip = this.wMenuStrip;
			this.Name = "LevelEditor";
			this.Text = "Level editor";
			this.Load += new System.EventHandler(this.LevelEditor_Load);
			this.wMenuStrip.ResumeLayout(false);
			this.wMenuStrip.PerformLayout();
			this.wRailPanel.ResumeLayout(false);
			this.wRailPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.wNodeFlagsIn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.wRailFlagsIn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.wRailWaitIn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.wRailSizeIn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.wRailSpeedIn)).EndInit();
			this.wStatusPanel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MenuStrip wMenuStrip;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem openToolStripMenuItem;
		private Panel wImageArea;
		private ToolStripMenuItem addToolStripMenuItem;
		private ToolStripMenuItem railToolStripMenuItem;
		private ToolStripMenuItem linearToolStripMenuItem;
		private Panel wRailPanel;
		private Button wAddNode;
		private Label wRailLbl;
		private NumericUpDown wRailSpeedIn;
		private Label wRailSpeedLbl;
		private Button wMoveNodeBtn;
		private Button wRemoveNodeBtn;
		private Panel wStatusPanel;
		private Label wStatusText;
		private NumericUpDown wRailSizeIn;
		private Label wRailSizeLbl;
		private ToolStripMenuItem saveToolStripMenuItem;
		private NumericUpDown wRailWaitIn;
		private Label wWaitTimeLbl;
		private Label wFlagsLbl;
		private NumericUpDown wRailFlagsIn;
		private Label wNode;
		private NumericUpDown wNodeFlagsIn;
		private Label wNodeFlags;
	}
}