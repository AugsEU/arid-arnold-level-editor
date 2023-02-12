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

				for (int i = 0; i < mAuxData.LinearRails.Count; i++)
				{
					List<RailNode> railNodes = mAuxData.LinearRails[i].GetNodes();

					Pen nodePen = new Pen(Color.Green);

					for (int j = 0; j < railNodes.Count; j++)
					{
						Point point = GetPixelPositionFromCoordinate(railNodes[j].Point);

						if (j > 0)
						{
							Point prevPoint = GetPixelPositionFromCoordinate(railNodes[j - 1].Point);

							e.Graphics.DrawLine(railPen, prevPoint, point);

							nodePen.Color = Color.DarkRed;
						}

						e.Graphics.DrawRectangle(nodePen, new Rectangle(point.X - 5, point.Y - 5, 10, 10));
					}

					if ((mAuxData.LinearRails[i].GetFlags() & LinearRail.RAIL_CYCLE_FLAG) != 0)
					{
						Point point = GetPixelPositionFromCoordinate(railNodes[0].Point);
						Point prevPoint = GetPixelPositionFromCoordinate(railNodes[railNodes.Count - 1].Point);

						e.Graphics.DrawLine(railPen, prevPoint, point);
					}
				}

				//Draw entities
				for (int i = 0; i < mAuxData.Entities.Count; i++)
				{
					Entity entity = mAuxData.Entities[i];

					Point point = GetPixelPositionFromCoordinate(entity.mPosition);
					Image entitySprite = entity.mImage;

					point.X -= entitySprite.Width / 2;
					point.Y += LevelEditor.TILE_SIZE / 2 - entitySprite.Height;

					e.Graphics.DrawImage(entitySprite, point);
				}
			}
		}

		Point GetPixelPositionFromCoordinate(Point tileCoord)
		{
			Point point = new Point();
			point.X = tileCoord.X * LevelEditor.TILE_SIZE + LevelEditor.TILE_SIZE / 2;
			point.Y = tileCoord.Y * LevelEditor.TILE_SIZE + LevelEditor.TILE_SIZE / 2;

			return point;
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			Point clickPoint = new Point(e.X / LevelEditor.TILE_SIZE, e.Y / LevelEditor.TILE_SIZE);

			mEditorRef.OnClickTile(clickPoint);
		}
	}
}
