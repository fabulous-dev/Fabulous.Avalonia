namespace Fabulous.Avalonia

open Avalonia.Controls.Primitives
open Fabulous

type IFabHeaderedContentControl =
    inherit IFabContentControl

module HeaderedContentControl =
    let Header =
        Attributes.defineAvaloniaProperty<string, obj>
            HeaderedContentControl.HeaderProperty
            box
            ScalarAttributeComparers.equalityCompare
