using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auralux.Core.ObjectModels.Lighting
{
	public class FixtureChannel : ICloneable
	{
		public class FixtureChannelCollection
			: System.Collections.ObjectModel.Collection<FixtureChannel>
		{

		}

		private Guid mvarID = Guid.Empty;
		public Guid ID { get { return mvarID; } set { mvarID = value; } }

		private string mvarTitle = String.Empty;
		public string Title { get { return mvarTitle; } set { mvarTitle = value; } }

		private FixtureChannelValue.FixtureChannelValueCollection mvarValues = new FixtureChannelValue.FixtureChannelValueCollection();
		public FixtureChannelValue.FixtureChannelValueCollection Values { get { return mvarValues; } }

		public object Clone()
		{
			FixtureChannel clone = new FixtureChannel();
			clone.ID = mvarID;
			clone.Title = (mvarTitle.Clone() as string);
			foreach (FixtureChannelValue item in mvarValues)
			{
				clone.Values.Add(item.Clone() as FixtureChannelValue);
			}
			return clone;
		}
	}
}
