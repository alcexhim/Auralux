using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auralux.Core.ObjectModels.Lighting
{
	public abstract class FixtureChannelValue : ICloneable
	{
		public class FixtureChannelValueCollection
			: System.Collections.ObjectModel.Collection<FixtureChannelValue>
		{

		}

		private Guid mvarID = Guid.Empty;
		public Guid ID { get { return mvarID; } set { mvarID = value; } }

		private string mvarTitle = String.Empty;
		public string Title { get { return mvarTitle; } set { mvarTitle = value; } }

		public object Clone()
		{
			FixtureChannelValue clone = CloneInternal();
			clone.ID = mvarID;
			clone.Title = (mvarTitle.Clone() as string);
			return clone;
		}

		protected abstract FixtureChannelValue CloneInternal();
	}
	public class FixtureChannelValueRange : FixtureChannelValue
	{
		private byte mvarStartingValue = 0;
		public byte StartingValue { get { return mvarStartingValue; } set { mvarStartingValue = value; } }

		private byte mvarEndingValue = 0;
		public byte EndingValue { get { return mvarEndingValue; } set { mvarEndingValue = value; } }

		protected override FixtureChannelValue CloneInternal()
		{
			FixtureChannelValueRange clone = new FixtureChannelValueRange();
			clone.StartingValue = mvarStartingValue;
			clone.EndingValue = mvarEndingValue;
			return clone;
		}
	}
	public class FixtureChannelValueStatic : FixtureChannelValue
	{
		private byte mvarStartingValue = 0;
		public byte StartingValue { get { return mvarStartingValue; } set { mvarStartingValue = value; } }

		private byte mvarEndingValue = 0;
		public byte EndingValue { get { return mvarEndingValue; } set { mvarEndingValue = value; } }

		protected override FixtureChannelValue CloneInternal()
		{
			FixtureChannelValueStatic clone = new FixtureChannelValueStatic();
			clone.StartingValue = mvarStartingValue;
			clone.EndingValue = mvarEndingValue;
			return clone;
		}
	}
}
