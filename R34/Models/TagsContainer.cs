using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace R34.Models;

[XmlType("tags")]
public class TagsContainer
{
    [XmlElement("tag"), JsonPropertyName("tag")]
    public List<Tag> Tags { get; set; }
}
