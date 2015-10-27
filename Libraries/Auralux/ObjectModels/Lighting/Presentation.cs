using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auralux.Core.ObjectModels.Lighting
{
	public class Presentation
	{
		public class PresentationCollection
			: System.Collections.ObjectModel.Collection<Presentation>
		{

		}

		private FixtureInstance.FixtureInstanceCollection mvarFixtures = new FixtureInstance.FixtureInstanceCollection();
		/// <summary>
		/// The collection of <see cref="FixtureInstance" />s that are used in this <see cref="Presentation" />.
		/// </summary>
		public FixtureInstance.FixtureInstanceCollection Fixtures { get { return mvarFixtures; } }

		private Guid mvarID = Guid.Empty;
		public Guid ID { get { return mvarID; } set { mvarID = value; } }

		private string mvarTitle = String.Empty;
		public string Title { get { return mvarTitle; } set { mvarTitle = value; } }


		public IEnumerable<PresentationTrack> Tracks { get; set; }
	}
}
