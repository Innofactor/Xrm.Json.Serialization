# Xrm.Json.Serialization

Library provides simple JSON serialization / deserialization functionality that will process MS Dynamics CRM entities nicely. It provides simple and compact output and requires minimum configuration. Library uses [JSON.NET](https://www.newtonsoft.com/json/) as an engine for its operation.

To enable MS Dynamics CRM specific rules, custom JSON.NET converters need to be registered before performing serialization / deserialization:

```c#
JsonConvert.DefaultSettings = () => new JsonSerializerSettings
{
    Converters = new List<JsonConverter>()
    {
        new EntityCollectionConverter(),
        new EntityConverter(),
        new EntityReferenceConverter(),
        new MoneyConverter(),
        new OptionSetConvertor()
    }
};
```

When all custom converters are registered, it's possible to supply entity to the JSON.NET engine:

```c#
// Creating dummy entity with one OptionSet attribute
var entity = new Entity("test", Guid.NewGuid());
entity.Attributes.Add("attribute1", new OptionSetValue(1));

// Performing conversion
var json = JsonConvert.SerializeObject(entity, Formatting.Indented);
```

Resulting JSON will look like following:

```json
{
  "_reference": "test:16118a60-4346-46ab-8cf7-7e2bd9233b2f",
  "attribute1": {
    "_option": 1
  }
}
```