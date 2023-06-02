namespace Gallery.Root

open Gallery.Root.Types

module View =
    let view (model: Model) =
#if MOBILE || BROWSER
        MainView.view model
#else
        MainWindow.view model
#endif
