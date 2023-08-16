using System.Collections;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace R34.Models;

[XmlType("posts")]
public class PostsContainer : EntityContainer<Post>
{
    [XmlElement("post"), JsonPropertyName("post")]
    public override IEnumerable<Post> Entities => base.Entities;
}
