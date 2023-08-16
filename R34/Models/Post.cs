using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace R34.Models;

[XmlType("post")]
public class Post
{
    [XmlAttribute("id"), JsonPropertyName("id")]
    public long Id { get; set; }
    [XmlAttribute("md5"), JsonPropertyName("md5")]
    public string Hash { get; set; }
    [XmlAttribute("score"), JsonPropertyName("score")]
    public int Score { get; set; }
    [XmlAttribute("file_url"), JsonPropertyName("file_url")]
    public string Image { get; set; }
    [XmlAttribute("creator_id"), JsonPropertyName("creator_id")]
    public string Owner { get; set; }

    public IEnumerable<string> TagsSequence => Tags.Split(' ');

    public static int GetRandomPostId => Random.Shared.Next(1, 8_000_000);

    [JsonPropertyName("width")]
    public int Width { get; set; }
    [JsonPropertyName("height")]
    public int Height { get; set; }
    [JsonPropertyName("tags")]
    public string Tags { get; set; }
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }
}
