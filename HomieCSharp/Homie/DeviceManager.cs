using System;
using System.Collections.Generic;
using Homie.datatypes;
using Homie.exchange;
using System.Linq;
using Homie.utils;
using System.Reflection;

namespace Homie
{
	public static class DeviceManager
	{
		public static string BaseTopic { get; private set; }
		public static Dictionary<string, Device> Devices { get; set; }
		public static bool IsReady => !string.IsNullOrEmpty(BaseTopic) && Devices != null;

		public static void Setup(string baseTopic)
		{
			BaseTopic = baseTopic;
			Devices = new Dictionary<string, Device>();
		}

		public static Device CreateDevice(IClientModel client, string ID)
		{
			if (!IsReady)
			{
				throw new Exception("DeviceManager is not ready, please call Setup() first.");
			}

			if (client != null || string.IsNullOrEmpty(ID))
			{
				throw new ArgumentException("Invalid arguments");
			}

			// Create a new Device
			var device = new Device(ID);

			// Register device to internal dictionary
			Devices.Add(ID, device);

			// Use client to subscribe to this particular Device ID
			client.Subscribe(string.Join("/", BaseTopic, ID, "#"), ProcessData);

			return device;
		}

		private static void ProcessData(string topic, string data)
		{
			if (topic.StartsWith(BaseTopic, StringComparison.CurrentCulture))
			{
				var info = topic.Split("/").Skip(1).ToArray();
				var deviceID = info[0];

				if (Devices.TryGetValue(deviceID, out Device device))
				{
					InjectData(device, data, info.Skip(1).ToArray());
				}
			}
		}

		private static void InjectData(HomieMeta meta, string data, params string[] path)
		{
			var field = path[0];

			if (meta.metaData.TryGetValue(field, out PropertyInfo property))
			{
				var info = meta.fieldMetaData[property];

				switch (info.type)
				{
					case HomiePropertyType.FIELD:

						if (property.IsString())
						{
							property.SetValue(meta, data);
						}
						else if (property.IsInt())
						{
							property.SetValue(meta, data.ParseInt());
						}
						else if (property.IsBool())
						{
							property.SetValue(meta, data.ParseBool());
						}

						break;
					case HomiePropertyType.STRUCT:

						HomieMeta structField = property.GetValue(meta) as HomieMeta;

						if (structField != null)
						{
							InjectData(structField, data, path.Skip(1).ToArray());
						}

						break;
					case HomiePropertyType.MAP:

						switch (field)
						{
							case "$nodes":

								var nodeMap = property.GetValue(meta) as Dictionary<string, Node>;

								foreach (var nodeName in data.Split(","))
								{
									var node = new Node(nodeName);

									nodeMap.TryAdd(nodeName, node);
									meta.metaLink.TryAdd(nodeName, node);
								}

								break;

							case "$properties":

								var propertyMap = property.GetValue(meta) as Dictionary<string, Property>;

								foreach (var propertyName in data.Split(","))
								{
									var prop = new Property(propertyName);

									propertyMap.TryAdd(propertyName, prop);
									meta.metaLink.TryAdd(propertyName, prop);
								}

								break;
						}

						break;
				}
			}
			else if (meta.metaLink.TryGetValue(field, out HomieMeta homieMeta))
			{
				if (homieMeta.GetType().IsAssignableFrom(typeof(Node)))
				{
					Console.WriteLine("Processing Node");

					InjectData(homieMeta, data, path.Skip(1).ToArray());
				}

				if (homieMeta.GetType().IsAssignableFrom(typeof(Property)))
				{
					var homieProperty = homieMeta as Property;

					homieProperty.Value = data;
				}
			}
		}
	}
}
