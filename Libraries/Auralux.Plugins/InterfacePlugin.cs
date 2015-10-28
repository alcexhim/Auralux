using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auralux.Plugins
{
    public abstract class InterfacePlugin
    {
		public void Initialize()
		{
			InitializeInternal();
		}
		protected virtual void InitializeInternal()
		{
		}

		public DevicePlugin[] GetDevices()
		{
			return GetDevicesInternal();
		}
		protected abstract DevicePlugin[] GetDevicesInternal();
    }
}
