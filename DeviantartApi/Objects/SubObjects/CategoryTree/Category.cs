using Newtonsoft.Json;

public class Category
{
    [JsonProperty("catpath")]
    public string Catpath { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("has_subcategory")]
    public bool HasSubcategory { get; set; }

    [JsonProperty("parent_catpath")]
    public string ParentCatpath { get; set; }
}