using System.Text.Json;

namespace NetSampleArch.Infra.CrossCutting.ExtensionMethods
{
    public static class StringExtensionMethods
    {
        public static T DeserializeFromJson<T>(this string jsonString)
        {
            return JsonSerializer.Deserialize<T>(jsonString, NetSampleArch.Infra.CrossCutting.Configuration.Configuration.JsonSerializerOptions);
        }
    }
}
