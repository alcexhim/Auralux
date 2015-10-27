using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auralux.Core.ObjectModels.Lighting
{
	public class Fixture : ICloneable
	{
		public class FixtureCollection
			: System.Collections.ObjectModel.Collection<Fixture>
		{

		}

		private Guid mvarID = Guid.Empty;
		public Guid ID { get { return mvarID; } set { mvarID = value; } }

		internal Guid ManufacturerID = Guid.Empty;
		private Manufacturer mvarManufacturer = null;
		public Manufacturer Manufacturer { get { return mvarManufacturer; } set { mvarManufacturer = value; } }

		private string mvarTitle = String.Empty;
		public string Title { get { return mvarTitle; } set { mvarTitle = value; } }

		private FixtureChannel.FixtureChannelCollection mvarChannels = new FixtureChannel.FixtureChannelCollection();
		public FixtureChannel.FixtureChannelCollection Channels { get { return mvarChannels; } }
		
		private FixtureMode.FixtureModeCollection mvarModes = new FixtureMode.FixtureModeCollection();
		public FixtureMode.FixtureModeCollection Modes { get { return mvarModes; } }

		public object Clone()
		{
			Fixture clone = new Fixture();
			clone.ID = mvarID;
			clone.ManufacturerID = ManufacturerID;
			clone.Manufacturer = mvarManufacturer;
			clone.Title = (mvarTitle.Clone() as string);
			foreach (FixtureChannel item in mvarChannels)
			{
				clone.Channels.Add(item.Clone() as FixtureChannel);
			}
			foreach (FixtureMode item in mvarModes)
			{
				clone.Modes.Add(item.Clone() as FixtureMode);
			}
			return clone;
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			if (mvarManufacturer != null)
			{
				sb.Append(mvarManufacturer.Title);
				sb.Append(' ');
			}
			sb.Append(mvarTitle);
			return sb.ToString();
		}
	}
}
