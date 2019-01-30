using Homie.utils;

namespace Homie.datatypes
{
	public class Firmware : HomieMeta
	{
		[HomieField("name", HomiePropertyType.FIELD)]
		public string Name { get; set; }

		[HomieField("version", HomiePropertyType.FIELD)]
		public string Version { get; set; }

		[HomieField("checksum", HomiePropertyType.FIELD)]
		public string Checksum { get; set; }

		public override string ToString()
		{
			return string.Format("Name: {0}\tVersion: {1}\tChecksum: {2}", Name, Version, Checksum);
		}
	}
}
