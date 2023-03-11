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
			this.entityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
			this.wSNPCPanel = new System.Windows.Forms.Panel();
			this.wNPCHeckleTxt = new System.Windows.Forms.TextBox();
			this.wNPCTalkTxt = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.wEntityPanel = new System.Windows.Forms.Panel();
			this.wEntityGravityCombo = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.wEntityFacingCombo = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.wEntityClassCombo = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.wEntityRemoveBtn = new System.Windows.Forms.Button();
			this.wEntityMoveBtn = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.wMenuStrip.SuspendLayout();
			this.wRailPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.wNodeFlagsIn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.wRailFlagsIn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.wRailWaitIn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.wRailSizeIn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.wRailSpeedIn)).BeginInit();
			this.wStatusPanel.SuspendLayout();
			this.wSNPCPanel.SuspendLayout();
			this.wEntityPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// wMenuStrip
			// 
			this.wMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.addToolStripMenuItem});
			this.wMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.wMenuStrip.Name = "wMenuStrip";
			this.wMenuStrip.Size = new System.Drawing.Size(1039, 24);
			this.wMenuStrip.TabIndex = 0;
			this.wMenuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.clearToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.ToolTipText = "Save file";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// addToolStripMenuItem
			// 
			this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.railToolStripMenuItem,
            this.entityToolStripMenuItem});
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.addToolStripMenuItem.Text = "Add";
			// 
			// railToolStripMenuItem
			// 
			this.railToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linearToolStripMenuItem});
			this.railToolStripMenuItem.Name = "railToolStripMenuItem";
			this.railToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
			this.railToolStripMenuItem.Text = "Rail";
			// 
			// linearToolStripMenuItem
			// 
			this.linearToolStripMenuItem.Name = "linearToolStripMenuItem";
			this.linearToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
			this.linearToolStripMenuItem.Text = "Linear";
			this.linearToolStripMenuItem.Click += new System.EventHandler(this.linearToolStripMenuItem_Click);
			// 
			// entityToolStripMenuItem
			// 
			this.entityToolStripMenuItem.Name = "entityToolStripMenuItem";
			this.entityToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
			this.entityToolStripMenuItem.Text = "Entity";
			this.entityToolStripMenuItem.Click += new System.EventHandler(this.entityToolStripMenuItem_Click);
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
			this.wNode.Size = new System.Drawing.Size(245, 32);
			this.wNode.TabIndex = 16;
			this.wNode.Text = "Node";
			this.wNode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// wNodeFlagsIn
			// 
			this.wNodeFlagsIn.Hexadecimal = true;
			this.wNodeFlagsIn.Location = new System.Drawing.Point(50, 183);
			this.wNodeFlagsIn.Maximum = new decimal(new int[] {
            0,
            1,
            0,
            0});
			this.wNodeFlagsIn.Name = "wNodeFlagsIn";
			this.wNodeFlagsIn.Size = new System.Drawing.Size(189, 23);
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
			this.wRailFlagsIn.Size = new System.Drawing.Size(189, 23);
			this.wRailFlagsIn.TabIndex = 12;
			this.wRailFlagsIn.ValueChanged += new System.EventHandler(this.wRailFlagsIn_ValueChanged);
			// 
			// wRailWaitIn
			// 
			this.wRailWaitIn.Location = new System.Drawing.Point(50, 154);
			this.wRailWaitIn.Name = "wRailWaitIn";
			this.wRailWaitIn.Size = new System.Drawing.Size(189, 23);
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
			this.wRailSizeIn.Size = new System.Drawing.Size(189, 23);
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
			this.wRailSpeedIn.Size = new System.Drawing.Size(189, 23);
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
			this.wRailLbl.Size = new System.Drawing.Size(237, 32);
			this.wRailLbl.TabIndex = 0;
			this.wRailLbl.Text = "Rail";
			this.wRailLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// wStatusPanel
			// 
			this.wStatusPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.wStatusPanel.Controls.Add(this.wStatusText);
			this.wStatusPanel.Location = new System.Drawing.Point(12, 550);
			this.wStatusPanel.Name = "wStatusPanel";
			this.wStatusPanel.Size = new System.Drawing.Size(1021, 54);
			this.wStatusPanel.TabIndex = 3;
			// 
			// wStatusText
			// 
			this.wStatusText.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.wStatusText.Location = new System.Drawing.Point(3, -2);
			this.wStatusText.Name = "wStatusText";
			this.wStatusText.Size = new System.Drawing.Size(1016, 52);
			this.wStatusText.TabIndex = 1;
			this.wStatusText.Text = "Status:";
			this.wStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// wSNPCPanel
			// 
			this.wSNPCPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.wSNPCPanel.Controls.Add(this.wNPCHeckleTxt);
			this.wSNPCPanel.Controls.Add(this.wNPCTalkTxt);
			this.wSNPCPanel.Controls.Add(this.label3);
			this.wSNPCPanel.Controls.Add(this.label6);
			this.wSNPCPanel.Controls.Add(this.label7);
			this.wSNPCPanel.Location = new System.Drawing.Point(6, 156);
			this.wSNPCPanel.Name = "wSNPCPanel";
			this.wSNPCPanel.Size = new System.Drawing.Size(232, 111);
			this.wSNPCPanel.TabIndex = 17;
			// 
			// wNPCHeckleTxt
			// 
			this.wNPCHeckleTxt.Location = new System.Drawing.Point(49, 65);
			this.wNPCHeckleTxt.Name = "wNPCHeckleTxt";
			this.wNPCHeckleTxt.Size = new System.Drawing.Size(176, 23);
			this.wNPCHeckleTxt.TabIndex = 16;
			this.wNPCHeckleTxt.TextChanged += new System.EventHandler(this.wNPCHeckleTxt_TextChanged);
			// 
			// wNPCTalkTxt
			// 
			this.wNPCTalkTxt.Location = new System.Drawing.Point(49, 37);
			this.wNPCTalkTxt.Name = "wNPCTalkTxt";
			this.wNPCTalkTxt.Size = new System.Drawing.Size(176, 23);
			this.wNPCTalkTxt.TabIndex = 15;
			this.wNPCTalkTxt.TextChanged += new System.EventHandler(this.wNPCTalkTxt_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(30, 15);
			this.label3.TabIndex = 13;
			this.label3.Text = "Talk:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 68);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(46, 15);
			this.label6.TabIndex = 3;
			this.label6.Text = "Heckle:";
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label7.Location = new System.Drawing.Point(3, 2);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(222, 32);
			this.label7.TabIndex = 0;
			this.label7.Text = "Simple NPC";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// wEntityPanel
			// 
			this.wEntityPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.wEntityPanel.Controls.Add(this.wEntityGravityCombo);
			this.wEntityPanel.Controls.Add(this.wSNPCPanel);
			this.wEntityPanel.Controls.Add(this.label2);
			this.wEntityPanel.Controls.Add(this.wEntityFacingCombo);
			this.wEntityPanel.Controls.Add(this.label1);
			this.wEntityPanel.Controls.Add(this.wEntityClassCombo);
			this.wEntityPanel.Controls.Add(this.label8);
			this.wEntityPanel.Controls.Add(this.wEntityRemoveBtn);
			this.wEntityPanel.Controls.Add(this.wEntityMoveBtn);
			this.wEntityPanel.Controls.Add(this.label10);
			this.wEntityPanel.Location = new System.Drawing.Point(787, 27);
			this.wEntityPanel.Name = "wEntityPanel";
			this.wEntityPanel.Size = new System.Drawing.Size(246, 274);
			this.wEntityPanel.TabIndex = 17;
			// 
			// wEntityGravityCombo
			// 
			this.wEntityGravityCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.wEntityGravityCombo.FormattingEnabled = true;
			this.wEntityGravityCombo.Items.AddRange(new object[] {
            "Up",
            "Right",
            "Down",
            "Left"});
			this.wEntityGravityCombo.Location = new System.Drawing.Point(57, 93);
			this.wEntityGravityCombo.Name = "wEntityGravityCombo";
			this.wEntityGravityCombo.Size = new System.Drawing.Size(176, 23);
			this.wEntityGravityCombo.TabIndex = 18;
			this.wEntityGravityCombo.SelectedIndexChanged += new System.EventHandler(this.wEntityGravityCombo_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 15);
			this.label2.TabIndex = 17;
			this.label2.Text = "Gravity:";
			// 
			// wEntityFacingCombo
			// 
			this.wEntityFacingCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.wEntityFacingCombo.FormattingEnabled = true;
			this.wEntityFacingCombo.Items.AddRange(new object[] {
            "Left",
            "Right",
            "None"});
			this.wEntityFacingCombo.Location = new System.Drawing.Point(57, 64);
			this.wEntityFacingCombo.Name = "wEntityFacingCombo";
			this.wEntityFacingCombo.Size = new System.Drawing.Size(176, 23);
			this.wEntityFacingCombo.TabIndex = 16;
			this.wEntityFacingCombo.SelectedIndexChanged += new System.EventHandler(this.wEntityFacingCombo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 67);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 15);
			this.label1.TabIndex = 15;
			this.label1.Text = "Facing:";
			// 
			// wEntityClassCombo
			// 
			this.wEntityClassCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.wEntityClassCombo.FormattingEnabled = true;
			this.wEntityClassCombo.Items.AddRange(new object[] {
            "Arnold",
            "Androld",
            "Trundle",
            "Roboto",
            "Barbara",
            "Zippy",
            "Dok",
            "BickDogel",
            "Electrent"});
			this.wEntityClassCombo.Location = new System.Drawing.Point(57, 34);
			this.wEntityClassCombo.Name = "wEntityClassCombo";
			this.wEntityClassCombo.Size = new System.Drawing.Size(176, 23);
			this.wEntityClassCombo.TabIndex = 14;
			this.wEntityClassCombo.SelectedIndexChanged += new System.EventHandler(this.wEntityClassCombo_SelectedIndexChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(14, 37);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(37, 15);
			this.label8.TabIndex = 6;
			this.label8.Text = "Class:";
			// 
			// wEntityRemoveBtn
			// 
			this.wEntityRemoveBtn.Location = new System.Drawing.Point(6, 127);
			this.wEntityRemoveBtn.Name = "wEntityRemoveBtn";
			this.wEntityRemoveBtn.Size = new System.Drawing.Size(100, 23);
			this.wEntityRemoveBtn.TabIndex = 5;
			this.wEntityRemoveBtn.Text = "Remove";
			this.wEntityRemoveBtn.UseVisualStyleBackColor = true;
			this.wEntityRemoveBtn.Click += new System.EventHandler(this.wEntityRemoveBtn_Click);
			// 
			// wEntityMoveBtn
			// 
			this.wEntityMoveBtn.Location = new System.Drawing.Point(138, 127);
			this.wEntityMoveBtn.Name = "wEntityMoveBtn";
			this.wEntityMoveBtn.Size = new System.Drawing.Size(100, 23);
			this.wEntityMoveBtn.TabIndex = 2;
			this.wEntityMoveBtn.Text = "Move";
			this.wEntityMoveBtn.UseVisualStyleBackColor = true;
			this.wEntityMoveBtn.Click += new System.EventHandler(this.wEntityMoveBtn_Click);
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label10.Location = new System.Drawing.Point(3, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(237, 32);
			this.label10.TabIndex = 0;
			this.label10.Text = "Entity";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// clearToolStripMenuItem
			// 
			this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
			this.clearToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.clearToolStripMenuItem.Text = "Clear";
			this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
			// 
			// LevelEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1039, 614);
			this.Controls.Add(this.wEntityPanel);
			this.Controls.Add(this.wStatusPanel);
			this.Controls.Add(this.wRailPanel);
			this.Controls.Add(this.wImageArea);
			this.Controls.Add(this.wMenuStrip);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MainMenuStrip = this.wMenuStrip;
			this.Name = "LevelEditor";
			this.Text = "Level editor";
			this.Load += new System.EventHandler(this.LevelEditor_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LevelEditor_KeyDown);
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
			this.wSNPCPanel.ResumeLayout(false);
			this.wSNPCPanel.PerformLayout();
			this.wEntityPanel.ResumeLayout(false);
			this.wEntityPanel.PerformLayout();
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
		private Panel wSNPCPanel;
		private Label label3;
		private Label label6;
		private Label label7;
		private TextBox wNPCHeckleTxt;
		private TextBox wNPCTalkTxt;
		private Panel wEntityPanel;
		private Label label8;
		private Button wEntityRemoveBtn;
		private Button wEntityMoveBtn;
		private Label label10;
		private ComboBox wEntityClassCombo;
		private ComboBox wEntityGravityCombo;
		private Label label2;
		private ComboBox wEntityFacingCombo;
		private Label label1;
		private ToolStripMenuItem entityToolStripMenuItem;
		private ToolStripMenuItem clearToolStripMenuItem;
	}
}