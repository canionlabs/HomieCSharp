using System;
using Homie.utils;

namespace Homie.datatypes
{
	public class Stat
	{
		[HomieField("uptime")]
		public int Uptime { get; set; }

		[HomieField("signal")]
		public int Signal { get; set; }

		[HomieField("interval")]
		public int Interval { get; set; }
	}
}
