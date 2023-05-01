namespace Gallery.Root

open Gallery

module Types =
    type Model =
        { PageModel: Pages.Types.Model
          Pages: string seq
          IsPanOpen: bool
          SafeAreaInsets: float
          SelectedIndex: int
          PaneLength: float }

    type Msg =
        | PageMsg of Pages.Types.Msg
        | SelectedIndexChanged of int
        | OpenPanChanged of bool
        | OpenPan
        | DoNothing
        | OnLoaded of bool
