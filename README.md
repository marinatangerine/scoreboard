## Table of Contents
1. [General Info](#general-info)
2. [Technologies](#technologies)
3. [Assumptions](#assumptions)

### General Info
***
Implementation of simple score board solution using TDD and class library.
Operations:
* Start a game. Two contenders and initial score 0-0.
* Finish a game. Remove the match from the score board.
* Update score. 
* List of matches by total score and most recently added.

## Technologies
***
* [.Net Core 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0): Version 6.0 

## Assumptions
***
* When updating a match, a team's score has not been validated if it is higher than current one, because goals can be disallowed, data can arrive with delay, etc.
* When adding or updating a match, the moment is updated inside the match class, to obtain the most recently updated.