using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auralux.Core.ObjectModels.CompiledLightingSequence
{
	public class CompiledLightingSequenceObjectModel
	{
		private Frame.FrameCollection mvarFrames = new Frame.FrameCollection();
		public Frame.FrameCollection Frames { get { return mvarFrames; } }
	}
}
