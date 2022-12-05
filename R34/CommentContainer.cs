using System.Xml.Serialization;

namespace R34;

[XmlType("comments")]
public class CommentContainer
{
    [XmlElement("comment")]
    public List<Comment> Comments;
}
