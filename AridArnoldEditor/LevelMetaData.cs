using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AridArnoldEditor
{
	class LevelMetaData
	{
		public string mName = "";
		public string mRoot = "";
		public uint mLevelType = 0;
		public string mTheme = "";
		public string mBG = "";
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
			mRoot = br.ReadString();
			mLevelType = br.ReadUInt32();
			mTheme = br.ReadString();
			mBG = br.ReadString();
			for(int i = 0; i < mIntParams.Length; i++)
			{
				mIntParams[i] = br.ReadInt32();
			}
		}

		public void WriteMetaData(BinaryWriter bw)
		{
			bw.Write(mName);
			bw.Write(mRoot);
			bw.Write((UInt32)mLevelType);
			bw.Write(mTheme);
			bw.Write(mBG);

			for (int i = 0; i < mIntParams.Length; i++)
			{
				bw.Write(mIntParams[i]);
			}
		}

		public void Clear()
		{
			mIntParams = new int[8];
		}
	}
}
