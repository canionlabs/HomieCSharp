using System;
using System.Collections.Generic;
using System.Reflection;
using Homie.exchange;

namespace Homie.utils
{
	public abstract class HomieMeta
	{
		public Dictionary<string, HomieMeta> metaLink;
		public Dictionary<string, PropertyInfo> metaData;
		public Dictionary<PropertyInfo, HomieField> fieldMetaData;

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

					Console.WriteLine("Creating property: {0}", tag);
				}
			}
		}
	}
}
