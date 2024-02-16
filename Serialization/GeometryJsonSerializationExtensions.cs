using Newtonsoft.Json;

namespace MagmaWorks.Geometry.Serialization.Extensions
{
    public static class GeometryJsonSerializationExtensions
    {
        public static string ToJson<T>(this T profile) where T : IGeometry
        {
            return JsonConvert.SerializeObject(profile, Formatting.Indented, GeometryJsonSerializer.Settings);
        }

        public static T FromJson<T>(this string json) where T : IGeometry
        {
            return JsonConvert.DeserializeObject<T>(json, GeometryJsonSerializer.Settings);
        }
    }
}
