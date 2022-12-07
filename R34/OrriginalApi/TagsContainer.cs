using System.Xml.Serialization;

namespace R34.OrriginalApi;

[XmlType("tags")]
public class TagsContainer
{
    [XmlElement("tag")]
    public List<Tag> Tags { get; set; }
}
