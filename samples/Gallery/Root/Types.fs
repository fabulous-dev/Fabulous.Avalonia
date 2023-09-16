namespace Gallery.Root

open Avalonia.Controls
open Avalonia.Interactivity
open Avalonia
open System
open Avalonia.Media
open Avalonia.Styling

module Types =
    type Model =
        { Navigation: NavigationModel
          IsPanOpen: bool
          ThemeVariants: ThemeVariant list
          FlowDirections: FlowDirection list
          TransparencyLevels: WindowTransparencyLevel list
          HeaderText: string }

    type Msg =
        | SubpageMsg of SubpageMsg
        | OnSelectionChanged of SelectionChangedEventArgs
        | OpenPanChanged of bool
        | DoNothing
        | Settings
        | DecorationsOnSelectionChanged of SelectionChangedEventArgs
        | ThemeVariantsOnSelectionChanged of SelectionChangedEventArgs
        | FlowDirectionsOnSelectionChanged of SelectionChangedEventArgs
        | TransparencyLevelsOnSelectionChanged of SelectionChangedEventArgs

    type CmdMsg =
        | NewMsg of Msg
        | SubpageCmdMsgs of SubpageCmdMsg list
