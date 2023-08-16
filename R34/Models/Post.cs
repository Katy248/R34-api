using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace R34.Models;

[XmlType("post")]
public class Post
{
    [XmlAttribute("id")] public long Id { get; set; }
    [XmlAttribute("parent_id")] public string ParentId { get; set; }
    [XmlAttribute("md5")] public string Hash { get; set; }
    [XmlAttribute("score")] public int Score { get; set; }
    [XmlAttribute("rating")] public string Rating { get; set; }
    [XmlAttribute("creator_id")] public string CreatorId { get; set; }
    [XmlAttribute("tags")] public string Tags { get; set; }
    [XmlAttribute("created_at")] public string CreatedAt { get; set; }
    [XmlAttribute("change")] public string Change { get; set; }
    [XmlAttribute("has_children")] public bool HasChildren { get; set; }
    [XmlAttribute("has_notes")] public bool HasNotes{ get; set; }
    [XmlAttribute("has_comments")] public bool HasComments{ get; set; }
    [XmlAttribute("source")] public string Source{ get; set; }
    [XmlAttribute("status")] public string Status{ get; set; }

    #region File data

    [XmlAttribute("file_url")] public string FileUrl { get; set; }
    [XmlAttribute("width")] public int Width { get; set; }
    [XmlAttribute("height")] public int Height { get; set; }

    [XmlAttribute("sample_url")] public string SampleUrl { get; set; }
    [XmlAttribute("sample_width")] public int SampleWidth { get; set; }
    [XmlAttribute("sample_height")] public int SampleHeight { get; set; }

    [XmlAttribute("preview_url")] public string PreviewUrl { get; set; }
    [XmlAttribute("preview_width")] public int PreviewWidth { get; set; }
    [XmlAttribute("preview_height")] public int PreviewHeight { get; set; }

    #endregion

    public IEnumerable<string> TagsSequence => Tags.Split(' ');

    #region Static

    public static int GetRandomPostId => Random.Shared.Next(1, 8_000_000);

    #endregion

    #region Not matched
    /// <summary>
    /// <b>Only in JSON.</b>
    /// </summary>
    [XmlAttribute("owner"), JsonPropertyName("owner")] public string Owner { get; set; }
    #endregion
}
