# Instant Games Bridge
Plugin of [InstantGamesBridge](https://github.com/mewtongames/instant-games-bridge) for Unity.

Roadmap: https://trello.com/b/NjF29vTW.

Join community: https://t.me/instant_games_bridge.

## Usage
+ [Platform](#platform)
+ [Device](#device)
+ [Player](#player)
+ [Game](#game)
+ [Storage](#storage)
+ [Advertisement](#advertisement)
+ [Social](#social)
+ [Leaderboard](#leaderboard)

### Platform
```csharp
// ID of current platform ('vk', 'yandex', 'mock')
Bridge.platform.id

// If platform provides information - this is the user language on platform. 
// If not - this is the language of the user's browser.
Bridge.platform.language

// The value of the payload parameter from the url. Examples:
// VK: vk.com/app8056947#your-info
// Yandex: yandex.com/games/play/183100?payload=your-info
// Mock: site.com/game?payload=your-info
Bridge.platform.payload

// Message to the platform. Supported only on CrazyGames.
// Possible values: 'GameLoadingStarted', 'GameLoadingStopped', 'GameplayStarted', 'GameplayStopped', 'PlayerGotAchievement'
Bridge.platform.SendMessage(message)
```

### Device
```csharp
// 'mobile', 'tablet', 'desktop', 'tv'
Bridge.device.type
```

### Player
```csharp
private void SomeMethod()
{
    Bridge.player.isAuthorizationSupported

    Bridge.player.isAuthorized

    // If player is authorized
    Bridge.player.id

    // If player is authorized (Yandex: and allowed access to this information)
    Bridge.player.name
    Bridge.player.photos // List of player photos, sorted in order of increasing photo size

    // If authorization is supported and player is not authorized
    var yandexScopes = true; // Request access to name and photo, default = true
    var authorizeYandexOptions = new AuthorizeYandexOptions(yandexScopes); // Optional
    Bridge.player.Authorize(
        success =>
        {
            if (success)
            {
                // Success
            }
            else
            {
                // Error
            }
        },
        authorizeYandexOptions);
}
```

### Game
```csharp
private void SomeMethod()
{
    // Fired when visibility state changed ('Visible', 'Hidden')
    // For example: you can play/pause music here 
    Bridge.game.visibilityStateChanged += state => { Debug.Log(state); };
}
```

### Storage
```csharp
private void SomeMethod()
{
    // Current platform storage type ('LocalStorage', 'PlatformInternal')
    Bridge.storage.defaultType

    // Check if the storage supported
    Bridge.storage.IsSupported(StorageType.LocalStorage)
    Bridge.storage.IsSupported(StorageType.PlatformInternal)

    // Get data from storage
    Bridge.storage.Get("key", (success, data) => 
    {
        if (success)
        {
            // Data has been received and you can work with them
            // data = null if there is no data for this key
        }
        else
        {
            // Error
        }
        
    });

    // Set game data in storage
    Bridge.storage.Set("key", "value", success =>
    {
        if (success)
        {
            // Success
        }
        else
        {
            // Error
        }
    });

    // Delete game data from storage
    Bridge.storage.Delete("key", success =>
    {
        if (success)
        {
            // Success
        }
        else
        {
            // Error
        }
    });

    // You can choose storage type
    Bridge.storage.Get("key", Callback, StorageType.LocalStorage);

    // You can send a list of keys and values
    var keys = new List<string> { "example_1", "example_2", "example_3" };
    var values = new List<object> { 1, "test", true };
    Bridge.storage.Set(keys, values);
}
```

### Advertisement
If you want to show banners on VK — add [bridge-vk-banner-extension](https://github.com/instant-games-bridge/instant-games-bridge-vk-banner-extension) (+482kb).
```csharp
private void SomeMethod()
{
    /* -- -- -- Banners -- -- -- */
    Bridge.advertisement.isBannerSupported

    Bridge.advertisement.ShowBanner(new ShowBannerVkOptions(VkBannerPosition.Bottom));
    Bridge.advertisement.HideBanner();

    /* -- -- -- Delays Between Interstitials -- -- -- */
    Bridge.advertisement.minimumDelayBetweenInterstitial // Default = 60 seconds

    // You can override minimum delay. You can use platform specific delays:
    var seconds = 30;
    Bridge.advertisement.SetMinimumDelayBetweenInterstitial(
        new SetMinimumDelayBetweenInterstitialVkOptions(seconds),
        new SetMinimumDelayBetweenInterstitialYandexOptions(seconds));
        
    // Or common to all platforms:
    Bridge.advertisement.SetMinimumDelayBetweenInterstitial(seconds);
    
    /* -- -- -- Interstitial -- -- -- */
    // Optional parameter
    var ignoreDelay = true; // Default = false
    
    //  You can use platform specific ignoring:
    Bridge.advertisement.ShowInterstitial(
        new ShowInterstitialVkOptions(ignoreDelay),
        new ShowInterstitialYandexOptions(ignoreDelay));
    
    // Or common to all platforms:
    Bridge.advertisement.ShowInterstitial(ignoreDelay);

    /* -- -- -- Rewarded Video -- -- -- */
    // Request to show rewarded video ads
    Bridge.advertisement.ShowRewarded();
    
    /* -- -- -- Advertisement States -- -- -- */
    // Fired when interstitial state changed ('Shown', 'Hidden', 'Failed')
    Bridge.advertisement.bannerStateChanged += state => { Debug.Log($"Banner state: {state}"); };

    // Fired when interstitial state changed ('Opened', 'Closed', 'Failed')
    Bridge.advertisement.interstitialStateChanged += state => { Debug.Log($"Interstitial state: {state}"); };
    
    // Fired when rewarded video state changed ('Opened', 'Rewarded', 'Closed', 'Failed')
    // It is recommended to give a reward when the state is 'Rewarded'
    Bridge.advertisement.rewardedStateChanged += state => { Debug.Log($"Rewarded state: {state}"); };
}
```

### Social
```csharp
private void SomeMethod()
{
    // VK: true
    // Yandex: false
    Bridge.social.isShareSupported
    Bridge.social.isJoinCommunitySupported
    Bridge.social.isInviteFriendsSupported
    Bridge.social.isCreatePostSupported
    Bridge.social.isAddToFavoritesSupported

    // VK, Yandex: partial supported
    Bridge.social.isAddToHomeScreenSupported
    
    // VK: false
    // Yandex: true
    Bridge.social.isRateSupported

    var vkShareLink = "https://vk.com/mewton.games";
    Bridge.social.Share(
        success => { 
            if (success)
            {
                // Success
            }
            else
            {
                // Error
            }
        },
        new ShareVkOptions(vkShareLink));

    var vkGroupId = 199747461;
    Bridge.social.JoinCommunity(
        success => {
            if (success)
            {
                // Success
            }
            else
            {
                // Error
            }
        },
        new JoinCommunityVkOptions(vkGroupId));
        
    Bridge.social.InviteFriends(success =>
    {
        if (success)
        {
            // Success
        }
        else
        {
            // Error
        }
    });

    var vkPostMessage = "Hello World!";
    var vkPostAttachments = "photo-199747461_457239629";
    Bridge.social.CreatePost(
        success =>
        {
            if (success)
            {
                // Success
            }
            else
            {
                // Error
            }
        },
        new CreatePostVkOptions(vkPostMessage, vkPostAttachments));

    Bridge.social.AddToHomeScreen(success =>
    {
        if (success)
        {
            // Success
        }
        else
        {
            // Error
        }
    });

    Bridge.social.AddToFavorites(success =>
    {
        if (success)
        {
            // Success
        }
        else
        {
            // Error
        }
    });
    
    Bridge.social.Rate(success =>
    {
        if (success)
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

### Leaderboard
```csharp
private void SomeMethod()
{
    // VK, Yandex: true
    Bridge.leaderboard.isSupported
    
    // VK: true, Yandex: false
    Bridge.leaderboard.isNativePopupSupported
    
    // VK: false, Yandex: true
    Bridge.leaderboard.isMultipleBoardsSupported
    Bridge.leaderboard.isSetScoreSupported
    Bridge.leaderboard.isGetScoreSupported
    Bridge.leaderboard.isGetEntriesSupported
    
    var vkUserResult = 42;
    var vkGlobal = true;
    Bridge.leaderboard.ShowNativePopup(
        success =>
        {
            if (success)
            {
                // Success
            }
            else
            {
                // Error
            }
        },
        new ShowNativePopupVkOptions(vkUserResult, vkGlobal));
    
    var yandexLeaderboardName = 'YOUR_LEADERBOARD_NAME';
    var yandexScore = 42;
    Bridge.leaderboard.SetScore(
        success =>
        {
            if (success)
            {
                // Success
            }
            else
            {
                // Error
            }
        },
        new SetScoreYandexOptions(yandexScore, yandexLeaderboardName));
        
    Bridge.leaderboard.GetScore(
        (success, score) =>
        {
            if (success)
            {
                // Success
            }
            else
            {
                // Error
            }
        },
        new GetScoreYandexOptions(yandexLeaderboardName));
        
    var yandexGetEntriesIncludeUser = true;
    var yandexGetEntriesQuantityTop = 10;
    var yandexGetEntriesQuantityAround = 10;
    var yandexGetEntriesOptions = new GetEntriesYandexOptions(
        yandexLeaderboardName,
        yandexGetEntriesIncludeUser,
        yandexGetEntriesQuantityTop,
        yandexGetEntriesQuantityAround);

    Bridge.leaderboard.GetEntries(
        (success, entries) =>
        {
            if (success)
            {
                foreach (var entry in entries)
                    Debug.Log($"ID: { entry.id }, name: { entry.name }, score: { entry.score }, rank: { entry.rank }");
            }
            else
            {
                // Error
            }
        },
        yandexGetEntriesOptions);
}
```