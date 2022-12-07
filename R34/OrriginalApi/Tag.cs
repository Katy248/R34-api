using System.Xml.Serialization;

namespace R34.OrriginalApi;

[XmlType("tag")]
public class Tag
{
    [XmlAttribute("id")]
    public long Id { get; set; }
    [XmlAttribute("name")]
    public string Name { get; set; }
    [XmlAttribute("type")]
    public int Type { get; set; }
    [XmlAttribute("count")]
    public int Count { get; set; }
    [XmlAttribute("ambiguous")]
    public bool Ambiguous { get; set; }

}
