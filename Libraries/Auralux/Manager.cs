using Auralux.Core.DataFormats.Lighting.XML;
using Auralux.Core.ObjectModels.Lighting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversalEditor;
using UniversalEditor.Accessors;

namespace Auralux.Core
{
	public class Manager
	{
		private static LightingObjectModel mvarObjectModel = new LightingObjectModel();
		public static LightingObjectModel ObjectModel { get { return mvarObjectModel; } }

		public static void Load()
		{
			string[] paths = new string[]
			{
				System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)
			};
			Load(paths);

			foreach (Fixture fixt in mvarObjectModel.Fixtures)
			{
				if (fixt.ManufacturerID != Guid.Empty) fixt.Manufacturer = mvarObjectModel.Manufacturers[fixt.ManufacturerID];
			}
		}
		public static void Load(string[] paths)
		{
			foreach (string path in paths)
			{
				Load(path);
			}
		}
		public static void Load(string path)
		{
			string[] filenames = System.IO.Directory.GetFiles(path, "*.alxml", System.IO.SearchOption.AllDirectories);
			foreach (string filename in filenames)
			{
				LoadFile(filename);
			}
		}

		public static void LoadFile(string filename)
		{
			LightingXMLDataFormat xdf = new LightingXMLDataFormat();
			LightingObjectModel lighting = new LightingObjectModel();

			Document.Load(lighting, xdf, new FileAccessor(filename));

			lighting.CopyTo(mvarObjectModel);
		}
	}
}
