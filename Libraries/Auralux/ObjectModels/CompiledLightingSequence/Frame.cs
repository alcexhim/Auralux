using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auralux.Core.ObjectModels.CompiledLightingSequence
{
	public class Frame
	{
		public class FrameCollection
			: System.Collections.ObjectModel.Collection<Frame>
		{

		}

		private Timestamp mvarTimestamp = null;
		public Timestamp Timestamp { get { return mvarTimestamp; } }

		private FrameChannel.FrameChannelCollection mvarChannels = new FrameChannel.FrameChannelCollection();
		public FrameChannel.FrameChannelCollection Channels { get { return mvarChannels; } }
	}
}
