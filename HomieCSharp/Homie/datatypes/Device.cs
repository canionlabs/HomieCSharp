using System;
using System.Collections.Generic;
using Homie.utils;

namespace Homie.datatypes
{
	public class Device
	{
		public string Id { get; set; }

		[HomieField("$homie")]
		public string HomieVersion { get; set; }

		[HomieField("$online")]
		public bool Online { get; set; }

		[HomieField("$name")]
		public string Name { get; set; }

		[HomieField("$localip")]
		public string LocalIP { get; set; }

		[HomieField("$mac")]
		public string MAC { get; set; }

		[HomieField("$implementation")]
		public string Implementation { get; set; }

		[HomieStruct]
		public Stat Stat { get; set; }

		[HomieStruct]
		public Firmware Firmware { get; set; }

		[HomieMap]
		public Dictionary<string, Node> Nodes { get; set; }

		public Device()
		{
			this.Stat = new Stat();
			this.Firmware = new Firmware();
			this.Nodes = new Dictionary<string, Node>();
		}
	}
}
