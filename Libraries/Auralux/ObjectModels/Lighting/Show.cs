using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auralux.Core
{
	public class Show
	{

		private Guid mvarID = Guid.Empty;
		public Guid ID { get { return mvarID; } set { mvarID = value; } }

		private string mvarTitle = String.Empty;
		public string Title { get { return mvarTitle; } set { mvarTitle = value; } }

	}
}
