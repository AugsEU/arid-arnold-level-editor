using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AridArnoldEditor
{
	class AuxData
	{
		#region rConstants

		const int FILE_VER = 2;

		#endregion rConstants

		public List<LinearRail> LinearRails { get; set; }
		public List<Entity> Entities { get; set; }

		public AuxData()
		{
			LinearRails = new List<LinearRail>();
			Entities = new List<Entity>();
		}

		#region rWrite

		public void SaveFile(string imageName)
		{
			string filePath = imageName.Substring(0, imageName.Length-3) + "aux";

			try
			{
				if (!File.Exists(filePath))
				{
					File.Create(filePath).Close();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception: " + ex.ToString());
				return;
			}

			SanitiseBeforeWrite();

			using (FileStream stream = File.OpenWrite(filePath))
			{
				using (BinaryWriter bw = new BinaryWriter(stream))
				{
					WriteBinary(bw);
				}
			}
		}

		private void WriteBinary(BinaryWriter bw)
		{
			bw.Write(FILE_VER);

			//Rails
			bw.Write(LinearRails.Count);
			for (int i = 0; i < LinearRails.Count; i++)
			{
				LinearRails[i].WriteRail(bw);
			}

			//Entities
			bw.Write(Entities.Count);
			for (int i = 0; i < Entities.Count; i++)
			{
				Entities[i].WriteEntity(bw);
			}
		}

		private void SanitiseBeforeWrite()
		{
			for (int i = 0; i < Entities.Count; i++)
			{
				if (Entities[i].ValidateEntity() == false)
				{
					DialogResult dialogResult = PromptError(Entities[i].mPosition, "entity");

					if (dialogResult != DialogResult.Yes)
					{
						Entities.RemoveAt(i);
						i--;
					}
				}
			}
		}

		private DialogResult PromptError(Point pos, string objectName)
		{
			string errorStr = "Invalid " + objectName + " at: " + pos.ToString() + ". Do you want to save it?";
			return MessageBox.Show(errorStr, "ERROR", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
		}

		#endregion rWrite





		#region rRead

		public void LoadFile(string imageName)
		{
			string filePath = imageName.Substring(0, imageName.Length - 3) + "aux";

			Clear();

			if (!File.Exists(filePath))
			{
				return;
			}

			bool delFile = false;

			using (FileStream stream = File.OpenRead(filePath))
			{
				using (BinaryReader br = new BinaryReader(stream))
				{
					try
					{
						ReadBinary(br);
					}
					catch (Exception ex)
					{
						Clear();
						delFile = true;
						Console.WriteLine("Exception: " + ex.ToString());
					}
				}
			}

			if (delFile)
			{
				File.Delete(filePath);
			}
		}

		private void ReadBinary(BinaryReader br)
		{
			int fileVersion = br.ReadInt32();
			if(fileVersion != FILE_VER)
			{
				Console.WriteLine("ERROR: WRONG FILE VERSION!");
			}

			//Rails
			int numRails = br.ReadInt32();
			for (int i = 0; i < numRails; i++)
			{
				LinearRail linearRail = new LinearRail(br);
				LinearRails.Add(linearRail);
			}

			//Check end of file
			if(br.BaseStream.Position == br.BaseStream.Length)
			{
				return;
			}

			//Entities
			int numEntities = br.ReadInt32();
			for (int i = 0; i < numEntities; i++)
			{
				Entity entity = new Entity(br, fileVersion);
				Entities.Add(entity);
			}
		}

		#endregion rRead


		public void Clear()
		{
			LinearRails.Clear();
			Entities.Clear();
		}
	}
}
