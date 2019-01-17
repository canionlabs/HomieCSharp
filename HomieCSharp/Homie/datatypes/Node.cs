using System;
using System.Collections.Generic;
using Homie.utils;

namespace Homie.datatypes
{
	public class Node
	{
		public string Id;

		[HomieField("$type")]
		public string Type { get; set; }

		[HomieMap]
		public Dictionary<string, Property> Properties { get; set; }

		public Node()
		{
			this.Properties = new Dictionary<string, Property>();
		}
	}
}
