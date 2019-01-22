using System;
using System.Collections.Generic;
using System.Reflection;
using Homie.exchange;
using Homie.utils;

namespace Homie.datatypes
{
	public class Device : HomieMeta
	{
		public string Id { get; set; }

		[HomieField("$homie", HomiePropertyType.FIELD)]
		public string HomieVersion { get; set; }

		[HomieField("$online", HomiePropertyType.FIELD)]
		public bool Online { get; set; }

		[HomieField("$name", HomiePropertyType.FIELD)]
		public string Name { get; set; }

		[HomieField("$localip", HomiePropertyType.FIELD)]
		public string LocalIP { get; set; }

		[HomieField("$mac", HomiePropertyType.FIELD)]
		public string MAC { get; set; }

		[HomieField("$implementation", HomiePropertyType.FIELD)]
		public string Implementation { get; set; }

		[HomieField("$stats", HomiePropertyType.STRUCT)]
		public Stat Stat { get; set; }

		[HomieField("$fw", HomiePropertyType.STRUCT)]
		public Firmware Firmware { get; set; }

		[HomieField("$nodes", HomiePropertyType.MAP)]
		public Dictionary<string, Node> Nodes { get; set; }

		public Device(string id)
		{
			this.Id = id;
			this.Stat = new Stat();
			this.Firmware = new Firmware();
			this.Nodes = new Dictionary<string, Node>();
		}

		public override string ToString()
		{
			var output = "";

			foreach(var node in Nodes.Values)
			{
				output += node.ToString();
			}

			return string.Format(
@"ID: {0}
Online: {1}
Name: {2}
LocalIP: {3}
MAC: {4}
Implementation: {5}
Stat: {6}
Firmware: {7}
Nodes: 
{8}", Id, Online, Name, LocalIP, MAC, Implementation, Stat, Firmware, output);
		}
	}
}
