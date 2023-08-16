using System.Collections;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace R34.Models;

[XmlType("tags")]
public class TagsContainer : EntityContainer<Tag>
{
    [XmlElement("tag"), JsonPropertyName("tag")]
    public override IEnumerable<Tag> Entities => base.Entities;
}
