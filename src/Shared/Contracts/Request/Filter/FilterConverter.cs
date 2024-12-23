namespace Falcon.Contracts;

public class FilterConverter : JsonConverter
{
    public override bool CanWrite => false;

    public override bool CanConvert(Type objectType)
    {
        return typeof(Filter).IsAssignableFrom(objectType);
    }

    public override Filter ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        JObject obj = JObject.Load(reader);
        FilterType filterType = obj.GetValue("kind")?.ToObject<FilterType>() ?? throw new ContractException("Filter Type not specified");
        return filterType switch
        {
            FilterType.Composite => new CompositeFilter(
                obj.GetValue("op")?.ToObject<CompositeOperator>() ?? throw new ContractException("Composite Operator not specified"),
                obj.GetValue("filters")?.ToObject<Filter[]>(serializer) ?? throw new ContractException("Composite Filter filters not specified")
             ),
            FilterType.Field => new FieldFilter(
                obj.GetValue("field")?.ToObject<string>() ?? throw new ContractException("Field not specified"),
                obj.GetValue("op")?.ToObject<FieldOperator>() ?? throw new ContractException("Field Filter operator not specified"),
                obj.GetValue("value")?.ToObject<object>() ?? throw new ContractException("value not specified")
            ),
            FilterType.Unary => new UnaryFilter(
                obj.GetValue("field")?.ToObject<string>() ?? throw new ContractException("Field not specified"),
                obj.GetValue("op")?.ToObject<UnaryOperator>() ?? throw new ContractException("Unary Filter operator not specified")
            ),
            _ => throw new ContractException("Request is not valid")
        };
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
