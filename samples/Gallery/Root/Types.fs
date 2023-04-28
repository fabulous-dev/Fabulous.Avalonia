namespace Gallery.Root

open Gallery
open Avalonia.Controls

module Types =
    type Model =
        { PageModel: Pages.Types.Model
          Pages: string seq
          IsPanOpen: bool
          SafeAreaInsets: float
          PaneLength: float }

    type Msg =
        | PageMsg of Pages.Types.Msg
        | SelectedChanged of SelectionChangedEventArgs
        | OpenPanChanged of bool
        | OpenPan
        | DoNothing
        | OnLoaded of bool
