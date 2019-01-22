using System;
using System.Reflection;

namespace Homie.utils
{
	public static class ExtensionMethods
	{
		public static int ParseInt(this string data)
		{
			int.TryParse(data, out int value);
			return value;
		}

		public static bool ParseBool(this string data)
		{
			bool.TryParse(data, out bool value);
			return value;
		}

		public static bool IsString(this PropertyInfo property)
		{
			return IsType(property, typeof(string));
		}

		public static bool IsInt(this PropertyInfo property)
		{
			return IsType(property, typeof(int));
		}

		public static bool IsBool(this PropertyInfo property)
		{
			return IsType(property, typeof(bool));
		}

		private static bool IsType(PropertyInfo property, Type type)
		{
			return property.PropertyType.IsAssignableFrom(type);
		}
	}
}
