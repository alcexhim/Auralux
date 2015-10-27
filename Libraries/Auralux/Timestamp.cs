using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auralux.Core
{
	public abstract class Timestamp
	{
	}
	public class AbsoluteTimestamp : Timestamp
	{
		private double mvarDays = 0.0;
		public double Days { get { return mvarDays; } set { mvarDays = value; } }

		private double mvarHours = 0.0;
		public double Hours { get { return mvarHours; } set { mvarHours = value; } }

		private double mvarMinutes = 0.0;
		public double Minutes { get { return mvarMinutes; } set { mvarMinutes = value; } }

		private double mvarSeconds = 0.0;
		public double Seconds { get { return mvarSeconds; } set { mvarSeconds = value; } }

		private double mvarMilliseconds = 0.0;
		public double Milliseconds { get { return mvarMilliseconds; } set { mvarMilliseconds = value; } }
	}
	public class MetronomeTimestamp : Timestamp
	{
		private double mvarWholeBeat = 0.0;
		public double WholeBeat { get { return mvarWholeBeat; } set { mvarWholeBeat = value; } }

		private double mvarHalfBeat = 0.0;
		public double HalfBeat { get { return mvarHalfBeat; } set { mvarHalfBeat = value; } }

		private double mvarQuarterBeat = 0.0;
		public double QuarterBeat { get { return mvarQuarterBeat; } set { mvarQuarterBeat = value; } }

		private double mvarEighthBeat = 0.0;
		public double EighthBeat { get { return mvarEighthBeat; } set { mvarEighthBeat = value; } }

		private double mvarSixteenthBeat = 0.0;
		public double SixteenthBeat { get { return mvarSixteenthBeat; } set { mvarSixteenthBeat = value; } }
	}
}
