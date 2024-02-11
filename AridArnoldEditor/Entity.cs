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
		public enum EntityType
		{
			kBasic,
			kSimpleNPC
		}

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
			kBarbara = kNPCClassStart,
			kZippy,
			kDok,
			kBickDogel,
			kElectrent,
			kBoilerMan,
			kBossMan,
			kBooker,
			kScholar,
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

			LoadImage();
		}

		public Entity(BinaryReader br, int fileVer)
		{
			mFloatParams = new float[8];
			mIntParams = new int[8];
			mTalkText = "";
			mHeckleText = "";

			ReadEntity(br, fileVer);
			LoadImage();
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

		void LoadImage()
		{
			switch (mEntityClass)
			{
				// Player
				case EntityClass.kArnold:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.arnold);
					break;
				case EntityClass.kAndrold:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.androld);
					break;

				// Enemy
				case EntityClass.kTrundle:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.trundle);
					break;
				case EntityClass.kRoboto:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.roboto);
					break;
				case EntityClass.kFutronGun:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.FutronGun);
					break;
				case EntityClass.kFutronRocket:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.FutronRocket);
					break;
				case EntityClass.kMamal:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.Mamal);
					break;
				case EntityClass.kPapyras:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.Papyras);
					break;
				case EntityClass.kRanger:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.Ranger);
					break;

				// NPC
				case EntityClass.kBarbara:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.barbara);
					break;
				case EntityClass.kZippy:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.zippy);
					break;
				case EntityClass.kDok:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.dok);
					break;
				case EntityClass.kBickDogel:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.grillvogel);
					break;
				case EntityClass.kElectrent:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.electrent);
					break;
				case EntityClass.kFarry:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.Farry);
					break;
				case EntityClass.kBoilerMan:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.BoilerMan);
					break;
				case EntityClass.kBossMan:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.BossMan);
					break;
				case EntityClass.kBooker:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.Booker);
					break;
				case EntityClass.kScholar:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.Scholar);
					break;

				// Utility
				case EntityClass.kArnoldSpawner:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.arnoldSpawner);
					break;
				case EntityClass.kSequenceDoor:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.Door);
					break;
				case EntityClass.kLevelLock:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.LevelLock);
					break;
				case EntityClass.kShopDoor:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.ShopDoor);
					break;
				case EntityClass.kItemStand:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.ItemStand);
					break;
				case EntityClass.kGravityOrb:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.OrbBase);
					break;
				case EntityClass.kGravityTile:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.GravityTile);
					break;
				case EntityClass.kTimeMachine:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.TimeMachine);
					break;
				case EntityClass.kPlantPot:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.PotWinter);
					break;
				case EntityClass.kPillarPot:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.PillarBase);
					break;
				default:
					mImage = new Bitmap(16, 16);
					break;
			}
		}

		public void SetClass(EntityClass theClass)
		{
			if (theClass != mEntityClass)
			{
				mEntityClass = theClass;
				LoadImage();

				if (GetEntityType() == EntityType.kSimpleNPC)
				{
					SetDefaultText();
				}
			}
		}

		void SetDefaultText()
		{
			mTalkText = "NPC." + GetEntityName() + ".Talk";
			mHeckleText = "NPC." + GetEntityName() + ".Heckle";
		}

		string GetEntityName()
		{
			string entityName = mEntityClass.ToString();

			if (entityName.StartsWith("k"))
			{
				entityName = entityName.Substring(1);
			}

			return entityName;
		}


		public EntityType GetEntityType()
		{
			if((int)mEntityClass >= kNPCClassStart && (int)mEntityClass <= (int)EntityClass.kNPCClassEnd)
			{
				if(mEntityClass == EntityClass.kBickDogel)
				{
					// Special exception
					return EntityType.kBasic;
				}

				return EntityType.kSimpleNPC;
			}
			return EntityType.kBasic;
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

			if (GetEntityType() == EntityType.kSimpleNPC)
			{
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

			if (GetEntityType() == EntityType.kSimpleNPC)
			{
				mTalkText = br.ReadString();
				mHeckleText = br.ReadString();
			}
		}

		#endregion rReadWrite
	}
}
