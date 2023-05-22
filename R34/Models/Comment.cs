using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace R34.Models;

public class Comment
{
    [XmlAttribute("id"), JsonPropertyName("id")]
    public int Id { get; set; }
    [XmlAttribute("creator_id"), JsonPropertyName("creator_id")]
    public int AuthorId { get; set; }
    [XmlAttribute("body"), JsonPropertyName("body")]
    public string Body { get; set; }
    [XmlAttribute("post_id"), JsonPropertyName("post_id")]
    public int PostId { get; set; }
    [XmlAttribute("created_at"), JsonPropertyName("created_at")]
    public string Creation { get; set; }
}
