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
		const int kPlayerClassStart = 0 * kClassSpacing;
		const int kEnemyClassStart  = 1 * kClassSpacing;
		const int kNPCClassStart    = 2 * kClassSpacing;

		public enum EntityClass
		{
			// Player
			kArnold = kPlayerClassStart,
			kAndrold,

			// Enemy
			kTrundle = kEnemyClassStart,
			kRoboto,

			//NPC
			kBarbara = kNPCClassStart,
			kZippy,
			kDok,
			kBickDogel,
			kElectrent
		}

		// UI
		public Image mImage;

		// Data
		public Point mPosition;
		public EntityClass mEntityClass;
		public WalkDirection mStartDirection;
		public CardinalDirection mGravityDirection;

		public Entity(Point tilePos)
		{
			mPosition = tilePos;
			mEntityClass = EntityClass.kArnold;
			mStartDirection = WalkDirection.kRight;
			mGravityDirection = CardinalDirection.kDown;

			LoadImage();
		}

		void LoadImage()
		{
			switch (mEntityClass)
			{
				case EntityClass.kArnold:
					break;
				case EntityClass.kAndrold:
					break;
				case EntityClass.kTrundle:
					break;
				case EntityClass.kRoboto:
					break;
				case EntityClass.kBarbara:
					break;
				case EntityClass.kZippy:
					break;
				case EntityClass.kDok:
					break;
				case EntityClass.kBickDogel:
					break;
				case EntityClass.kElectrent:
					break;
				default:
					break;
			}
			mImage = new Bitmap(16,16);
		}


		public virtual EntityType GetEntityType()
		{
			return EntityType.kBasic;
		}
	}
}
