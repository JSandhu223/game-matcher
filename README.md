# Game Matcher

A web application, written in Blazor, that allows users to find common games played by their
friends. Users search for their profile via their Steam ID. Then from their displayed friends
list, they can select a friend to compare their game library with. The games that both users
have played are then displayed.

The app utilizes the Steam Web API to retrieve profile information, the friends list, and
game data.

## Project Structure

### Classes

The project uses a **SteamModel** class for data representation. The API calls are made from
the **SteamService** class, which handles all interactions with the Steam Web API.

SteamModel:
- Uses multiple classes for deserializing JSON responses from the Steam Web API. Each class
contains a field corresponding to a property in the JSON response.

SteamService
- Reponsible for making API calls to the Steam Web API and returning the data in a usable
format for the application.
- Manages the HTTP client instance's lifecycle
- Is injected into Blazor components that require the Steam Web API data.

### Components

The application consists of a main component associated with the home page, from which
other components are rendered. The main component handles user input for searching profiles,
fetching the user's friends list, and displaying the common games.

The reusable components include:

- **UserInfo.razor**: a container for displaying the user's information such as their profile
picture, username, and online status.
- **FriendCard.razor**: a bootstrap card that contains the friend's profile picture, username,
and buttons for showing their common games and viewing their Steam profile.
- **GameSlot.razor**: a column of a bootstrap grid row that contains that game's image and name,
along with the link to the game's store page on Steam.
