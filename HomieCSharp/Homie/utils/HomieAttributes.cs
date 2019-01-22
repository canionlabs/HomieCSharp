using System;

namespace Homie.utils
{
	public enum HomiePropertyType
	{
		FIELD,
		STRUCT,
		MAP
	}

	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public class HomieField : Attribute
	{
		public string tag;
		public HomiePropertyType type;

		public HomieField(string tag, HomiePropertyType type)
		{
			this.tag = tag;
			this.type = type;
		}
	}
}
