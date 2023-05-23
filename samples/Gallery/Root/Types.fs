namespace Gallery.Root

open Gallery

module Types =
    type Model =
        { Navigation: NavigationModel
          SafeAreaInsets: float }

    type Msg =
        | SubpageMsg of SubpageMsg
        | NavigationMsg of NavigationRoute
        | OnLoaded of bool

    type CmdMsg =
        | NewMsg of Msg
        | SubpageCmdMsgs of SubpageCmdMsg list
