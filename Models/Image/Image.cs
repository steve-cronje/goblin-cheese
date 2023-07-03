namespace goblin_cheese.Models.Image;

public class Image 
{
    public string? ContentType {get;set;}
    public byte[]? Data {get;set;}
    public string getData()
    {
        return this.Data != null ? Convert.ToBase64String(this.Data) : "";
    }
}