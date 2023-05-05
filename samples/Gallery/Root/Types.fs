namespace Gallery.Root

open Gallery

module Types =
    type Model =
        { Navigation: NavigationModel
          IsPanOpen: bool
          SafeAreaInsets: float
          SelectedIndex: int
          PaneLength: float }

    type Msg =
        | SubpageMsg of SubpageMsg
        | OpenPanChanged of bool
        | NavigationMsg of NavigationRoute
        | BackButtonPressed
        | OpenPan
        | DoNothing
        | OnLoaded of bool
        
     type CmdMsg =
        | NewMsg of Msg
        | SubpageCmdMsgs of SubpageCmdMsg list