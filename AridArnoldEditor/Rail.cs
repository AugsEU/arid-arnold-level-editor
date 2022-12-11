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
			Speed = 1;
			WaitTime = 0;
			Flags = 0;
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
			mSize = 1;
			mFlags = 0;
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
	}
}
