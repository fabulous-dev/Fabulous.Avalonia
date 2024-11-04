namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous.Avalonia

module ComponentPanel =
    let Children =
        Attributes.defineAvaloniaListWidgetCollectionNoDispatch "Panel_Children" (fun x -> (x :?> Panel).Children)
