using System.Collections;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace R34.Models;

[XmlType("comments")]
public class CommentsContainer : EntityContainer<Comment>
{
    [XmlElement("comment"), JsonPropertyName("comment")]
    public override IEnumerable<Comment> Entities => base.Entities;
}
