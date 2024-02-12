using CsvHelper.Configuration.Attributes;

namespace PostcodeLoader;

public class PostcodeRecord
{
    [Name("pcd")]
    public string? Postcode
    {
        get => _postcode;
        set => _postcode = value.Replace(" ", string.Empty);
    }

    private string? _postcode;

    [Name("lat")]
    public double Latitude { get; set; }

    [Name("long")]
    public double Longitude { get; set; }
}
