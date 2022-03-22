mergeInto(LibraryManager.library, {

    InstantGamesBridgeInitialize: function() {
        window.initialize()
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

    InstantGamesBridgeSetMinimumDelayBetweenInterstitial: function(seconds) {
        window.setMinimumDelayBetweenInterstitial(seconds)
    },

    InstantGamesBridgeShowInterstitial: function(ignoreDelay) {
        window.showInterstitial(ignoreDelay)
    },

    InstantGamesBridgeShowRewarded: function() {
        window.showRewarded()
    },

    InstantGamesBridgeGetGameData: function(key) {
        window.getGameData(Pointer_stringify(key))
    },

    InstantGamesBridgeSetGameData: function(key, value) {
        window.setGameData(Pointer_stringify(key), Pointer_stringify(value))
    }

});