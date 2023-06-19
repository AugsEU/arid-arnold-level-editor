using System.Windows.Forms.Design;

namespace AridArnoldEditor
{
	class RailNode
	{
		public Point Point { get; set; }
		public float Speed { get; set; }
		public float WaitTime { get; set; }
		public UInt32 Flags { get; set; }

		public RailNode(Point point)
		{
			Point = point;
			Speed = 4;
			WaitTime = 4;
			Flags = 0;
		}

		public RailNode(RailNode other)
		{
			Point = other.Point;
			Speed = other.Speed;
			WaitTime = other.WaitTime;
			Flags = other.Flags;
		}
	}

	class LinearRail
	{
		public const UInt32 RAIL_CYCLE_FLAG = 0b0000_0001;

		List<RailNode> mNodes;
		int mSize;
		UInt32 mFlags;

		public LinearRail()
		{
			mNodes = new List<RailNode>();
			mSize = 2;
			mFlags = 0;
		}

		public LinearRail(LinearRail otherRail)
		{
			mNodes = new List<RailNode>();
			for(int i = 0; i < otherRail.mNodes.Count; i++)
			{
				RailNode otherNode = new RailNode(otherRail.mNodes[i]);
				mNodes.Add(otherNode);
			}

			mSize = otherRail.mSize;
			mFlags = otherRail.mFlags;
		}

		public LinearRail(BinaryReader br, int fileVer)
		{
			mNodes = new List<RailNode>();
			ReadRail(br, fileVer);
		}

		public void AddNode(Point newPoint)
		{
			mNodes.Add(new RailNode(newPoint));
		}

		public UInt32 GetFlags()
		{
			return mFlags;
		}

		public void SetFlags(UInt32 flags)
		{
			mFlags = flags;
		}

		public void SetSize(int size)
		{
			mSize = size;
		}

		public int GetSize()
		{
			return mSize;
		}

		public List<RailNode> GetNodes()
		{
			return mNodes;
		}

		public RailNode? GetNodeAtPoint(Point point)
		{
			for (int i = 0; i < mNodes.Count; i++)
			{
				if (mNodes[i].Point == point)
				{
					return mNodes[i];
				}
			}

			return null;
		}

		public void MoveNode(Point start, Point end)
		{
			for (int i = 0; i < mNodes.Count; i++)
			{
				if (mNodes[i].Point == start)
				{
					mNodes[i].Point = end;
					break;
				}
			}
		}

		public void RemoveNode(Point position)
		{
			for (int i = 0; i < mNodes.Count; i++)
			{
				if (mNodes[i].Point == position)
				{
					mNodes.RemoveAt(i);
					break;
				}
			}
		}

		public void MoveRail(Point delta)
		{
			for(int i = 0; i < mNodes.Count; i++)
			{
				Point oldPos = mNodes[i].Point;
				oldPos.X += delta.X;
				oldPos.Y += delta.Y;
				mNodes[i].Point = oldPos;
			}
		}


		#region rReadWrite

		public void WriteRail(BinaryWriter bw)
		{
			bw.Write(mSize);
			bw.Write((UInt32)mFlags);

			//Nodes
			bw.Write(mNodes.Count);

			for (int i = 0; i < mNodes.Count; i++)
			{
				bw.Write(mNodes[i].Point.X);
				bw.Write(mNodes[i].Point.Y);
				bw.Write(mNodes[i].Speed);
				bw.Write(mNodes[i].WaitTime);
				bw.Write(mNodes[i].Flags);
			}
		}

		public void ReadRail(BinaryReader br, int fileVer)
		{
			mSize = br.ReadInt32();
			mFlags = br.ReadUInt32();

			//Nodes
			int numNodes = br.ReadInt32();

			for (int i = 0; i < numNodes; i++)
			{
				int ptX = br.ReadInt32();
				int ptY = br.ReadInt32();

				if(fileVer <= 2)
				{
					ptX += 2;
					ptY += 2;
				}

				RailNode node = new RailNode(new Point(ptX, ptY));
				node.Speed = br.ReadSingle();
				node.WaitTime = br.ReadSingle();
				node.Flags = br.ReadUInt32();

				mNodes.Add(node);
			}
		}

		#endregion rReadWrite
	}
}
