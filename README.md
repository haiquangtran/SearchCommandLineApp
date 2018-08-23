# SearchCommandLineApp
A simple command line application that does an exact match on field values for .json data and returns the results as JSON objects.

# Usage
1. In your terminal, navigate to the directory of the SearchCommandLineApp.exe.
2. Use this tool by using the following syntax in the terminal: "./SearchCommandLineApp -search "search-term" -dataset <organisations | users | tickets> [organisations | users | tickets] [organisations | users | tickets]"

# Syntax
### ./SearchCommandLineApp -search "search-term" -dataset <organisations | users | tickets>
- "Search-term": is the value you are looking for within the JSON object i.e. "John"
- <organisations | users | tickets>: Represents that it is required to specify one of these datasets.
- [organisations | users | tickets]: Represents that it is optional to specify one of these datasets.
- Note:
  - If you specify organisations, it will use the dataset organizations.json file.
  - If you specify users, it will use the dataset users.json file.
  - If you specify tickets, it will use the dataset tickets.json file.

## Example Usages:
- ./SearchCommandLineApp.exe -search "" -dataset users
  - This command will display all the JSON objects that have an empty string value from the users.json file dataset.
- ./SearchCommandLineApp.exe -search null -dataset organisations users tickets
  - This command will display all the JSON objects that have a null value for the following dataset files: organizations.json, users.json, and tickets.json.
- ./SearchCommandLineApp.exe -search "Hendricks" -dataset users tickets
  - This command will display all the JSON objects that have a value equal to "Hendricks" for the following dataset files: users.json, and tickets.json.
- ./SearchCommandLineApp.exe -search "129" -dataset organisations users tickets
  - This command will display all the JSON objects that have a value equal to 129 for the following dataset files: organizations.json, users.json, and tickets.json. 

# Developer Requirements 
- .NET Framework 4.7.1
- Visual Studio 2017 (To debug)
- Windows OS
## Compilation
- To compile, run, debug, or see the code - open the SearchCommandLineApp.sln in VS 2017 

# Approach
- Reads the .JSON files and converts them into C# (POCO) Objects
- Uses Reflection to go through all the properties of the Object and searches for an **exact** match on the value
- Returns all the JSON objects that have the **exact** match on the property value.
- I used this method because it was simple, maintainable, extensible with the tradeoff being performance.
- Used Repository Pattern to make it extensible, in case a database would be used in the future.
- Thought of using the Strategy Pattern to utilize different search strategies for each data class (i.e. ticket, user, organisation) but in the end it was not needed because the search strategy was the same for each class.

# Future Extensions
- Create a client UI to be able to upload, edit, delete .json files to be searched on. 
- Store the models in a database and perform queries on it instead. The database would be running in the background and the command line would be able to utilize it.
- Add a cache layer using MemoryCache to speed up reptitive searches.
- Extend the command line tool to take in field parameters so you can search on a specific field
- Allow users to specify .json files to search on
- Add in Fuzzy Search

# Other Approach Considerations:

### Storing in a Document store
- Store the JSON objects in a document store such as MongoDB 
- The command line tool would then query and search the JSON by issuing queries to the document store
- Another option could be utilizing Elastic Search for the lookups and searches.
- You could add indexes on fields to speed up lookups
- However, this would mean you need to stand up servers and it would need to be running in the background. 
### Use a Map:
- Store values in a map, where values act as a index (map key) to a list of JSON objects (map value). 
- This would provide efficient lookup's at O(1) but the disadvantage is that the map would take long to generate and it would not be able to cater for partial matches.
### Use JSONPath
- This is a possibility but would be too slow and difficult to maintain and read. 


