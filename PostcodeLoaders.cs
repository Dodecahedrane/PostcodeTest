using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using System.Formats.Asn1;

namespace PostcodeLoader;

public class PostcodeLoaderHashSet
{
    public HashSet<PostcodeRecord> Records { get; private set; }

    public PostcodeLoaderHashSet(string path)
    {
        Records = GetPostcodes(path);
    }

    private static HashSet<PostcodeRecord> GetPostcodes(string path)
    {
        try
        {
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
            return csv.GetRecords<PostcodeRecord>().ToHashSet();
        }
        catch (Exception ex)
        {
            throw new FailedToLoadPostcodeData("Failed To Load The Postcode Data: ", ex);
        }
    }
}

public class PostcodeLoaderList
{
    public List<PostcodeRecord> Records { get; private set; }

    public PostcodeLoaderList(string path)
    {
        Records = GetPostcodes(path);
    }

    private static List<PostcodeRecord> GetPostcodes(string path)
    {
        try
        {
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
            return csv.GetRecords<PostcodeRecord>().ToList();
        }
        catch (Exception ex)
        {
            throw new FailedToLoadPostcodeData("Failed To Load The Postcode Data: ", ex);
        }
    }
}

public class PostcodeLoaderDictionary
{
    public Dictionary<string, PostcodeRecord> Records { get; private set; }

    public PostcodeLoaderDictionary(string path)
    {
        Records = GetPostcodes(path);
    }

    private static Dictionary<string, PostcodeRecord> GetPostcodes(string path)
    {
        try
        {
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));

            // Read the records into a list
            List<PostcodeRecord> records = csv.GetRecords<PostcodeRecord>().ToList();

            // Create a dictionary to hold the postcode records
            var postcodeDictionary = new Dictionary<string, PostcodeRecord>();

            // Iterate through the records and populate the dictionary
            foreach (var record in records)
            {
                if (!string.IsNullOrEmpty(record.Postcode))
                {
                    // Use the postcode as the key
                    postcodeDictionary[record.Postcode] = record;
                }
            }

            return postcodeDictionary;
        }
        catch (Exception ex)
        {
            throw new FailedToLoadPostcodeData("Failed To Load The Postcode Data: ", ex);
        }
    }
}





public class FailedToLoadPostcodeData : Exception
{
    public FailedToLoadPostcodeData() { }

    public FailedToLoadPostcodeData(string message) : base(message) { }

    public FailedToLoadPostcodeData(string message, Exception innerException) : base(message, innerException) { }
}