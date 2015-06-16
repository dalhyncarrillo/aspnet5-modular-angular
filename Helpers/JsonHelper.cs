using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AngularPlugin.Helpers
{
	public static class JsonHelper
	{
		public static string Convert(object obj)
		{
			var camelCaseFormatter = new JsonSerializerSettings();
	        camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
			return JsonConvert.SerializeObject(obj, camelCaseFormatter);
		}
	}
}