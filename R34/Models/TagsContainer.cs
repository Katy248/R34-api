using System.Collections;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace R34.Models;

[XmlType("tags")]
public class TagsContainer : IEnumerable<Tag>
{
    [XmlElement("tag"), JsonPropertyName("tag")]
    public List<Tag> Tags { get; set; }

    public IEnumerator<Tag> GetEnumerator() => Tags.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => Tags.GetEnumerator();
}
