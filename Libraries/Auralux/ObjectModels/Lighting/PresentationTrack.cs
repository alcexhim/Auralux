using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auralux.Core.ObjectModels.Lighting
{
	public class PresentationTrack
	{
		private PresentationCommand.PresentationCommandCollection mvarCommands = new PresentationCommand.PresentationCommandCollection();
		public PresentationCommand.PresentationCommandCollection Commands { get { return mvarCommands; } }
	}
}
