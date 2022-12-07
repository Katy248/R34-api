using System.Xml.Serialization;

namespace R34.OrriginalApi;

[XmlType("comments")]
public class CommentsContainer
{
    [XmlElement("comment")]
    public List<Comment> Comments;
}
