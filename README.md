# PostcodeTest

This is some performance testing related to a {Postcode Search API I have build](https://github.com/Dodecahedrane/PostcodeApi)

The API gets its data from a CSV file, this is loaded into memory when the server starts, as loading this from disk (~2.6M Records) on each request would increase the response times to single digit seconds. Originally the data was loaded into a HashSet - this was chosen because someone once told me it was fast, but I have built this set of benchmarks to test that.

## The test

This tests loads the CSV into memory, it then searches for several postcodes, checks that they all return data, and repeats this a number of times. It returns the total run time, and the average time per look up.

This is performed on three types of collection, HashSet, List and Dictionary.

## Hypothesis 

The dictionary will probably be the fastest, I am unsure as to if the List or HashSet will be better.

## The results

For 1,000 Runs or 11,000 Look Ups

### List

- 94.7 Seconds
- 8.61 ms/Lookup

### HashSet

- 99.5 Seconds
- 9.04 ms/Lookup

### Dictionary

- 0.00002 Seconds
- ~0 ms/Lookup

1,100,000,000 Lookups = 17.2 Seconds of total runtime

## Conclusion

Dictionaries are a lot faster, no surprise there.

The original HashSet basic postcode search implementation was lifted from a second year uni project, I should probably have had a think about that implementation when I built this project. In hindsight this is obvious. At least I now know for sure that my implementation is as fast as it can be. (or at least, as fast as it reasonably needs to be)
