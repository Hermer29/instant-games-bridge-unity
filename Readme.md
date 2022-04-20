# Instant Games Bridge
Plugin of [InstantGamesBridge](https://github.com/mewtongames/instant-games-bridge) for Unity.

Roadmap: https://trello.com/b/NjF29vTW.

Join community: https://t.me/instant_games_bridge.

## Usage
+ [Before Setup](#before-setup)
+ [Setup](#setup)
+ [Platform](#platform)
+ [Player](#player)
+ [Game](#game)
+ [Advertisement](#advertisement)
+ [Social](#social)

### Before Setup
**Optional.** Before call the "Initialize" method, you can change InstantGamesBridge/Resources/InstantGamesBridgeSettings file.

### Setup
First you need to initialize the SDK:
```csharp
private void Start()
{
    InstantGamesBridge.Initialize(result =>
    {
        if (result)
        {
            // Initialized. You can use other methods.
        }
        else
        {
            // Error
        }
    });
}
```
### Platform
```csharp
// ID of current platform ('vk', 'yandex', 'mock')
InstantGamesBridge.platform.id

// If platform provides information - this is the user language on platform. 
// If not - this is the language of the user's browser.
InstantGamesBridge.platform.language

// The value of the payload parameter from the url. Examples:
// VK: vk.com/app8056947#your-info
// Yandex: yandex.com/games/play/183100?payload=your-info
// Mock: site.com/game?payload=your-info
InstantGamesBridge.platform.payload
```

### Player
```csharp
private void SomeMethod()
{
    InstantGamesBridge.player.isAuthorizationSupported

    InstantGamesBridge.player.isAuthorized

    // If player is authorized
    InstantGamesBridge.player.id

    // If player is authorized (Yandex: and allowed access to this information)
    InstantGamesBridge.player.name
    InstantGamesBridge.player.photos // List of player photos, sorted in order of increasing photo size

    // If authorization is supported and player is not authorized
    InstantGamesBridge.player.Authorize(result =>
    {
        if (result)
        {
            // Success
        }
        else
        {
            // Error
        }
    });
}
```

### Game
```csharp
private void SomeMethod()
{
    // Get game data from storage
    InstantGamesBridge.game.GetData("key", data =>
    {
        // Data has been received and you can work with them
        // data = null if there is no data for this key
    });

    // Set game data in storage
    InstantGamesBridge.game.SetData("key", "value", result =>
    {
        if (result)
        {
            // Success
        }
        else
        {
            // Error
        }
    });

    // Delete game data from storage
    InstantGamesBridge.game.DeleteData("key", result =>
    {
        if (result)
        {
            // Success
        }
        else
        {
            // Error
        }
    });
}
```

### Advertisement
```csharp
private void SomeMethod()
{
    InstantGamesBridge.advertisement.minimumDelayBetweenInterstitial // Default = 60 seconds

    // You can override minimum delay
    var seconds = 30;
    InstantGamesBridge.advertisement.SetMinimumDelayBetweenInterstitial(seconds);

    InstantGamesBridge.advertisement.interstitialStateChanged += state => { Debug.Log($"Interstitial state: {state}"); };
    InstantGamesBridge.advertisement.rewardedStateChanged += state => { Debug.Log($"Rewarded state: {state}"); };

    // Optional parameter
    var ignoreDelay = true; // Default = false
    // Request to show interstitial ads
    InstantGamesBridge.advertisement.ShowInterstitial(ignoreDelay, result =>
    {
        if (result)
        {
            // Success
        }
        else
        {
            // Error
        }
    });

    // Request to show rewarded video ads
    InstantGamesBridge.advertisement.ShowRewarded(result =>
    {
        if (result)
        {
            // Success
        }
        else
        {
            // Error
        }
    });
}
```

### Social
```csharp
private void SomeMethod()
{
    // VK: true
    // Yandex: false
    InstantGamesBridge.social.isShareSupported
    InstantGamesBridge.social.isJoinCommunitySupported
    InstantGamesBridge.social.isInviteFriendsSupported
    InstantGamesBridge.social.isCreatePostSupported
    InstantGamesBridge.social.isAddToFavoritesSupported

    // VK, Yandex: partial supported
    InstantGamesBridge.social.isAddToHomeScreenSupported

    InstantGamesBridge.social.Share(result =>
    {
        if (result)
        {
            // Success
        }
        else
        {
            // Error
        }
    });

    // For VK - you need to fill the group id in InstantGamesBridgeSettings
    InstantGamesBridge.social.JoinCommunity(result =>
    {
        if (result)
        {
            // Success
        }
        else
        {
            // Error
        }
    });

    InstantGamesBridge.social.InviteFriends(result =>
    {
        if (result)
        {
            // Success
        }
        else
        {
            // Error
        }
    });

    InstantGamesBridge.social.CreatePost(text, result =>
    {
        if (result)
        {
            // Success
        }
        else
        {
            // Error
        }
    });

    InstantGamesBridge.social.AddToHomeScreen(result =>
    {
        if (result)
        {
            // Success
        }
        else
        {
            // Error
        }
    });

    InstantGamesBridge.social.AddToFavorites(result =>
    {
        if (result)
        {
            // Success
        }
        else
        {
            // Error
        }
    });
}
```