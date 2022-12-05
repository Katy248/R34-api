using System.Drawing;

namespace R34;

public class Post
{
    public int Id { get; set; }
    public string Hash { get; set; }
    public int Score { get; set; }
    public Size Size => new Size(width, height);
    public string Image => file_url;
    public string Owner { get; set; }
    public IEnumerable<string> TagsSequence => tags.Split(' ');

    public static int GetRandomPostId => Random.Shared.Next(1, 8_000_000);

    #region JSON specific
    public string file_url { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    public string tags { get; set; }
    #endregion
}
