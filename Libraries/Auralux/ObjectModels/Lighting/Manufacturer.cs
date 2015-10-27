using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auralux.Core.ObjectModels.Lighting
{
	public class Manufacturer : ICloneable
	{
		public class ManufacturerCollection
			: System.Collections.ObjectModel.Collection<Manufacturer>
		{
			private Dictionary<Guid, Manufacturer> manufacturersByID = new Dictionary<Guid, Manufacturer>();

			protected override void ClearItems()
			{
				base.ClearItems();
				manufacturersByID.Clear();
			}
			protected override void InsertItem(int index, Manufacturer item)
			{
				base.InsertItem(index, item);
				manufacturersByID[item.ID] = item;
			}
			protected override void RemoveItem(int index)
			{
				if (manufacturersByID.ContainsKey(this[index].ID))
				{
					manufacturersByID.Remove(this[index].ID);
				}
				base.RemoveItem(index);
			}
			protected override void SetItem(int index, Manufacturer item)
			{
				if (this[index] != null && manufacturersByID.ContainsKey(this[index].ID)) manufacturersByID.Remove(this[index].ID);
				base.SetItem(index, item);
				manufacturersByID[item.ID] = item;
			}

			public Manufacturer this[Guid id]
			{
				get
				{
					if (!manufacturersByID.ContainsKey(id)) return null;
					return manufacturersByID[id];
				}
			}
		}

		private Guid mvariD = Guid.Empty;
		public Guid ID { get { return mvariD; } set { mvariD = value; } }

		private string mvarTitle = String.Empty;
		public string Title { get { return mvarTitle; } set { mvarTitle = value; } }

		public object Clone()
		{
			Manufacturer clone = new Manufacturer();
			clone.ID = mvariD;
			clone.Title = (mvarTitle.Clone() as string);
			return clone;
		}

		public override string ToString()
		{
			return mvarTitle;
		}
	}
}
