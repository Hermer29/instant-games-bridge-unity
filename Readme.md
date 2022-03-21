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
// Get ID of current platform ('vk', 'yandex', 'mock')
InstantGamesBridge.platform.id
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