using System.Text.Json;

namespace NetSampleArch.Infra.CrossCutting.ExtensionMethods
{
    public static class ObjectExtensionMethods
    {
        public static string SerializeToJson(this object obj)
        {
            return JsonSerializer.Serialize(obj, NetSampleArch.Infra.CrossCutting.Configuration.Configuration.JsonSerializerOptions);
        }
    }
}
