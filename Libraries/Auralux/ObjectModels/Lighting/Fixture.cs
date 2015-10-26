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

		public object Clone()
		{
			Fixture clone = new Fixture();
			clone.ID = mvarID;
			return clone;
		}
	}
}
