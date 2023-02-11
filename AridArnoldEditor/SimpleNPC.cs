using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AridArnoldEditor
{
	class SimpleNPC : Entity
	{
		public enum NPCType
		{
			kBarbara = 0,
			kZippy = 1,
			kDok = 2,
			kBickDogel = 3,
			kElectrent = 4
		}

		public NPCType mType;
		public string mTalkText;
		public string mHeckleText;

		public SimpleNPC(Point tilePos) : base(tilePos)
		{
			mType = NPCType.kBarbara;
			mTalkText = "";
			mHeckleText = "";
		}

		public override EntityType GetEntityType()
		{
			return EntityType.kSimpleNPC;
		}
	}
}
