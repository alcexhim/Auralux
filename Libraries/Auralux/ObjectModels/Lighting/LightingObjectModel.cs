using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UniversalEditor;

namespace Auralux.Core.ObjectModels.Lighting
{
	public class LightingObjectModel : ObjectModel
	{
		private Manufacturer.ManufacturerCollection mvarManufacturers = new Manufacturer.ManufacturerCollection();
		public Manufacturer.ManufacturerCollection Manufacturers { get { return mvarManufacturers; } }

		private Fixture.FixtureCollection mvarFixtures = new Fixture.FixtureCollection();
		public Fixture.FixtureCollection Fixtures { get { return mvarFixtures; } }

		private Presentation.PresentationCollection mvarPresentations = new Presentation.PresentationCollection();
		public Presentation.PresentationCollection Presentations { get { return mvarPresentations; } }

		public override void Clear()
		{
			mvarManufacturers.Clear();
			mvarFixtures.Clear();
		}

		public override void CopyTo(ObjectModel where)
		{
			LightingObjectModel clone = (where as LightingObjectModel);
			if (clone == null) throw new ObjectModelNotSupportedException();

			foreach (Manufacturer item in mvarManufacturers)
			{
				clone.Manufacturers.Add(item.Clone() as Manufacturer);
			}
			foreach (Fixture item in mvarFixtures)
			{
				clone.Fixtures.Add(item.Clone() as Fixture);
			}
		}
	}
}
