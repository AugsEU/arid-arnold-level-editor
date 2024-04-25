namespace AridArnoldEditor
{
	public partial class LevelEditor : Form
	{
		#region rConstants

		public static int NUM_TILES = 36;
		public static int TILE_SIZE = 16;

		#endregion rConstants





		#region rTypes

		enum FormActionState
		{
			None,
			AddingRail,
			CopyRail,
			AddingNode,
			MovingNode,
			AddingEntity,
			MovingEntity,
			CopyEntity
		}

		#endregion rTypes





		#region rMembers

		//Current level
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

		// Entities
		int mSelectedEntityIdx;
		NumericUpDown[] mFloatParamsUpDown;
		NumericUpDown[] mIntParamsUpDown;

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
			mFilePath = "";

			//Rails
			mSelectedRailIdx = -1;

			//Entity
			mSelectedEntityIdx = -1;
			mFloatParamsUpDown = new NumericUpDown[16];
			mIntParamsUpDown = new NumericUpDown[16];

			mFloatParamsUpDown[0] = wEntityFP0;
			mFloatParamsUpDown[1] = wEntityFP1;
			mFloatParamsUpDown[2] = wEntityFP2;
			mFloatParamsUpDown[3] = wEntityFP3;
			mFloatParamsUpDown[4] = wEntityFP4;
			mFloatParamsUpDown[5] = wEntityFP5;
			mFloatParamsUpDown[6] = wEntityFP6;
			mFloatParamsUpDown[7] = wEntityFP7;

			mIntParamsUpDown[0] = wEntityIP0;
			mIntParamsUpDown[1] = wEntityIP1;
			mIntParamsUpDown[2] = wEntityIP2;
			mIntParamsUpDown[3] = wEntityIP3;
			mIntParamsUpDown[4] = wEntityIP4;
			mIntParamsUpDown[5] = wEntityIP5;
			mIntParamsUpDown[6] = wEntityIP6;
			mIntParamsUpDown[7] = wEntityIP7;

			for (int i = 0; i < 8; i++)
			{
				int dumbAssCopyWhyIsCSharpLikeThisPleaseSamirYouAreWreckingTheLanguage = i;
				mFloatParamsUpDown[i].ValueChanged += (sender, e) => SetEntityFloatParam(dumbAssCopyWhyIsCSharpLikeThisPleaseSamirYouAreWreckingTheLanguage, mFloatParamsUpDown[dumbAssCopyWhyIsCSharpLikeThisPleaseSamirYouAreWreckingTheLanguage]);
				mIntParamsUpDown[i].ValueChanged += (sender, e) => SetEntityIntParam(dumbAssCopyWhyIsCSharpLikeThisPleaseSamirYouAreWreckingTheLanguage, mIntParamsUpDown[dumbAssCopyWhyIsCSharpLikeThisPleaseSamirYouAreWreckingTheLanguage]);
			}

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

			wEntityClassCombo.Items.Clear();
			foreach (string enumStr in Enum.GetNames(typeof(Entity.EntityClass)))
			{
				string className = enumStr.Substring(1);
				if(className.EndsWith("ClassEnd"))
				{
					continue;
				}
				wEntityClassCombo.Items.Add(className);
			}

			//State
			SetAction(FormActionState.None);

			UpdateRailPanel();
			UpdateEntityPanel();
			UpdateMetaPanel();
		}

		private void LevelEditor_Load(object sender, EventArgs e)
		{

		}

		#endregion rInitialisation





		#region rForm

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

		private void LevelEditor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				SetAction(FormActionState.None);
			}
		}

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


		private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (File.Exists(mFilePath))
			{
				LoadImage(mFilePath);
				InvalidateAll();
			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (mFilePath != "")
			{
				mAuxData.SaveFile(mFilePath);
			}
		}

		private void clearToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Are you sure?", "Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
			if (result == DialogResult.Yes)
			{
				mAuxData.Clear();
			}
		}

		private void ClickOnSelectTile(object? sender, MouseEventArgs e)
		{
			OnClickTile(mSelectedTileCoord);
		}

		#endregion rWidgets





		#region rRailWidgets
		private void linearToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SetAction(FormActionState.AddingRail);
		}

		private void wAddNode_Click(object sender, EventArgs e)
		{
			SetAction(FormActionState.AddingNode);
		}

		private void wCopyRailBtn_Click(object sender, EventArgs e)
		{
			SetAction(FormActionState.CopyRail);
		}

		private void wCopyEntityButton_Click(object sender, EventArgs e)
		{
			SetAction(FormActionState.CopyEntity);
		}

		private void wRemoveNodeBtn_Click(object sender, EventArgs e)
		{
			int railIdx = GetRailIdxAtPoint(mSelectedTileCoord);

			if (railIdx != -1)
			{
				mAuxData.LinearRails[railIdx].RemoveNode(mSelectedTileCoord);

				if (mAuxData.LinearRails[railIdx].GetNodes().Count == 0)
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

		private void UpdateRailPanel()
		{
			wRailPanel.Enabled = mSelectedRailIdx != -1;
			if (mSelectedRailIdx != -1 && mAuxData != null)
			{
				RailNode? selectedNode = mAuxData.LinearRails[mSelectedRailIdx].GetNodeAtPoint(mSelectedTileCoord);

				if (selectedNode != null)
				{
					wRailSpeedIn.Value = (decimal)selectedNode.Speed;
					wRailWaitIn.Value = (decimal)selectedNode.WaitTime;
					wNodeFlagsIn.Value = (decimal)(selectedNode.Flags);
				}

				wRailSizeIn.Value = (decimal)mAuxData.LinearRails[mSelectedRailIdx].GetSize();
				wRailFlagsIn.Value = mAuxData.LinearRails[mSelectedRailIdx].GetFlags();
			}
		}

		private void wRailSizeIn_ValueChanged(object sender, EventArgs e)
		{
			if (mSelectedRailIdx != -1)
			{
				mAuxData.LinearRails[mSelectedRailIdx].SetSize((int)wRailSizeIn.Value);
			}
		}

		private void wRailFlagsIn_ValueChanged(object sender, EventArgs e)
		{
			if (mSelectedRailIdx != -1)
			{
				mAuxData.LinearRails[mSelectedRailIdx].SetFlags((UInt32)wRailFlagsIn.Value);
				InvalidateAll();
			}
		}

		private void wRailWaitIn_ValueChanged(object sender, EventArgs e)
		{
			if (mSelectedRailIdx != -1)
			{
				RailNode? selectedNode = mAuxData.LinearRails[mSelectedRailIdx].GetNodeAtPoint(mSelectedTileCoord);

				if (selectedNode != null)
				{
					selectedNode.WaitTime = ((float)wRailWaitIn.Value);
				}
			}
		}

		private void wRailSpeedIn_ValueChanged(object sender, EventArgs e)
		{
			if (mSelectedRailIdx != -1)
			{
				RailNode? selectedNode = mAuxData.LinearRails[mSelectedRailIdx].GetNodeAtPoint(mSelectedTileCoord);

				if (selectedNode != null)
				{
					selectedNode.Speed = ((float)wRailSpeedIn.Value);
				}
			}
		}


		private void wNodeFlagsIn_ValueChanged(object sender, EventArgs e)
		{
			if (mSelectedRailIdx != -1)
			{
				RailNode? selectedNode = mAuxData.LinearRails[mSelectedRailIdx].GetNodeAtPoint(mSelectedTileCoord);

				if (selectedNode != null)
				{
					selectedNode.Flags = ((UInt32)wNodeFlagsIn.Value);
				}
			}
		}

		#endregion rRailWidgets





		#region rEntityWidgets

		private void UpdateEntityPanel()
		{
			Entity? selectedEntity = GetSelectedEntity();

			if (selectedEntity != null)
			{
				wEntityPanel.Enabled = true;
				wEntityClassCombo.SelectedIndex = EntityClassIndexFromEnum(selectedEntity.mEntityClass);
				wEntityFacingCombo.SelectedIndex = (int)selectedEntity.mStartDirection;
				wEntityGravityCombo.SelectedIndex = (int)selectedEntity.mGravityDirection;

				for (int i = 0; i < 8; i++)
				{
					mFloatParamsUpDown[i].Value = (decimal)selectedEntity.mFloatParams[i];
					mIntParamsUpDown[i].Value = (decimal)selectedEntity.mIntParams[i];
				}

				if (selectedEntity.mEntityClass == Entity.EntityClass.kSimpleNPC)
				{
					wSNPCPanel.Enabled = true;
					wNPCHeckleTxt.Text = selectedEntity.mHeckleText;
					wNPCTalkTxt.Text = selectedEntity.mTalkText;
					wNPCTalkPath.Text = selectedEntity.mNPCPath;
				}
				else
				{
					wSNPCPanel.Enabled = false;
					wNPCHeckleTxt.Text = "";
					wNPCTalkTxt.Text = "";
					wNPCTalkPath.Text = "";
				}
			}
			else
			{
				wEntityPanel.Enabled = false;
				wSNPCPanel.Enabled = false;
			}
		}

		private void entityToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SetAction(FormActionState.AddingEntity);
		}

		private void wEntityMoveBtn_Click(object sender, EventArgs e)
		{
			SetAction(FormActionState.MovingEntity);
		}

		private void wEntityClassCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			Entity? selectedEntity = GetSelectedEntity();
			if (selectedEntity != null)
			{
				Entity.EntityClass entityClass = EntityClassEnumFromIdx(wEntityClassCombo.SelectedIndex);
				selectedEntity.SetClass(entityClass);

				InvalidateAll();
				UpdateEntityPanel();
			}
		}

		private void wEntityFacingCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			Entity? selectedEntity = GetSelectedEntity();
			if (selectedEntity != null)
			{
				selectedEntity.mStartDirection = (WalkDirection)wEntityFacingCombo.SelectedIndex;

				InvalidateAll();
				UpdateEntityPanel();
			}
		}

		private void wEntityGravityCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			Entity? selectedEntity = GetSelectedEntity();
			if (selectedEntity != null)
			{
				selectedEntity.mGravityDirection = (CardinalDirection)wEntityGravityCombo.SelectedIndex;

				InvalidateAll();
				UpdateEntityPanel();
			}
		}

		private void wEntityRemoveBtn_Click(object sender, EventArgs e)
		{
			if (mSelectedEntityIdx != -1)
			{
				mAuxData.Entities.RemoveAt(mSelectedEntityIdx);
				mSelectedEntityIdx = -1;
				InvalidateAll();
				UpdateEntityPanel();
			}
		}

		private void SetEntityFloatParam(int idx, NumericUpDown widget)
		{
			Entity? entity = GetSelectedEntity();
			if (entity != null)
			{
				entity.mFloatParams[idx] = (float)widget.Value;
			}
		}

		private void SetEntityIntParam(int idx, NumericUpDown widget)
		{
			Entity? entity = GetSelectedEntity();
			if (entity != null)
			{
				entity.mIntParams[idx] = (int)widget.Value;
			}
		}

		private void wNPCTalkTxt_TextChanged(object sender, EventArgs e)
		{
			Entity? selectedEntity = GetSelectedEntity();
			if (selectedEntity != null)
			{
				selectedEntity.mTalkText = wNPCTalkTxt.Text;

				InvalidateAll();
				UpdateEntityPanel();
			}
		}

		private void wNPCHeckleTxt_TextChanged(object sender, EventArgs e)
		{
			Entity? selectedEntity = GetSelectedEntity();
			if (selectedEntity != null)
			{
				selectedEntity.mHeckleText = wNPCHeckleTxt.Text;

				InvalidateAll();
				UpdateEntityPanel();
			}
		}

		private void wNPCTalkPath_TextChanged(object sender, EventArgs e)
		{
			Entity? selectedEntity = GetSelectedEntity();
			if (selectedEntity != null)
			{
				selectedEntity.mNPCPath = wNPCTalkPath.Text;

				InvalidateAll();
				UpdateEntityPanel();
			}
		}

		private Entity.EntityClass EntityClassEnumFromIdx(int idx)
		{
			if (idx < (int)Entity.EntityClass.kPlayerClassEnd)
			{
				return (Entity.EntityClass)idx;
			}

			idx -= (int)Entity.EntityClass.kPlayerClassEnd - Entity.kPlayerClassStart;
			idx += Entity.kClassSpacing;

			if (idx < (int)Entity.EntityClass.kEnemyClassEnd)
			{
				return (Entity.EntityClass)idx;
			}

			idx -= (int)Entity.EntityClass.kEnemyClassEnd - Entity.kEnemyClassStart;
			idx += Entity.kClassSpacing;

			if (idx < (int)Entity.EntityClass.kNPCClassEnd)
			{
				return (Entity.EntityClass)idx;
			}

			idx -= (int)Entity.EntityClass.kNPCClassEnd - Entity.kNPCClassStart;
			idx += Entity.kClassSpacing;

			return (Entity.EntityClass)idx;
		}

		private int EntityClassIndexFromEnum(Entity.EntityClass myEnum)
		{
			int enumInt = (int)myEnum;
			int subclassIdx = enumInt % Entity.kClassSpacing;
			int offset = 0;

			if (enumInt > (int)Entity.EntityClass.kPlayerClassEnd)
			{
				offset += (int)Entity.EntityClass.kPlayerClassEnd - Entity.kPlayerClassStart;
			}

			if (enumInt > (int)Entity.EntityClass.kEnemyClassEnd)
			{
				offset += (int)Entity.EntityClass.kEnemyClassEnd - Entity.kEnemyClassStart;
			}

			if (enumInt > (int)Entity.EntityClass.kNPCClassEnd)
			{
				offset += (int)Entity.EntityClass.kNPCClassEnd - Entity.kNPCClassStart;
			}

			if (enumInt > (int)Entity.EntityClass.kUtilityClassEnd)
			{
				offset += (int)Entity.EntityClass.kUtilityClassEnd - Entity.kUtilityClassStart;
			}

			return offset + subclassIdx;
		}

		private Entity? GetSelectedEntity()
		{
			if (mSelectedEntityIdx != -1)
			{
				return mAuxData.Entities[mSelectedEntityIdx];
			}

			return null;
		}

		#endregion rEntityWidgets





		#region rMeta

		private void UpdateMetaPanel()
		{
			wMetaPanel.Enabled = mFilePath != "";

			if (wMetaPanel.Enabled)
			{
				wLevelName.Text = mAuxData.mMetaData.mName;
				wLevelRoot.Text = mAuxData.mMetaData.mRoot;
				wLevelType.SelectedIndex = (int)mAuxData.mMetaData.mLevelType;
				wLevelTheme.Text = mAuxData.mMetaData.mTheme;
				wLevelBG.Text = mAuxData.mMetaData.mBG;

				wLevelIntP0.Value = mAuxData.mMetaData.mIntParams[0];
				wLevelIntP1.Value = mAuxData.mMetaData.mIntParams[1];
				wLevelIntP2.Value = mAuxData.mMetaData.mIntParams[2];
				wLevelIntP3.Value = mAuxData.mMetaData.mIntParams[3];
			}
			else
			{
				wLevelName.Text = "";
				wLevelRoot.Text = "";
				wLevelType.SelectedIndex = 0;
				wLevelTheme.Text = "";
				wLevelBG.Text = "";
			}
		}

		private void wLevelName_TextChanged(object sender, EventArgs e)
		{
			mAuxData.mMetaData.mName = wLevelName.Text;
		}

		private void wLevelSubName_TextChanged(object sender, EventArgs e)
		{
			mAuxData.mMetaData.mRoot = wLevelRoot.Text;
		}

		private void wLevelType_SelectedIndexChanged(object sender, EventArgs e)
		{
			mAuxData.mMetaData.mLevelType = (uint)wLevelType.SelectedIndex;
		}

		private void wLevelTheme_TextChanged(object sender, EventArgs e)
		{
			mAuxData.mMetaData.mTheme = wLevelTheme.Text;
		}

		private void wLevelOther_TextChanged(object sender, EventArgs e)
		{
			mAuxData.mMetaData.mBG = wLevelBG.Text;
		}

		// Yeah I know...
		private void wLevelIntP0_ValueChanged(object sender, EventArgs e) { mAuxData.mMetaData.mIntParams[0] = (int)wLevelIntP0.Value; }
		private void wLevelIntP1_ValueChanged(object sender, EventArgs e) { mAuxData.mMetaData.mIntParams[1] = (int)wLevelIntP1.Value; }
		private void wLevelIntP2_ValueChanged(object sender, EventArgs e) { mAuxData.mMetaData.mIntParams[2] = (int)wLevelIntP2.Value; }
		private void wLevelIntP3_ValueChanged(object sender, EventArgs e) { mAuxData.mMetaData.mIntParams[3] = (int)wLevelIntP3.Value; }

		#endregion rMeta





		#region rLevelEditing

		private void LoadLevel(string filePath)
		{
			this.Text = "Level Editor - " + Path.GetFileName(filePath);

			LoadImage(filePath);

			mAuxData.LoadFile(filePath);

			UpdateMetaPanel();

			SetAction(FormActionState.None);
			OnClickTile(mSelectedTileCoord);
			InvalidateAll();
		}

		private void LoadImage(string filePath)
		{
			using (Bitmap loadedImage = new Bitmap(filePath))
			{
				for (int x = 0; x < NUM_TILES; x++)
				{
					for (int y = 0; y < NUM_TILES; y++)
					{
						mPanels[x, y].BackColor = loadedImage.GetPixel(x, y);
					}
				}
			}
		}

		public void OnClickTile(Point tileClicked)
		{
			//Deal with Action
			DoAction(mActionState, tileClicked);

			//Rail
			mSelectedRailIdx = GetRailIdxAtPoint(tileClicked);

			//Entity
			mSelectedEntityIdx = GetEntityIdxAtPoint(tileClicked);

			//Update selection point
			mSelectedTileCoord = tileClicked;
			mSelectionPanel.Location = new Point(tileClicked.X * TILE_SIZE, tileClicked.Y * TILE_SIZE);
			if (tileClicked.X >= 0 && tileClicked.Y >= 0)
			{
				mSelectionPanel.BackColor = mPanels[tileClicked.X, tileClicked.Y].BackColor;
			}

			UpdateRailPanel();
			UpdateEntityPanel();
		}

		private void DoAction(FormActionState action, Point tile)
		{
			int railIdx = GetRailIdxAtPoint(tile);
			int entityIdx = GetEntityIdxAtPoint(tile);
			bool tileEmpty = railIdx == -1 && entityIdx == -1;

			switch (action)
			{
				case FormActionState.AddingRail:
					if (tileEmpty)
					{
						LinearRail newRail = new LinearRail();
						newRail.AddNode(tile);
						mAuxData.LinearRails.Add(newRail);
					}
					break;
				case FormActionState.CopyRail:
					if (tileEmpty)
					{
						LinearRail newRail = new LinearRail(mAuxData.LinearRails[mSelectedRailIdx]);
						Point delta = tile;
						delta.X -= mSelectedTileCoord.X;
						delta.Y -= mSelectedTileCoord.Y;
						newRail.MoveRail(delta);
						mAuxData.LinearRails.Add(newRail);
					}
					break;
				case FormActionState.CopyEntity:
					if (tileEmpty && mSelectedEntityIdx != -1)
					{
						Entity newEntity = new Entity(mAuxData.Entities[mSelectedEntityIdx]);
						newEntity.mPosition = tile;
						mAuxData.Entities.Add(newEntity);
					}
					break;
				case FormActionState.AddingNode:
					if (tileEmpty)
					{
						mAuxData.LinearRails[mSelectedRailIdx].AddNode(tile);
					}
					break;
				case FormActionState.MovingNode:
					if (tileEmpty)
					{
						mAuxData.LinearRails[mSelectedRailIdx].MoveNode(mSelectedTileCoord, tile);
					}
					break;
				case FormActionState.AddingEntity:
					if (tileEmpty)
					{
						Entity newEntity = new Entity(tile);
						mAuxData.Entities.Add(newEntity);
					}
					break;
				case FormActionState.MovingEntity:
					Entity? selectedEntity = GetSelectedEntity();

					if (tileEmpty && selectedEntity != null)
					{
						selectedEntity.mPosition = tile;
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
				if (mAuxData.LinearRails[i].GetNodeAtPoint(tile) != null)
				{
					return i;
				}
			}

			return -1;
		}

		private int GetEntityIdxAtPoint(Point tile)
		{
			for (int i = 0; i < mAuxData.Entities.Count; i++)
			{
				if (mAuxData.Entities[i].mPosition == tile)
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
				case FormActionState.CopyRail:
					return "Copying Rail...";
				case FormActionState.AddingNode:
					return "Adding Node...";
				case FormActionState.MovingNode:
					return "Moving Node...";
				case FormActionState.AddingEntity:
					return "Adding Entity...";
				case FormActionState.MovingEntity:
					return "Moving Entity...";
				case FormActionState.CopyEntity:
					return "Copying Entity...";
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