using System.Collections;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace R34.Models;

[XmlRoot(ElementName = "comments")]
public class CommentsContainer
{
    [XmlElement("comment"), JsonPropertyName("comment")]
    public List<Comment> Entities { get; set; }
}
