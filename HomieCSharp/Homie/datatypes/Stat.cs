using System;
using Homie.exchange;
using Homie.utils;

namespace Homie.datatypes
{
	public class Stat : HomieMeta
	{
		[HomieField("uptime", HomiePropertyType.FIELD)]
		public int Uptime { get; set; }

		[HomieField("signal", HomiePropertyType.FIELD)]
		public int Signal { get; set; }

		[HomieField("interval", HomiePropertyType.FIELD)]
		public int Interval { get; set; }

		public override string ToString()
		{
			return string.Format("UP: {0}\tSignal: {1}\tInterval: {2}", Uptime, Signal, Interval);
		}
	}
}
