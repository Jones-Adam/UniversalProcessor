# UniversalProcessor
A universal data processor

The idea with this library component is to be able to provide it any piece of data and be able to explore that piece of data. I find that very often when dealing with a new piece of packaged information, be it a file format, a database, a zipfile with stuff in it, the first step is unpacking it into some kind of data structure. This unpacking work is unique per piece of information but the process that is followed is very similar for every case.

It usually begins with manually exploring the data, followed by writing some scripts or code to either ingest the data directly or to transform it into something that can be injested.  Sometimes it needs to be injested and processed in an optimal way, othertimes it is not important.

So the aim with this library is to convert data (whatever its source) into a self-describing format that can be explored by software.  This opens up a number of analytics and downstream possibilities.

There are two fundamental assumptions in making this library.  

Firstly, the self-describing data is not about data types but real world "human" concepts.  If you want data types only, we already have an excellent reflection system in .net that covers everything you need.  Obviously there is some overlap, but in general the self-describing approach primarily tries to look at the data the way a human might look at the data.

Secondly, this library is not about performance, its about understanding.  Once data is understood, then I can well imagine a downstream component will be able to use that data to generate optimised code for bulk importing data from one format into another - but that is not this library.  That isn't to say that the code will never be optimised, just that its not a big focus and in the case of conflict the library will always favor clarity over performance.


## Structure

Currently outlined are 2 aspects to the universal processor

- self-describing objects : These classes describe real-world concepts
- Describers : These classes take incoming data and convert them into self-describing objects

Still to be deisgned are

- ReferenceHandlers : These classes handle expanding references like filenames or urls into actual content.
- Analysers : An analyser will provide additional insight into a given piece of data

## milestone goals

Obviously this is subject to change but this is the broad goals.

### version 0.1 - In development

Get the basic structure in place for self-describing objects
Be able to describe - a filename, a url, a word (token), a string of text, an integer, a .net object

### version 0.2 -  In planning

structure for reference handlers
Reference handlers for: binary files, text files, web content 
be able to describe - a floating point number, a fraction, a percentage, a scientific number

### version 0.3

structure for nested content
be able to describe - a list of things, a line of text, a money amount, time, dates
testing goal: describe a basic text file.

### version 0.4

be able to describe - a table of data, a name-value pair, categorised data, positioned text (indented)
testing goal: describe an ini file.

### version 0.5

able to describe - time spans, data ranges, number spans, well known mathematical constants
structure for analytics
testing goal: describe a csv file, describe a tsv file

### version 0.6

analytics: support for data mapping with nominial, ordered nominal and ordinal references
analytics: support for defined interval scales

### version 0.7

be able to describe - hierachical data, 
testing goal: describe an xml file without a schema
analytics: count, mean, std, min, quartiles, max for numberic data types

### version 0.8

support for tar, zip, gz, slob content extraction
testing goal: able to describe a zip file with data in it

### version 0.9

analytics: references between datasets (relationships)
support for sqllite db

### version 1.0

testing goal: describe the top 10 datsets available on kaggle.com
