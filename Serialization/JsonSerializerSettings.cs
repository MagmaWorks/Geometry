using Newtonsoft.Json;

namespace MagmaWorks.Geometry.Serialization
{
    public static class GeometryJsonSerializer
    {
        public static JsonSerializerSettings Settings
        {
            get
            {
                var settings = new JsonSerializerSettings
                {
                    Converters = {
                        new OasysUnits.Serialization.JsonNet.OasysUnitsIQuantityJsonConverter(),
                    },
                    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
                };
                return settings;
            }
        }
    }
}
