mergeInto(LibraryManager.library, {

  ShowFullscreen: function () {
      ysdk.adv.showFullscreenAdv({
      callbacks: {
          onOpen: function(wasShown) {
            console.log('Реклама Fullscreen открылась.');
          },
          onClose: function(wasShown) {
            console.log("Реклама Fullscreen закрылась.");
          },
          onError: function(error) {
            console.log("Ошибка по рекламе Fullscreen.");
          }
      }
      })
  }
});