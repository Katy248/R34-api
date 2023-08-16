using System.Collections;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace R34.Models;

[XmlType("posts")]
public class PostsContainer : IEnumerable<Post>
{
    [XmlElement("post"), JsonPropertyName("post")]
    public List<Post> Posts { get; set; }

    public IEnumerator<Post> GetEnumerator() => Posts.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => Posts.GetEnumerator();
}
