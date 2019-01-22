using System;
using System.Reflection;
using Homie.utils;

namespace Homie.datatypes
{
	public class Property : HomieMeta
	{
		public string Name { get; set; }
		public string Value { get; set; }
		public bool Settable { get; set; }

		public Property(string name)
		{
			this.Name = name;
		}

		public override string ToString()
		{
			return string.Format("{0} = {1}", Name, Value);
		}
	}
}
