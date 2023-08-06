namespace Gallery.Root

open Avalonia.Controls
open Avalonia.Interactivity
open Avalonia
open System

module Types =
    type Model =
        { Navigation: NavigationModel
          IsPanOpen: bool
          PaneLength: float
          HeaderText: string }

    type Msg =
        | SubpageMsg of SubpageMsg
        | OnSelectionChanged of SelectionChangedEventArgs
        | OpenPanChanged of bool
        | OpenPan
        | OnLoaded of RoutedEventArgs
        | DoNothing
        | Update of DateTime

    type CmdMsg =
        | NewMsg of Msg
        | SubpageCmdMsgs of SubpageCmdMsg list
