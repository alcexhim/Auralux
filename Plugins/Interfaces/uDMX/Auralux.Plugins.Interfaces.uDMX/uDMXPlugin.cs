using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auralux.Plugins.Interfaces.uDMX
{
    public class uDMXPlugin : InterfacePlugin
    {

		protected override DevicePlugin[] GetDevicesInternal()
		{
			List<DevicePlugin> list = new List<DevicePlugin>();

			return list.ToArray();
		}
	}
}
