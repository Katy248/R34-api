using System.Drawing;
using System.Xml.Serialization;

namespace R34;

[XmlType("post")]
public class Post
{
    [XmlAttribute("id")]
    public int Id { get; set; }
    [XmlAttribute("md5")]
    public string Hash { get; set; }
    [XmlAttribute("score")]
    public int Score { get; set; }
    public Size Size => new Size(width, height);
    [XmlAttribute("file_url")]
    public string Image { get; set; }
    [XmlAttribute("creator_id")]
    public string Owner { get; set; }

    public IEnumerable<string> TagsSequence => tags.Split(' ');
    public DateTime CreationDate => DateTime.Parse(created_at);

    public static int GetRandomPostId => Random.Shared.Next(1, 8_000_000);

    #region XML specific
    [XmlAttribute(nameof(width))]
    public int width { get; set; }
    [XmlAttribute(nameof(height))]
    public int height { get; set; }
    [XmlAttribute(nameof(tags))]
    public string tags { get; set; }
    [XmlAttribute(nameof(created_at))]
    public string created_at { get; set; }
    #endregion
}
