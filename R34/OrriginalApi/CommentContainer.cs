using System.Xml.Serialization;

namespace R34.OrriginalApi;

[XmlType("comments")]
public class CommentContainer
{
    [XmlElement("comment")]
    public List<Comment> Comments;
}
