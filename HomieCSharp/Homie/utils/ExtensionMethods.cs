using System;
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
	}
}
