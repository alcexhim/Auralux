using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UniversalEditor.ObjectModels.Markup;
using UniversalEditor.DataFormats.Markup.XML;
using UniversalEditor;

using Auralux.Core.ObjectModels.Lighting;

namespace Auralux.Core.DataFormats.Lighting.XML
{
	public class LightingXMLDataFormat : XMLDataFormat
	{
		private static DataFormatReference _dfr = null;
		protected override DataFormatReference MakeReferenceInternal()
		{
			if (_dfr == null)
			{
				_dfr = new DataFormatReference(GetType());
				_dfr.Capabilities.Add(typeof(LightingObjectModel), DataFormatCapabilities.All);
			}
			return _dfr;
		}

		protected override void BeforeLoadInternal(Stack<ObjectModel> objectModels)
		{
			base.BeforeLoadInternal(objectModels);
			objectModels.Push(new MarkupObjectModel());
		}
		protected override void AfterLoadInternal(Stack<ObjectModel> objectModels)
		{
			base.AfterLoadInternal(objectModels);

			MarkupObjectModel mom = (objectModels.Pop() as MarkupObjectModel);
			LightingObjectModel lighting = (objectModels.Pop() as LightingObjectModel);

			MarkupTagElement tagAuralux = (mom.Elements["Auralux"] as MarkupTagElement);
			if (tagAuralux == null) throw new InvalidDataFormatException("File does not begin with top-level tag 'Auralux'");

			foreach (MarkupElement el in tagAuralux.Elements)
			{
				MarkupTagElement tag = (el as MarkupTagElement);
				if (tag == null) continue;

				switch (tag.FullName)
				{
					case "Manufacturers":
					{
						LoadManufacturers(tag, lighting);
						break;
					}
					case "Fixtures":
					{
						LoadFixtures(tag, lighting);
						break;
					}
				}
			}
		}

		private void LoadFixtures(MarkupTagElement tag, LightingObjectModel lighting)
		{
			foreach (MarkupElement el1 in tag.Elements)
			{
				MarkupTagElement tag1 = (el1 as MarkupTagElement);
				if (tag1 == null) continue;
				if (tag1.FullName != "Fixture") continue;

				MarkupAttribute attID = tag1.Attributes["ID"];
				if (attID == null) continue;

				Fixture item = new Fixture();
				item.ID = new Guid(attID.Value);

				MarkupAttribute attManufacturerID = tag1.Attributes["ManufacturerID"];
				if (attManufacturerID != null) item.ManufacturerID = new Guid(attManufacturerID.Value);

				MarkupTagElement tagInformation = (tag1.Elements["Information"] as MarkupTagElement);
				if (tagInformation != null)
				{
					MarkupTagElement tagTitle = (tagInformation.Elements["Title"] as MarkupTagElement);
					if (tagTitle != null) item.Title = tagTitle.Value;
				}

				#region Channels
				{
					MarkupTagElement tagChannels = (tag1.Elements["Channels"] as MarkupTagElement);
					if (tagChannels != null)
					{
						foreach (MarkupElement elChannel in tagChannels.Elements)
						{
							MarkupTagElement tagChannel = (elChannel as MarkupTagElement);
							if (tagChannel == null) continue;
							if (tagChannel.FullName != "Channel") continue;

							MarkupAttribute attChannelID = tagChannel.Attributes["ID"];
							if (attChannelID == null) continue;

							FixtureChannel channel = new FixtureChannel();
							channel.ID = new Guid(attChannelID.Value);

							MarkupTagElement tagChannelInformation = (tagChannel.Elements["Information"] as MarkupTagElement);
							if (tagChannelInformation != null)
							{
								MarkupTagElement tagChannelTitle = (tagChannelInformation.Elements["Title"] as MarkupTagElement);
								if (tagChannelTitle != null) channel.Title = tagChannelTitle.Value;
							}

							MarkupTagElement tagChannelValues = (tagChannel.Elements["Values"] as MarkupTagElement);
							if (tagChannelValues != null)
							{
								foreach (MarkupElement elChannelValue in tagChannelValues.Elements)
								{
									MarkupTagElement tagChannelValue = (elChannelValue as MarkupTagElement);
									if (tagChannelValue == null) continue;
								
									MarkupAttribute attTitle = (tagChannelValue.Attributes["Title"] as MarkupAttribute);
									string title = null;
									if (attTitle != null) title = attTitle.Value;

									switch (tagChannelValue.FullName.ToLower())
									{
										case "range":
										{
											FixtureChannelValueRange value = new FixtureChannelValueRange();

											MarkupAttribute attStartingValue = tagChannelValue.Attributes["From"];
											MarkupAttribute attEndingValue = tagChannelValue.Attributes["Until"];

											value.Title = title;
											value.StartingValue = Byte.Parse(attStartingValue.Value);
											value.EndingValue = Byte.Parse(attEndingValue.Value);

											channel.Values.Add(value);
											break;
										}
										case "static":
										{
											FixtureChannelValueStatic value = new FixtureChannelValueStatic();

											MarkupAttribute attStartingValue = tagChannelValue.Attributes["From"];
											MarkupAttribute attEndingValue = tagChannelValue.Attributes["Until"];

											value.Title = title;
											value.StartingValue = Byte.Parse(attStartingValue.Value);
											value.EndingValue = Byte.Parse(attEndingValue.Value);

											channel.Values.Add(value);
											break;
										}
										default:
										{
											Console.WriteLine("alxml: unknown channel value type '" + tagChannelValue.FullName + "'");
											break;
										}
									}
								}
							}

							item.Channels.Add(channel);
						}
					}
				}
				#endregion

				#region Modes
				{
					MarkupTagElement tagModes = (tag1.Elements["Modes"] as MarkupTagElement);
					if (tagModes != null)
					{
						foreach (MarkupElement elMode in tagModes.Elements)
						{
							MarkupTagElement tagMode = (elMode as MarkupTagElement);
							LoadMode(tagMode, item);
						}
					}
				}
				#endregion

				lighting.Fixtures.Add(item);
			}
		}

