mergeInto(LibraryManager.library, {

    InstantGamesBridgeInitialize: function(settings) {
        window.initialize(UTF8ToString(settings))
    },

    InstantGamesBridgeGetPlatformId: function() {
        var platformId = window.getPlatformId()
        var bufferSize = lengthBytesUTF8(platformId) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(platformId, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeGetPlatformLanguage: function() {
        var platformLanguage = window.getPlatformLanguage()
        var bufferSize = lengthBytesUTF8(platformLanguage) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(platformLanguage, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeGetPlatformPayload: function() {
        var platformPayload = window.getPlatformPayload()
        var bufferSize = lengthBytesUTF8(platformPayload) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(platformPayload, buffer, bufferSize)
        return buffer
    },


    InstantGamesBridgeIsPlayerAuthorizationSupported: function() {
        var isPlayerAuthorizationSupported = window.getIsPlayerAuthorizationSupported()
        var bufferSize = lengthBytesUTF8(isPlayerAuthorizationSupported) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isPlayerAuthorizationSupported, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeIsPlayerAuthorized: function() {
        var isPlayerAuthorized = window.getIsPlayerAuthorized()
        var bufferSize = lengthBytesUTF8(isPlayerAuthorized) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isPlayerAuthorized, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgePlayerId: function() {
        var playerId = window.getPlayerId()
        var bufferSize = lengthBytesUTF8(playerId) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(playerId, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgePlayerName: function() {
        var playerName = window.getPlayerName()
        var bufferSize = lengthBytesUTF8(playerName) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(playerName, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgePlayerPhotos: function() {
        var playerPhotos = window.getPlayerPhotos()
        var bufferSize = lengthBytesUTF8(playerPhotos) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(playerPhotos, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeAuthorizePlayer: function() {
        window.authorizePlayer()
    },


    InstantGamesBridgeGetGameData: function(key) {
        window.getGameData(UTF8ToString(key))
    },

    InstantGamesBridgeSetGameData: function(key, value) {
        window.setGameData(UTF8ToString(key), UTF8ToString(value))
    },

    InstantGamesBridgeDeleteGameData: function(key) {
        window.deleteGameData(UTF8ToString(key))
    },


    InstantGamesBridgeMinimumDelayBetweenInterstitial: function() {
        var minimumDelayBetweenInterstitial = window.getMinimumDelayBetweenInterstitial()
        var bufferSize = lengthBytesUTF8(minimumDelayBetweenInterstitial) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(minimumDelayBetweenInterstitial, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeSetMinimumDelayBetweenInterstitial: function(seconds) {
        window.setMinimumDelayBetweenInterstitial(seconds)
    },

    InstantGamesBridgeShowInterstitial: function(ignoreDelay) {
        window.showInterstitial(ignoreDelay)
    },

    InstantGamesBridgeShowRewarded: function() {
        window.showRewarded()
    },


    InstantGamesBridgeIsShareSupported: function() {
        var isShareSupported = window.getIsShareSupported()
        var bufferSize = lengthBytesUTF8(isShareSupported) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isShareSupported, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeIsInviteFriendsSupported: function() {
        var isInviteFriendsSupported = window.getIsInviteFriendsSupported()
        var bufferSize = lengthBytesUTF8(isInviteFriendsSupported) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isInviteFriendsSupported, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeIsJoinCommunitySupported: function() {
        var isJoinCommunitySupported = window.getIsJoinCommunitySupported()
        var bufferSize = lengthBytesUTF8(isJoinCommunitySupported) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isJoinCommunitySupported, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeIsCreatePostSupported: function() {
        var isCreatePostSupported = window.getIsCreatePostSupported()
        var bufferSize = lengthBytesUTF8(isCreatePostSupported) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isCreatePostSupported, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeIsAddToHomeScreenSupported: function() {
        var isAddToHomeScreenSupported = window.getIsAddToHomeScreenSupported()
        var bufferSize = lengthBytesUTF8(isAddToHomeScreenSupported) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isAddToHomeScreenSupported, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeIsAddToFavoritesSupported: function() {
        var isAddToFavoritesSupported = window.getIsAddToFavoritesSupported()
        var bufferSize = lengthBytesUTF8(isAddToFavoritesSupported) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isAddToFavoritesSupported, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeShare: function() {
        window.share()
    },

    InstantGamesBridgeInviteFriends: function() {
        window.inviteFriends()
    },

    InstantGamesBridgeJoinCommunity: function() {
        window.joinCommunity()
    },

    InstantGamesBridgeCreatePost: function(text) {
        window.createPost(UTF8ToString(text))
    },

    InstantGamesBridgeAddToHomeScreen: function() {
        window.addToHomeScreen()
    },

    InstantGamesBridgeAddToFavorites: function() {
        window.addToFavorites()
    }

});