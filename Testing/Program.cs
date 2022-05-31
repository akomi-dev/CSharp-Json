// See https://aka.ms/new-console-template for more information

using System;
using System.Runtime.Serialization;
using CSharpJson;

namespace Testing;

internal class Program
{
    static void Main(string[] args)
    {
        // Json File Example

        string filePath = "C:\\Users\\snowy\\Documents\\GitHub\\CSharp-Json\\Testing\\test.json";
        dynamic file = File.ReadAllText(filePath);
        var deserialized = JsonConv<AnimeInfo>.Deserialize(file);

        Console.WriteLine(deserialized?.Name);
        deserialized.Name = "False";
        Console.WriteLine(deserialized?.Name);
        deserialized.Name = "Erased"; // name back to default
        Console.WriteLine(deserialized?.Author);
        Console.WriteLine(deserialized?.Genre);

        var serialized = JsonConv<AnimeInfo>.Serialize(deserialized);
        Console.WriteLine(serialized);

        JsonConv<AnimeInfo>.Write(serialized, filePath);

        Console.WriteLine();
        Console.WriteLine();


        // Class Obj Example

        var animeInfo = new AnimeInfo
        {
            Name = "Black Clover",
            Author = "Yuuki Tabata",
            Genre = "Action"
        };

        var _serialized = JsonConv<AnimeInfo>.Serialize(animeInfo);

        var _deserialized = JsonConv<AnimeInfo>.Deserialize(_serialized);

        Console.WriteLine(_serialized);
        Console.WriteLine();
        Console.WriteLine(_deserialized?.Name);
        Console.WriteLine(_deserialized?.Author);
        Console.WriteLine(_deserialized?.Genre);
    }
}

[DataContract]
internal class AnimeInfo
{
    [DataMember]
    public string? Name { get; set; }

    [DataMember]
    public string? Author { get; set; }

    [DataMember]
    public string? Genre { get; set; }
}