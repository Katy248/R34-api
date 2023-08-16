using System.Collections;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace R34.Models;

[XmlType("comments")]
public class CommentsContainer : IEnumerable<Comment>
{
    [XmlElement("comment"), JsonPropertyName("comment")]
    public List<Comment> Comments;

    public IEnumerator<Comment> GetEnumerator() => Comments.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => Comments.GetEnumerator();
}
