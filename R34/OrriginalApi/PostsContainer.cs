using System.Xml.Serialization;

namespace R34.OrriginalApi;

[XmlType("posts")]
public class PostsContainer
{
    [XmlElement("post")]
    public List<Post> Posts;
}
