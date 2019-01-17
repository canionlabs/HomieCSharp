using System;
using Homie.utils;

namespace Homie.datatypes
{
	public class Firmware
	{
		[HomieField("name")]
		public string Name { get; set; }

		[HomieField("version")]
		public string Version { get; set; }

		[HomieField("checksum")]
		public string Checksum { get; set; }
	}
}
