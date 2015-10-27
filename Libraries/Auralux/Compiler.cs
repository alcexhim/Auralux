using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Auralux.Core.ObjectModels.CompiledLightingSequence;
using Auralux.Core.ObjectModels.Lighting;

namespace Auralux.Core
{
	public class Compiler
	{
		public CompiledLightingSequenceObjectModel Compile(Presentation presentation)
		{
			CompiledLightingSequenceObjectModel compiled = new CompiledLightingSequenceObjectModel();

			// step 1: gather all the PresentationCommands that occur during the same Timestamp

			Dictionary<Timestamp, List<PresentationCommand>> commandsByTimestamp = new Dictionary<Timestamp, List<PresentationCommand>>();
			foreach (PresentationTrack track in presentation.Tracks)
			{
				foreach (PresentationCommand command in track.Commands)
				{
					if (!commandsByTimestamp.ContainsKey(command.Timestamp))
					{
						commandsByTimestamp.Add(command.Timestamp, new List<PresentationCommand>());
					}
					commandsByTimestamp[command.Timestamp].Add(command);
				}
			}

			// step 2: flatten the PresentationCommands to arrays of channel-> value mappings

			return compiled;
		}
	}
}
