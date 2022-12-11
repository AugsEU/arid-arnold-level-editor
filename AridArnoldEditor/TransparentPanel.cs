namespace AridArnoldEditor
{
	public class TransparentPanel : Panel
	{
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
				return cp;
			}
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			//base.OnPaintBackground(e);
		}
	}

	class DrawLevelArea : TransparentPanel
	{
		AuxData? mAuxData;
		LevelEditor mEditorRef;

		public DrawLevelArea(LevelEditor refEditor)
		{
			mEditorRef = refEditor;
			mAuxData = null;
		}

		public void SetData(AuxData auxData)
		{
			mAuxData = auxData;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (mAuxData != null)
			{
				//Draw rails
				Pen railPen = new Pen(Color.OrangeRed);
				Pen nodePen = new Pen(Color.Green);

				for (int i = 0; i < mAuxData.LinearRails.Count; i++)
				{
					List<RailNode> railNodes = mAuxData.LinearRails[i].GetNodes();

					for (int j = 0; j < railNodes.Count; j++)
					{
						Point point = railNodes[j].Point;

						point.X = point.X * LevelEditor.TILE_SIZE + LevelEditor.TILE_SIZE / 2;
						point.Y = point.Y * LevelEditor.TILE_SIZE + LevelEditor.TILE_SIZE / 2;

						if (j > 0)
						{
							Point prevPoint = railNodes[j - 1].Point;

							prevPoint.X = prevPoint.X * LevelEditor.TILE_SIZE + LevelEditor.TILE_SIZE / 2;
							prevPoint.Y = prevPoint.Y * LevelEditor.TILE_SIZE + LevelEditor.TILE_SIZE / 2;

							e.Graphics.DrawLine(railPen, prevPoint, point);

							nodePen.Color = Color.DarkRed;
						}

						e.Graphics.DrawRectangle(nodePen, new Rectangle(point.X - 5, point.Y - 5, 10, 10));
					}

					if ((mAuxData.LinearRails[i].GetFlags() & LinearRail.RAIL_CYCLE_FLAG) != 0)
					{
						Point point = railNodes[0].Point;
						Point prevPoint = railNodes[railNodes.Count - 1].Point;

						prevPoint.X = prevPoint.X * LevelEditor.TILE_SIZE + LevelEditor.TILE_SIZE / 2;
						prevPoint.Y = prevPoint.Y * LevelEditor.TILE_SIZE + LevelEditor.TILE_SIZE / 2;

						point.X = point.X * LevelEditor.TILE_SIZE + LevelEditor.TILE_SIZE / 2;
						point.Y = point.Y * LevelEditor.TILE_SIZE + LevelEditor.TILE_SIZE / 2;

						e.Graphics.DrawLine(railPen, prevPoint, point);
					}
				}
			}
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			Point clickPoint = new Point(e.X / LevelEditor.TILE_SIZE, e.Y / LevelEditor.TILE_SIZE);

			mEditorRef.OnClickTile(clickPoint);
		}
	}
}
