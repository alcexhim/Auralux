using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Auralux.Core.ObjectModels.Lighting;
using Auralux.Core;

namespace Auralux.ConsoleApplication
{
	class Program
	{
		public static void Main(string[] args)
		{
			Manager.Load();

			FixtureInstance instance = new FixtureInstance(Manager.ObjectModel.Fixtures[0], 23);
			instance.Mode = instance.Fixture.Modes[1];
		}
	}
}
