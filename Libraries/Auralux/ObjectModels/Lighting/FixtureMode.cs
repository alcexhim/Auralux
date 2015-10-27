using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auralux.Core.ObjectModels.Lighting
{
	public class FixtureMode : ICloneable
	{
		public class FixtureModeCollection
			: System.Collections.ObjectModel.Collection<FixtureMode>
		{

		}

		private Guid mvarID = Guid.Empty;
		public Guid ID { get { return mvarID; } set { mvarID = value; } }

		private string mvarTitle = String.Empty;
		public string Title { get { return mvarTitle; } set { mvarTitle = value; } }

		private FixtureModeChannel.FixtureModeChannelCollection mvarChannels = new FixtureModeChannel.FixtureModeChannelCollection();
		public FixtureModeChannel.FixtureModeChannelCollection Channels { get { return mvarChannels; } }

		public object Clone()
		{
			FixtureMode clone = new FixtureMode();
			clone.ID = mvarID;
			clone.Title = (mvarTitle.Clone() as string);
			foreach (FixtureModeChannel item in mvarChannels)
			{
				clone.Channels.Add(item.Clone() as FixtureModeChannel);
			}
			return clone;
		}

		public override string ToString()
		{
			return mvarTitle;
		}
	}
}
