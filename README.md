# Game Matcher

A web application, written in Blazor, that allows users to find common games played by their
friends. Users search for their profile via their Steam ID. Then from their displayed friends
list, they can select a friend to compare their game library with. The games that both users
have played are then displayed.

The app utilizes the Steam Web API to retrieve profile information, the friends list, and
game data.

## Structure

The project uses a **SteamModel** class for data representation. The API calls are made from
the **SteamService** class, which handles all interactions with the Steam Web API.

SteamModel:
- Uses multiple classes for deserializing JSON responses from the Steam Web API. Each class
contains a field corresponding to each property in the JSON response.

SteamService
- Reponsible for making API calls to the Steam Web API and returning the data in a usable
format for the application.
- Manages the HTTP client instance's lifecycle
- Is injected into Blazor components
