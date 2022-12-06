using System.Drawing;
using System.Xml.Serialization;

namespace R34;

[XmlType("post")]
public class Post
{
    [XmlAttribute("id")]
    public long Id { get; set; }
    [XmlAttribute("md5")]
    public string Hash { get; set; }
    [XmlAttribute("score")]
    public string Score { get; set; }
    //public Size Size => new Size(width, height);
    [XmlAttribute("file_url")]
    public string Image { get; set; }
    [XmlAttribute("creator_id")]
    public string Owner { get; set; }

    public IEnumerable<string> TagsSequence => tags.Split(' ');

    public static int GetRandomPostId => Random.Shared.Next(1, 8_000_000);

    #region XML specific
    [XmlAttribute(nameof(width))]
    public string width { get; set; }
    [XmlAttribute(nameof(height))]
    public string height { get; set; }
    [XmlAttribute(nameof(tags))]
    public string tags { get; set; }
    [XmlAttribute(nameof(created_at))]
    public string created_at { get; set; }
    #endregion
}
