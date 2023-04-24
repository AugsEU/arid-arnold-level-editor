using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AridArnoldEditor
{
	class LevelMetaData
	{
		public enum LevelType
		{
			CollectWater,
			CollectFlag
		}

		public string mName = "";
		public string mSubName = "";
		public LevelType mLevelType = LevelType.CollectWater;
		public string mTheme = "";
		public string mOther = "";
		public int[] mIntParams = new int[8];

		public LevelMetaData()
		{
		}

		public LevelMetaData(BinaryReader br, int fileVer)
		{
			ReadMetaData(br, fileVer);
		}

		void ReadMetaData(BinaryReader br, int fileVer)
		{
			mName = br.ReadString();
			mSubName = br.ReadString();
			mLevelType = (LevelType)br.ReadUInt32();
			mTheme = br.ReadString();
			mOther = br.ReadString();
			for(int i = 0; i < mIntParams.Length; i++)
			{
				mIntParams[i] = br.ReadInt32();
			}
		}

		public void WriteMetaData(BinaryWriter bw)
		{
			bw.Write(mName);
			bw.Write(mSubName);
			bw.Write((UInt32)mLevelType);
			bw.Write(mTheme);
			bw.Write(mOther);

			for (int i = 0; i < mIntParams.Length; i++)
			{
				bw.Write(mIntParams[i]);
			}
		}

		public void Clear()
		{
			mName = "";
			mSubName = "";
			mLevelType = LevelType.CollectWater;
			mTheme = "";
			mOther = "";
			mIntParams = new int[8];
		}
	}
}