		private bool LoadMode(MarkupTagElement tag, Fixture fixture)
		{
			if (tag == null) return false;
			if (tag.FullName != "Mode") return false;

			MarkupAttribute attModeID = tag.Attributes["ID"];
			if (attModeID == null) return false;

			FixtureMode mode = new FixtureMode();
			mode.ID = new Guid(attModeID.Value);

			MarkupAttribute attTitle = tag.Attributes["Title"];
			if (attTitle != null) mode.Title = attTitle.Value;

			MarkupTagElement tagChannels = (tag.Elements["Channels"] as MarkupTagElement);
			foreach (MarkupElement elChannel in tagChannels.Elements)
			{
				MarkupTagElement tagChannel = (elChannel as MarkupTagElement);
				if (tagChannel == null) continue;
				if (tagChannel.FullName != "Channel") continue;

				MarkupAttribute attChannelID = tagChannel.Attributes["ID"];
				if (attChannelID == null) continue;

				MarkupAttribute attRelativeOffset = tagChannel.Attributes["RelativeOffset"];

				FixtureModeChannel channel = new FixtureModeChannel();
				channel.ChannelID = new Guid(attChannelID.Value);

				int relativeOffset = 0;
				if (attRelativeOffset != null && Int32.TryParse(attRelativeOffset.Value, out relativeOffset))
				{
					channel.RelativeOffset = relativeOffset;
				}

				mode.Channels.Add(channel);
			}

			fixture.Modes.Add(mode);
			return true;
		}
		private void LoadManufacturers(MarkupTagElement tag, LightingObjectModel lighting)
		{
			foreach (MarkupElement el1 in tag.Elements)
			{
				MarkupTagElement tag1 = (el1 as MarkupTagElement);
				if (tag1 == null) continue;
				if (tag1.FullName != "Manufacturer") continue;

				MarkupAttribute attID = tag1.Attributes["ID"];
				if (attID == null) continue;

				Manufacturer item = new Manufacturer();
				item.ID = new Guid(attID.Value);

				MarkupTagElement tagInformation = (tag1.Elements["Information"] as MarkupTagElement);
				if (tagInformation != null)
				{
					MarkupTagElement tagTitle = (tagInformation.Elements["Title"] as MarkupTagElement);
					if (tagTitle != null) item.Title = tagTitle.Value;
				}

				lighting.Manufacturers.Add(item);
			}
		}

		protected override void BeforeSaveInternal(Stack<ObjectModel> objectModels)
		{
			base.BeforeSaveInternal(objectModels);

			LightingObjectModel lighting = (objectModels.Pop() as LightingObjectModel);
			MarkupObjectModel mom = new MarkupObjectModel();

			objectModels.Push(mom);
		}
	}
}
