using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiStone.Converters
{
    public class JsonDecimalConverter : JsonConverter<decimal>
    {

        public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("0.00", CultureInfo.InvariantCulture));
        }

    }
}
