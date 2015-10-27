using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auralux.Core.ObjectModels.CompiledLightingSequence
{
	public class FrameChannel
	{
		public class FrameChannelCollection
			: System.Collections.ObjectModel.Collection<FrameChannel>
		{

		}

		private int mvarAbsoluteOffset = 0;
		public int AbsoluteOffset { get { return mvarAbsoluteOffset; } set { mvarAbsoluteOffset = value; } }

		private byte mvarValue = 0;
		public byte Value { get { return mvarValue; } set { mvarValue = value; } }

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("channel ");
			sb.Append(mvarAbsoluteOffset);
			sb.Append(" = ");
			sb.Append(mvarValue);
			return sb.ToString();
		}
	}
}
