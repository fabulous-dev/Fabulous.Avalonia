namespace Gallery.Root

open Gallery

module Types =
    type Model =
        { Navigation: NavigationModel
          IsPanOpen: bool
          SafeAreaInsets: float
          SelectedIndex: int
          PaneLength: float
          Pages: string array }

    type Msg =
        | SubpageMsg of SubpageMsg
        | SelectedIndexChanged of int
        | OpenPanChanged of bool
        | OpenPan
        | OnLoaded of bool

    type CmdMsg =
        | NewMsg of Msg
        | SubpageCmdMsgs of SubpageCmdMsg list
