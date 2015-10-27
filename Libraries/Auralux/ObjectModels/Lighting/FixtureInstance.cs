using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auralux.Core.ObjectModels.Lighting
{
	public class FixtureInstance
	{
		public class FixtureInstanceCollection
			: System.Collections.ObjectModel.Collection<FixtureInstance>
		{

		}

		private Fixture mvarFixture = null;
		public Fixture Fixture { get { return mvarFixture; } set { mvarFixture = value; } }

		private int mvarInitialOffset = 0;
		public int InitialOffset { get { return mvarInitialOffset; } set { mvarInitialOffset = value; } }

		private FixtureMode mvarMode = null;
		public FixtureMode Mode { get { return mvarMode; } set { mvarMode = value; } }

		public FixtureInstance(Fixture fixture, int initialOffset)
		{
			mvarFixture = fixture;
			mvarInitialOffset = initialOffset;
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(mvarFixture.ToString());
			sb.Append(' ');
			sb.Append('@');
			sb.Append(' ');
			sb.Append(mvarInitialOffset.ToString());
			if (mvarMode != null)
			{
				sb.Append(' ');
				sb.Append('-');
				sb.Append(' ');
				sb.Append((mvarInitialOffset + mvarMode.Channels.Count).ToString());
				sb.Append(' ');
				sb.Append('(');
				sb.Append(mvarMode.Channels.Count.ToString());
				sb.Append(' ');
				sb.Append("channels");
				sb.Append(')');
			}
			return sb.ToString();
		}
	}
}
