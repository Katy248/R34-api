using System.Xml.Serialization;

namespace R34.OrriginalApi;

public class Comment
{
    [XmlAttribute("id")]
    public int Id { get; set; }
    [XmlAttribute("creator_id")]
    public int AuthorId { get; set; }
    [XmlAttribute("body")]
    public string Body { get; set; }
    [XmlAttribute("post_id")]
    public int PostId { get; set; }
    [XmlAttribute("created_at")]
    public string Creation { get; set; }
}
