namespace R34;

public class ICame
{
    public string CharacterName { get; set; }
    public int Count { get; set; }
    public string TagUrl => $"https://rule34.xxx/index.php?page=post&s=list&tags={CharacterName.Replace(' ', '_')}";
}
