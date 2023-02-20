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

		public enum EntityClass
		{
			// Player
			kArnold = kPlayerClassStart,
			kAndrold,
			kPlayerClassEnd,

			// Enemy
			kTrundle = kEnemyClassStart,
			kRoboto,
			kEnemyClassEnd,

			//NPC
			kBarbara = kNPCClassStart,
			kZippy,
			kDok,
			kBickDogel,
			kElectrent,
			kNPCClassEnd
		}

		// UI
		public Image mImage;

		// Data
		public Point mPosition;
		public EntityClass mEntityClass;
		public WalkDirection mStartDirection;
		public CardinalDirection mGravityDirection;

		// Only NPC data
		public string mTalkText;
		public string mHeckleText;

		public Entity(Point tilePos)
		{
			mPosition = tilePos;
			mEntityClass = EntityClass.kArnold;
			mStartDirection = WalkDirection.kRight;
			mGravityDirection = CardinalDirection.kDown;

			mTalkText = "";
			mHeckleText = "";

			LoadImage();
		}

		public Entity(BinaryReader br)
		{
			ReadEntity(br);
			LoadImage();
		}

		void LoadImage()
		{
			switch (mEntityClass)
			{
				case EntityClass.kArnold:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.arnold);
					break;
				case EntityClass.kAndrold:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.androld);
					break;
				case EntityClass.kTrundle:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.trundle);
					break;
				case EntityClass.kRoboto:
					mImage = new Bitmap(AridArnoldEditor.Properties.Resources.roboto);
					break;
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
			switch (mEntityClass)
			{
				case EntityClass.kArnold:
					return "Arnold";
				case EntityClass.kAndrold:
					return "Androld";
				case EntityClass.kTrundle:
					return "Trundle";
				case EntityClass.kRoboto:
					return "Roboto";
				case EntityClass.kBarbara:
					return "Barbara";
				case EntityClass.kZippy:
					return "Zippy";
				case EntityClass.kDok:
					return "Dok";
				case EntityClass.kBickDogel:
					return "BickDogel";
				case EntityClass.kElectrent:
					return "Electrent";
				default:
					break;
			}

			throw new NotImplementedException();
		}


		public EntityType GetEntityType()
		{
			if((int)mEntityClass >= kNPCClassStart)
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

			if(GetEntityType() == EntityType.kSimpleNPC)
			{
				bw.Write(mTalkText);
				bw.Write(mHeckleText);
			}
		}


		public void ReadEntity(BinaryReader br)
		{
			mPosition.X = br.ReadInt32();
			mPosition.Y = br.ReadInt32();
			mEntityClass = (EntityClass)br.ReadUInt32();
			mStartDirection = (WalkDirection)br.ReadUInt32();
			mGravityDirection = (CardinalDirection)br.ReadUInt32();

			if (GetEntityType() == EntityType.kSimpleNPC)
			{
				mTalkText = br.ReadString();
				mHeckleText = br.ReadString();
			}
		}

		#endregion rReadWrite
	}
}
