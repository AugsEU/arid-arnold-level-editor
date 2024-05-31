using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AridArnoldEditor
{
	enum CardinalDirection
	{
		kUp = 0,
		kRight,
		kDown,
		kLeft
	}

	enum WalkDirection
	{
		kLeft = 0,
		kRight,
		kNone,
	}

	class Entity
	{
		public const int kClassSpacing = 2048;
		public const int kPlayerClassStart = 0 * kClassSpacing;
		public const int kEnemyClassStart  = 1 * kClassSpacing;
		public const int kNPCClassStart    = 2 * kClassSpacing;
		public const int kUtilityClassStart = 3 * kClassSpacing;

		public enum EntityClass
		{
			// Player
			kArnold = kPlayerClassStart,
			kAndrold,
			kPlayerClassEnd,

			// Enemy
			kTrundle = kEnemyClassStart,
			kRoboto,
			kFutronGun,
			kFutronRocket,
			kFarry,
			kMamal,
			kPapyras,
			kRanger,
			kEnemyClassEnd,

			//NPC
			kSimpleNPC = kNPCClassStart,
			kBickDogel,
			kFireBarrel,
			kBouncer,
			kNPCClassEnd,

			// Utility
			kArnoldSpawner = kUtilityClassStart,
			kSequenceDoor,
			kLevelLock,
			kShopDoor,
			kItemStand,
			kGravityOrb,
			kGravityTile,
			kTimeMachine,
			kPlantPot,
			kPillarPot,
			kWorldCabinet,
			kArcadeBuilding,
			kUtilityClassEnd
		}

		// UI
		public Image mImage;

		// Data
		public Point mPosition;
		public EntityClass mEntityClass;
		public WalkDirection mStartDirection;
		public CardinalDirection mGravityDirection;
		public float[] mFloatParams;
		public int[] mIntParams;

		// Only NPC data
		public string mNPCPath;
		public string mTalkText;
		public string mHeckleText;

		public Entity(Point tilePos)
		{
			mPosition = tilePos;
			mEntityClass = EntityClass.kArnold;
			mStartDirection = WalkDirection.kRight;
			mGravityDirection = CardinalDirection.kDown;

			mFloatParams = new float[8];
			mIntParams = new int[8];

			mTalkText = "";
			mHeckleText = "";

			mImage = LoadImage();
		}

		public Entity(BinaryReader br, int fileVer)
		{
			mFloatParams = new float[8];
			mIntParams = new int[8];
			mTalkText = "";
			mHeckleText = "";

			ReadEntity(br, fileVer);
			mImage = LoadImage();
		}

		public Entity(Entity other)
		{
			mFloatParams = new float[8];
			mIntParams = new int[8];
			Array.Copy(other.mFloatParams, mFloatParams, other.mFloatParams.Length);
			Array.Copy(other.mIntParams, mIntParams, other.mIntParams.Length);

			mPosition = other.mPosition;
			mEntityClass = other.mEntityClass;
			mStartDirection = other.mStartDirection;
			mGravityDirection = other.mGravityDirection;

			mTalkText = other.mTalkText;
			mHeckleText = other.mHeckleText;

			mImage = other.mImage;
		}

		Image LoadImage()
		{
			string bmpName = Enum.GetName(typeof(EntityClass), mEntityClass);
			Bitmap bmp = (Bitmap)AridArnoldEditor.Properties.Resources.ResourceManager.GetObject(bmpName.Substring(1));

			if(bmp is null)
			{
				throw new Exception("ENTITY IS NULL " + bmpName);
			}
			return new Bitmap(bmp);
		}

		public void SetClass(EntityClass theClass)
		{
			if (theClass != mEntityClass)
			{
				mEntityClass = theClass;
				mImage = LoadImage();

				if (theClass == EntityClass.kSimpleNPC)
				{
					mNPCPath = "NPC/Barbara";
					SetDefaultText();
				}
			}
		}

		void SetDefaultText()
		{
			string baseID = mNPCPath.Replace("/", ".");
			baseID = baseID.Replace("\\", ".");
			mTalkText = baseID + ".Talk";
			mHeckleText = baseID + ".Heckle";
		}

		public bool ValidateEntity()
		{
			if (mPosition.X < 0 || mPosition.X >= LevelEditor.NUM_TILES)
			{
				return false;
			}

			if (mPosition.Y < 0 || mPosition.Y >= LevelEditor.NUM_TILES)
			{
				return false;
			}

			int entityClass = (int)mEntityClass;

			if((int)EntityClass.kPlayerClassEnd <= entityClass && entityClass < kEnemyClassStart)
			{
				return false;
			}

			if ((int)EntityClass.kEnemyClassEnd <= entityClass && entityClass < kNPCClassStart)
			{
				return false;
			}

			return true;
		}


		#region rReadWrite

		public void WriteEntity(BinaryWriter bw)
		{
			bw.Write((int)mPosition.X);
			bw.Write((int)mPosition.Y);
			bw.Write((UInt32)mEntityClass);
			bw.Write((UInt32)mStartDirection);
			bw.Write((UInt32)mGravityDirection);

			for (int i = 0; i < mFloatParams.Length; i++)
			{
				bw.Write(mFloatParams[i]);
				bw.Write(mIntParams[i]);
			}

			if (mEntityClass == EntityClass.kSimpleNPC)
			{
				bw.Write(mNPCPath);
				bw.Write(mTalkText);
				bw.Write(mHeckleText);
			}
		}


		public void ReadEntity(BinaryReader br, int fileVer)
		{
			mPosition.X = br.ReadInt32();
			mPosition.Y = br.ReadInt32();

			// Adjust for new tile size
			if(fileVer <= 2)
			{
				mPosition.X += 2;
				mPosition.Y += 2;
			}

			mEntityClass = (EntityClass)br.ReadUInt32();
			if (fileVer < 5)
			{
				if ((int)mEntityClass == 4099) // Old Bick ID
				{
					mEntityClass = EntityClass.kBickDogel;
				}
				if ((int)EntityClass.kNPCClassEnd <= (int)mEntityClass && (int)mEntityClass < kUtilityClassStart)
				{
					mEntityClass = EntityClass.kSimpleNPC;
				}
			}
			mStartDirection = (WalkDirection)br.ReadUInt32();
			mGravityDirection = (CardinalDirection)br.ReadUInt32();

			// Read generic params
			if (fileVer != 1)
			{
				for (int i = 0; i < mFloatParams.Length; i++)
				{
					mFloatParams[i] = br.ReadSingle();
					mIntParams[i] = br.ReadInt32();
				}
			}

			if (mEntityClass == EntityClass.kSimpleNPC)
			{
				if(fileVer >= 5)
				{
					mNPCPath = br.ReadString();
				}
				else
				{
					mNPCPath = "NPC/Name/Name.mtn";
				}
				mTalkText = br.ReadString();
				mHeckleText = br.ReadString();
			}
		}

		#endregion rReadWrite
	}
}
