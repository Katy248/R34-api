using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace R34.Models;

[XmlType("posts")]
public class PostsContainer
{
    [XmlElement("post"), JsonPropertyName("post")]
    public List<Post> Posts;
}
