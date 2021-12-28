# Scripts-Repo
Repository for KTU Game Unity scripts

## Coding Style
* Use https://www.dofactory.com/reference/csharp-coding-standards as a reference. Setup your IDE to apply these rules.
* Use 4 spaces instead of a tab.
* Brackets can be ommited if the body consists of one line.
    ```C#
    // Correct
    if (clause)
    {
        // Statements
    }
    // Also correct
    if (clause)
        // Statement
    // Avoid
    if (clause) { /* Statement */ }
    ```
* Access modifiers should be typed explicitly.
    ```C#
    // Correct
    internal class Example
    {
        private int _number;
    }
    // Avoid
    class Example
    {
        int _number;
    }
    ```
* Private variables should be named with `_camelCase`.
    ```C#
    // Correct
    private int _number;
    // Avoid
    private int number;
    private int Number;
    ```
* Static variables and constants should be named with `PascalCase`.
    ```C#
    // Correct
    public static string ApiUrl;
    public const int Year = 2021;
    // Avoid
    public static string apiUrl;
    public const int year = 2021;
    ```
    
* Public fields and methods should have `public` access modifier.

## Git Workflow

* For every feature/bug fix - new branch needs to be created
    * feature - `feature/`
    * bug fix / fixes - `fix/`
* Merge request needs at least 1 review to be approved
* Merge request is only created when work with branch is done 
    * if you want to check if there is some kind of chuck comments - just create a merge request with `WIP:` at the start
* All discussions are to be resolved before merging
* Branch needs to be deleted after merge request is merged
* Commit message needs to be descriptive 
* All commits should start with a verb in imperative form
  * Good: `Add feature`
  * Bad: `feature added, bug fix, minor change.`
  
  
## IDE 
* [Microsoft Visual Studio 2019](https://visualstudio.microsoft.com/vs/) is highly recommended.
* [Resharper extension](https://www.jetbrains.com/resharper/) is highly recommended.


