using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auralux.Core.ObjectModels.Lighting
{
	public class FixtureModeChannel : ICloneable
	{
		public class FixtureModeChannelCollection
			: System.Collections.ObjectModel.Collection<FixtureModeChannel>
		{

		}

		private Guid mvarChannelID = Guid.Empty;
		public Guid ChannelID { get { return mvarChannelID; } set { mvarChannelID = value; } }

		private int mvarRelativeOffset = 0;
		public int RelativeOffset { get { return mvarRelativeOffset; } set { mvarRelativeOffset = value; } }

		public object Clone()
		{
			FixtureModeChannel clone = new FixtureModeChannel();
			clone.ChannelID = mvarChannelID;
			clone.RelativeOffset = mvarRelativeOffset;
			return clone;
		}
	}
}
