namespace Fabulous.Avalonia

open Avalonia.Controls.Primitives
open Fabulous

type IFabHeaderedContentControl =
    inherit IFabContentControl

module HeaderedContentControl =
    let HeaderString =
        Attributes.defineAvaloniaProperty<string, obj>
            HeaderedContentControl.HeaderProperty
            box
            ScalarAttributeComparers.equalityCompare

    let HeaderWidget =
        Attributes.defineAvaloniaPropertyWidget HeaderedContentControl.HeaderProperty
