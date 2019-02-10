
# Assorted.Utils

Most of the time, when I am writing a small program as proof of concept or to test something, I end up writing the same set of helper functions. Finally, I decided to put them all together in a [NuGet package](https://www.nuget.org/packages/Assorted.Utils/) to make my life a bit easier. I hope you find it useful.

## Content

The library contains the following namespaces:

- `Assorted.Utils.Collections`
  - some extensions for generic `IDictionary` and `IEnumerable` objects
  - a generic and thread-safe object pool class
- `Assorted.Utils.Crypto`
  - optimized functions for converting array of bytes to and from hex/base-64 strings
  - MD5, SHA-1, SHA-256, SHA-384 and SHA-512 hash and HMAC objects
- `Assorted.Utils.Dates`
  - various `DateTime` extensions and helper functions
  - classes for generating recurring date patterns
- `Assorted.Utils.Serialization`
  - helper objects for serializing/deserializing object to/from XML, JSON and binary formats
  - functions and extensions for converting primitieve values to and from string in a culture indipendent format
- `Assorted.Utils.Text`
  - various extensions for manipulating strings
  - extension methods for calculating [Damerau-Levenshtein](https://en.wikipedia.org/wiki/Damerau%E2%80%93Levenshtein_distance), [Jaro](https://en.wikipedia.org/wiki/Jaro%E2%80%93Winkler_distance) and [Jaro-Winkler](https://en.wikipedia.org/wiki/Jaro%E2%80%93Winkler_distance) distance between two strings
  - implementation of [Knuth–Morris–Pratt](https://en.wikipedia.org/wiki/Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm) string-search algorithm.
  - a string stream class

You will find the detailed documentation of the library [here](https://github.com/Khojasteh/assorted-utils/blob/master/docs/markdown/_toc.Assorted.Utils.md).

## Contribution

If you have ideas to improve the functionallity or code quality of this library, please don't hesitate to share it here by making a pull request.