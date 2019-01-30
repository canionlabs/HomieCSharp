using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace Homie.utils
{
	public abstract class HomieMeta
	{
		[JsonIgnore]
		public Dictionary<string, HomieMeta> metaLink;

		[JsonIgnore]
		public Dictionary<string, PropertyInfo> metaData;

		[JsonIgnore]
		public Dictionary<PropertyInfo, HomieField> fieldMetaData;

		[JsonIgnore]
		private static readonly JsonSerializerSettings jsonSettings;

		static HomieMeta()
		{
			jsonSettings = new JsonSerializerSettings
			{
				Formatting = Formatting.None,
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
				NullValueHandling = NullValueHandling.Ignore
			};
		}

		protected HomieMeta()
		{
			metaLink = new Dictionary<string, HomieMeta>();
			metaData = new Dictionary<string, PropertyInfo>();
			fieldMetaData = new Dictionary<PropertyInfo, HomieField>();

			Setup();
		}

		protected void Setup()
		{
			var @type = GetType();

			foreach (var property in @type.GetProperties())
			{
				var homieField = property.GetCustomAttribute<HomieField>();

				if (homieField != null)
				{
					var tag = homieField.tag;

					metaData.Add(tag, property);
					fieldMetaData.Add(property, homieField);
				}
			}
		}

		public string ToJson()
		{
			return JsonConvert.SerializeObject(this, jsonSettings);
		}
	}
}
