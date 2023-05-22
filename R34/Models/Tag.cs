using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace R34.Models;

[XmlType("tag")]
public class Tag
{
    [XmlAttribute("id"), JsonPropertyName("id")]
    public long Id { get; set; }
    [XmlAttribute("name"), JsonPropertyName("name")]
    public string Name { get; set; }
    [XmlAttribute("type"), JsonPropertyName("type")]
    public int Type { get; set; }
    [XmlAttribute("count"), JsonPropertyName("count")]
    public int Count { get; set; }
    [XmlAttribute("ambiguous"), JsonPropertyName("ambiguous")]
    public bool Ambiguous { get; set; }

}
