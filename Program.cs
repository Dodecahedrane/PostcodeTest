// See https://aka.ms/new-console-template for more information
using PostcodeLoader;
using System.Diagnostics;

List<string> postcodes = ["PL48AA", "PL47LJ", "PL11AE", "BA21AE"];
int runs = 10;

Console.WriteLine("Postcode Performance Test");

void HashSetTest()
{
    Console.WriteLine("HashSet Test:");

    // Load HashSet
    PostcodeLoaderHashSet LoaderHashSet = new("..\\..\\..\\Data\\PostcodesLatLong.csv");

    // Verify Number of Records Loaded
    Console.WriteLine($"Count Of Records: {LoaderHashSet.Records.Count}");

    // Initialize stopwatch
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    // Benchmark
    for (int i = 0; i < runs; i++)
    {
        foreach (string postcode in postcodes)
        {
            PostcodeRecord? res = LoaderHashSet.Records.FirstOrDefault(
                    x => x.Postcode == postcode
                    );
            if (res == null)
            {
                throw new Exception("Error In Search");
            }
        }
    }

    stopwatch.Stop();
    TimeSpan elapsedTime = stopwatch.Elapsed;
    Console.WriteLine($"HashSet Elapsed Time: {elapsedTime.TotalSeconds} Seconds");
    Console.WriteLine($"HashSet Elapsed Time Per Search {elapsedTime.TotalMilliseconds / (postcodes.Count * runs):F2} milliseconds");
}

void ListTest()
{
    Console.WriteLine("List Test:");

    // Load List
    PostcodeLoaderList LoaderList = new("..\\..\\..\\Data\\PostcodesLatLong.csv");

    // Verify Number of Records Loaded
    Console.WriteLine($"Count Of Records: {LoaderList.Records.Count}");

    // Initialize stopwatch
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    // Benchmark
    for (int i = 0; i < runs; i++)
    {
        foreach (string postcode in postcodes)
        {
            PostcodeRecord? res = LoaderList.Records.FirstOrDefault(
                    x => x.Postcode == postcode
                    );
            if (res == null)
            {
                throw new Exception("Error In Search");
            }
        }
    }

    stopwatch.Stop();
    TimeSpan elapsedTime = stopwatch.Elapsed;
    Console.WriteLine($"List Elapsed Time: {elapsedTime.TotalSeconds} Seconds");
    Console.WriteLine($"List Elapsed Time Per Search {elapsedTime.TotalMilliseconds / (postcodes.Count * runs):F2} milliseconds");
}

void DictionaryTest()
{
    Console.WriteLine("Dictionary Test:");

    // Load HashSet
    PostcodeLoaderDictionary LoaderDict = new("..\\..\\..\\Data\\PostcodesLatLong.csv");

    // Verify Number of Records Loaded
    Console.WriteLine($"Count Of Records: {LoaderDict.Records.Count}");


    // Initialize stopwatch
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    // Benchmark
    for (int i = 0; i < runs; i++)
    {
        foreach (string postcode in postcodes)
        {
            PostcodeRecord? res = LoaderDict.Records[postcode];

            if (res == null)
            {
                throw new Exception("Error In Search");
            }
        }
    }


    stopwatch.Stop();
    TimeSpan elapsedTime = stopwatch.Elapsed;
    Console.WriteLine($"List Elapsed Time: {elapsedTime.TotalSeconds} Seconds");
    Console.WriteLine($"List Elapsed Time Per Search {elapsedTime.TotalMilliseconds / (postcodes.Count * runs):F2} milliseconds");
}


// Run Tests


DictionaryTest();

ListTest();

HashSetTest();








