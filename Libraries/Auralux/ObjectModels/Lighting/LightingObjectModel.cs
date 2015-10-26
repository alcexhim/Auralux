using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UniversalEditor;

namespace Auralux.Core.ObjectModels.Lighting
{
	public class LightingObjectModel : ObjectModel
	{
		private Fixture.FixtureCollection mvarFixtures = new Fixture.FixtureCollection();
		public Fixture.FixtureCollection Fixtures { get { return mvarFixtures; } }

		public override void Clear()
		{
			mvarFixtures.Clear();
		}

		public override void CopyTo(ObjectModel where)
		{
			LightingObjectModel clone = (where as LightingObjectModel);
			if (clone == null) throw new ObjectModelNotSupportedException();

			foreach (Fixture fixt in mvarFixtures)
			{
				clone.Fixtures.Add(fixt.Clone() as Fixture);
			}
		}
	}
}
