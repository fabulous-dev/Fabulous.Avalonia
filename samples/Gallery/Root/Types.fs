namespace Gallery.Root

open Avalonia.Controls
open Gallery

module Types =
    type Model =
        { Navigation: NavigationModel
          IsPanOpen: bool
          PaneLength: float }

    type Msg =
        | SubpageMsg of SubpageMsg
        | OnSelectionChanged of SelectionChangedEventArgs
        | OpenPanChanged of bool
        | OpenPan
        | OnLoaded of bool
        | DoNothing

    type CmdMsg =
        | NewMsg of Msg
        | SubpageCmdMsgs of SubpageCmdMsg list
