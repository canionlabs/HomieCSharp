using System;
using System.Collections.Generic;
using Homie.exchange;
using Homie.utils;

namespace Homie.datatypes
{
	public class Node : HomieMeta
	{
		public string Id;

		[HomieField("$type", HomiePropertyType.FIELD)]
		public string Type { get; set; }

		[HomieField("$properties", HomiePropertyType.MAP)]
		public Dictionary<string, Property> Properties { get; set; }

		public Node(string nodeName)
		{
			this.Id = nodeName;
			this.Properties = new Dictionary<string, Property>();
		}

		public override string ToString()
		{
			var output = "";
			foreach(var prop in Properties.Values)
			{
				output += prop.ToString();
			}

			return string.Format("\nID: {0}\tType: {1}\n{2}", Id, Type, output);
		}
	}
}
