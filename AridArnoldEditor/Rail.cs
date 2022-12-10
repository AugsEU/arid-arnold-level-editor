namespace AridArnoldEditor
{
	class RailNode
	{
		Point mPoint;

		public RailNode(Point point)
		{
			mPoint = point;
		}

		public Point GetPoint()
		{
			return mPoint;
		}

		public void SetPoint(Point newValue)
		{
			mPoint = newValue;
		}
	}

	class LinearRail
	{
		List<RailNode> mNodes;
		float mSpeed;
		int mSize;
		bool mCycle;

		public LinearRail(float speed)
		{
			mNodes = new List<RailNode>();
			mSpeed = speed;
			mSize = 1;
			mCycle = false;
		}

		public void AddNode(Point newPoint)
		{
			mNodes.Add(new RailNode(newPoint));
		}

		public bool GetCylce()
		{
			return mCycle;
		}

		public void SetCycle(bool cycle)
		{
			mCycle = cycle;
		}

		public void SetSize(int size)
		{
			mSize = size;
		}

		public int GetSize()
		{
			return mSize;
		}

		public float GetSpeed()
		{
			return mSpeed;
		}

		public void ChangeSpeed(float newSpeed)
		{
			mSpeed = newSpeed;
		}

		public List<RailNode> GetNodes()
		{
			return mNodes;
		}

		public bool HasNodeAtPoint(Point point)
		{
			for (int i = 0; i < mNodes.Count; i++)
			{
				if (mNodes[i].GetPoint() == point)
				{
					return true;
				}
			}

			return false;
		}

		public void MoveNode(Point start, Point end)
		{
			for (int i = 0; i < mNodes.Count; i++)
			{
				if (mNodes[i].GetPoint() == start)
				{
					mNodes[i].SetPoint(end);
					break;
				}
			}
		}

		public void RemoveNode(Point position)
		{
			for (int i = 0; i < mNodes.Count; i++)
			{
				if (mNodes[i].GetPoint() == position)
				{
					mNodes.RemoveAt(i);
					break;
				}
			}
		}
	}
}
