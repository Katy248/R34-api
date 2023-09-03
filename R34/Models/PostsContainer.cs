using System.Collections;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace R34.Models;

[XmlType("posts")]
public class PostsContainer
{
    [XmlElement("post"), JsonPropertyName("post")]
    public List<Post> Entities { get; set; } = new List<Post>();
    [XmlAttribute(AttributeName = "count")]
    public int PostsCount { get; set; }
    [XmlAttribute("offset")]
    public int Offset { get; set; }
}
