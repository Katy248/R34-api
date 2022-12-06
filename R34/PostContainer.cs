using System.Xml.Serialization;

namespace R34;

[XmlType("posts")]
public class PostContainer
{
    [XmlElement("post")]
    public List<Post> Posts;
}
