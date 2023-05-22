using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace R34.Models;

[XmlType("comments")]
public class CommentsContainer
{
    [XmlElement("comment"), JsonPropertyName("comment")]
    public List<Comment> Comments;
}
