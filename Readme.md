# Instant Games Bridge
Plugin of [InstantGamesBridge](https://github.com/mewtongames/instant-games-bridge) for Unity.

Join community: https://t.me/instant_games_bridge.

## Usage
+ [Setup](#setup)
+ [Platform](#platform)
+ [Advertisement](#advertisement)
+ [Game Data](#game-data)

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

### Advertisement
```csharp
private void SomeMethod()
{
    // Override minimum delay between interstitials. Default = 60 seconds.
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
### Game Data
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
}
```