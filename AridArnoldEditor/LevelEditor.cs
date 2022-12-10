namespace AridArnoldEditor
{
	public partial class LevelEditor : Form
	{
		#region rConstants

		public static int NUM_TILES = 32;
		public static int TILE_SIZE = 16;

		#endregion rConstants


		#region rTypes

		enum FormActionState
		{
			None,
			AddingRail,
			AddingNode,
			MovingNode
		}

		#endregion rTypes



		#region rMembers

		//Current level
		Bitmap? mLoadedImage;
		string mFilePath;

		//State
		FormActionState mActionState;

		//Tiles
		TilePanel[,] mPanels;
		DrawLevelArea mDrawLevelArea;

		//Selection
		Panel mSelectionPanel;
		Point mSelectedTileCoord;

		//Rails
		int mSelectedRailIdx;

		//Data
		AuxData mAuxData;

		#endregion rMembers





		#region rInitialisation

		public LevelEditor()
		{
			//Form
			InitializeComponent();

			MinimumSize = Size;

			//Loaded level
			mLoadedImage = null;
			mFilePath = "";

			//Rails
			mSelectedRailIdx = -1;
			mAuxData = new AuxData();

			//Tiles
			mPanels = new TilePanel[NUM_TILES, NUM_TILES];
			for (int x = 0; x < NUM_TILES; x++)
			{
				for (int y = 0; y < NUM_TILES; y++)
				{
					mPanels[x, y] = new TilePanel(x, y);
					mPanels[x, y].Size = new Size(TILE_SIZE, TILE_SIZE);

					mPanels[x, y].Location = new Point(x * TILE_SIZE, y * TILE_SIZE);
					mPanels[x, y].SendToBack();
					wImageArea.Controls.Add(mPanels[x, y]);
				}
			}

			//Drawer
			mDrawLevelArea = new DrawLevelArea(this);
			mDrawLevelArea.Size = wImageArea.Size;
			wImageArea.Controls.Add(mDrawLevelArea);

			//Selection
			mSelectionPanel = new Panel();
			mSelectionPanel.Size = new Size(TILE_SIZE, TILE_SIZE);
			mSelectionPanel.BackColor = Color.Transparent;
			mSelectionPanel.BorderStyle = BorderStyle.Fixed3D;
			mSelectionPanel.MouseClick += ClickOnSelectTile;
			OnClickTile(new Point(-1, -1));
			wImageArea.Controls.Add(mSelectionPanel);
			mSelectionPanel.BringToFront();
			mDrawLevelArea.BringToFront();

			//State
			SetAction(FormActionState.None);

			UpdateRailPanel();
		}

		private void LevelEditor_Load(object sender, EventArgs e)
		{

		}

		#endregion rInitialisation


		#region rForm


		#endregion rForm



		#region rWidgets

		/// <summary>
		/// File -> Open callback
		/// </summary>
		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			mFilePath = "";

			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "Level image (*.png)|*.png";
				openFileDialog.FilterIndex = 2;
				openFileDialog.RestoreDirectory = true;

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					//Get the path of specified file
					mFilePath = openFileDialog.FileName;
				}
			}

			if (File.Exists(mFilePath))
			{
				LoadLevel(mFilePath);
			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(mFilePath != "")
			{
				mAuxData.SaveFile(mFilePath);
			}
		}

		private void linearToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SetAction(FormActionState.AddingRail);
		}

		private void wAddNode_Click(object sender, EventArgs e)
		{
			SetAction(FormActionState.AddingNode);
		}

		private void wRemoveNodeBtn_Click(object sender, EventArgs e)
		{
			int railIdx = GetRailIdxAtPoint(mSelectedTileCoord);

			if(railIdx != -1)
			{
				mAuxData.LinearRails[railIdx].RemoveNode(mSelectedTileCoord);

				if(mAuxData.LinearRails[railIdx].GetNodes().Count == 0)
				{
					mAuxData.LinearRails.RemoveAt(railIdx);
					mSelectedRailIdx = -1;
				}
			}

			OnClickTile(mSelectedTileCoord);
		}

		private void wMoveNodeBtn_Click(object sender, EventArgs e)
		{
			SetAction(FormActionState.MovingNode);
		}

		private void ClickOnSelectTile(object? sender, MouseEventArgs e)
		{
			OnClickTile(mSelectedTileCoord);
		}

		private void UpdateRailPanel()
		{
			wRailPanel.Enabled = mSelectedRailIdx != -1;
			if(mSelectedRailIdx != -1)
			{
				wRailSpeedIn.Value = (decimal)mAuxData.LinearRails[mSelectedRailIdx].GetSpeed();
				wRailSizeIn.Value = (decimal)mAuxData.LinearRails[mSelectedRailIdx].GetSize();
				wCycleRailIn.Checked = mAuxData.LinearRails[mSelectedRailIdx].GetCylce();
			}
		}

		private void wCycleRailIn_CheckedChanged(object sender, EventArgs e)
		{
			if (mSelectedRailIdx != -1)
			{
				mAuxData.LinearRails[mSelectedRailIdx].SetCycle((bool)wCycleRailIn.Checked);
				InvalidateAll();
			}
		}

		private void wRailSpeedIn_ValueChanged(object sender, EventArgs e)
		{
			if (mSelectedRailIdx != -1)
			{
				mAuxData.LinearRails[mSelectedRailIdx].ChangeSpeed((float)wRailSpeedIn.Value);
			}
		}

		private void wRailSizeIn_ValueChanged(object sender, EventArgs e)
		{
			if (mSelectedRailIdx != -1)
			{
				mAuxData.LinearRails[mSelectedRailIdx].SetSize((int)wRailSizeIn.Value);
			}
		}


		private void InvalidateAll()
		{
			for (int x = 0; x < NUM_TILES; x++)
			{
				for (int y = 0; y < NUM_TILES; y++)
				{
					mPanels[x, y].Invalidate();
				}
			}

			mDrawLevelArea.Invalidate();
			mSelectionPanel.Invalidate();
		}

		#endregion rWidgets





		#region rLevelEditing

		private void LoadLevel(string filePath)
		{
			mLoadedImage = new Bitmap(filePath);

			for (int x = 0; x < NUM_TILES; x++)
			{
				for (int y = 0; y < NUM_TILES; y++)
				{
					mPanels[x, y].BackColor = mLoadedImage.GetPixel(x, y);
				}
			}

			mAuxData.LoadFile(filePath);

			SetAction(FormActionState.None);
			OnClickTile(mSelectedTileCoord);
			InvalidateAll();
		}

		public void OnClickTile(Point tileClicked)
		{
			//Deal with Action
			DoAction(mActionState, tileClicked);

			//Rail
			mSelectedRailIdx = GetRailIdxAtPoint(tileClicked);
			UpdateRailPanel();

			//Update selection point
			mSelectedTileCoord = tileClicked;
			mSelectionPanel.Location = new Point(tileClicked.X * TILE_SIZE, tileClicked.Y * TILE_SIZE);
			if (tileClicked.X >= 0 && tileClicked.Y >= 0)
			{
				mSelectionPanel.BackColor = mPanels[tileClicked.X, tileClicked.Y].BackColor;
			}
		}

		private void DoAction(FormActionState action, Point tile)
		{
			switch (action)
			{
				case FormActionState.AddingRail:
					if (GetRailIdxAtPoint(tile) == -1)
					{
						LinearRail newRail = new LinearRail(1.0f);
						newRail.AddNode(tile);
						mAuxData.LinearRails.Add(newRail);
					}
					break;
				case FormActionState.AddingNode:
					int railIdx = GetRailIdxAtPoint(mSelectedTileCoord);
					if (railIdx != -1)
					{
						mAuxData.LinearRails[railIdx].AddNode(tile);
					}
					break;
				case FormActionState.MovingNode:
					railIdx = GetRailIdxAtPoint(mSelectedTileCoord);
					if(railIdx != -1)
					{
						mAuxData.LinearRails[railIdx].MoveNode(mSelectedTileCoord, tile);
					}
					break;
				case FormActionState.None:
				default:
					break;
			}

			//Draw
			mDrawLevelArea.SetData(mAuxData);
			InvalidateAll();

			SetAction(FormActionState.None);
		}

		private int GetRailIdxAtPoint(Point tile)
		{
			for (int i = 0; i < mAuxData.LinearRails.Count; i++)
			{
				if (mAuxData.LinearRails[i].HasNodeAtPoint(tile))
				{
					return i;
				}
			}

			return -1;
		}

		#endregion rLevelEditing




		#region rUtility

		private string GetStatusText(FormActionState state)
		{
			switch (state)
			{
				case FormActionState.None:
					return "None";
				case FormActionState.AddingRail:
					return "Addding Rail...";
				case FormActionState.AddingNode:
					return "Adding Node...";
				case FormActionState.MovingNode:
					return "Moving Node...";
				default:
					break;
			}

			throw new NotImplementedException();
		}


		private void SetAction(FormActionState state)
		{
			mActionState = state;
			wStatusText.Text = "Status: " + GetStatusText(mActionState);
			if (state == FormActionState.None)
			{
				wStatusPanel.BackColor = Color.White;
			}
			else
			{
				wStatusPanel.BackColor = Color.Wheat;
			}
		}

		#endregion rUtility
	}
}