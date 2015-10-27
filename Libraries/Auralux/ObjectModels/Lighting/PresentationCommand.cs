using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auralux.Core.ObjectModels.Lighting
{
	public class PresentationCommand
	{
		public class PresentationCommandCollection
			: System.Collections.ObjectModel.Collection<PresentationCommand>
		{

		}

		private Timestamp mvarTimestamp = null;
		public Timestamp Timestamp { get { return mvarTimestamp; } set { mvarTimestamp = value; } }
	}
}
