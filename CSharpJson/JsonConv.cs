using System.Runtime.Serialization.Json;
using System.Text;

namespace CSharpJson;

public static class JsonConv<ClassType> where ClassType : class
{
    /// <summary>
    /// Serializes an object to JSON
    /// </summary>
    public static string Serialize(ClassType instance)
    {
        var serializer = new DataContractJsonSerializer(typeof(ClassType));
        using var stream = new MemoryStream();
        serializer.WriteObject(stream, instance);
        return Encoding.Default.GetString(stream.ToArray());
    }

    /// <summary>
    /// Deserializes an object from JSON string
    /// </summary>
    public static ClassType? Deserialize(string json)
    {
        using var stream = new MemoryStream(Encoding.Default.GetBytes(json));
        var serializer = new DataContractJsonSerializer(typeof(ClassType));
        return serializer.ReadObject(stream) as ClassType;
    }

    public static void Write(string serializedJson, string filepath)
    {
        File.WriteAllText(filepath, serializedJson);
    }
}