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

		const int FILE_VER = 1;

		#endregion rConstants

		public List<LinearRail> LinearRails { get; set; }

		public AuxData()
		{
			LinearRails = new List<LinearRail>();
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
				WriteRail(bw, LinearRails[i]);
			}
		}

		private void WriteRail(BinaryWriter bw, LinearRail linearRail)
		{
			bw.Write(linearRail.GetSize());
			bw.Write(linearRail.GetSpeed());
			bw.Write(linearRail.GetCylce());

			//Nodes
			List<RailNode> nodes = linearRail.GetNodes();
			bw.Write(nodes.Count);

			for(int i = 0; i < nodes.Count; i++)
			{
				bw.Write(nodes[i].GetPoint().X);
				bw.Write(nodes[i].GetPoint().Y);
			}
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
				return;
			}

			//Rails
			int numRails = br.ReadInt32();
			for (int i = 0; i < numRails; i++)
			{
				LinearRails.Add(ReadRail(br));
			}
		}

		private LinearRail ReadRail(BinaryReader br)
		{
			LinearRail resultRail = new LinearRail(0.0f);

			resultRail.SetSize(br.ReadInt32());
			resultRail.ChangeSpeed(br.ReadSingle());
			resultRail.SetCycle(br.ReadBoolean());

			//Nodes
			int numNodes = br.ReadInt32();

			for (int i = 0; i < numNodes; i++)
			{
				int ptX = br.ReadInt32();
				int ptY = br.ReadInt32();

				resultRail.GetNodes().Add(new RailNode(new Point(ptX, ptY)));
			}

			return resultRail;
		}

		#endregion rRead


		private void Clear()
		{
			LinearRails.Clear();
		}
	}
}
