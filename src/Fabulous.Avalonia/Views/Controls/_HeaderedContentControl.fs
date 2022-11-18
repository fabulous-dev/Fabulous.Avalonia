namespace Fabulous.Avalonia

open Avalonia.Controls.Primitives
open Fabulous

type IFabHeaderedContentControl = inherit IFabContentControl

module HeaderedContentControl =
    let Header = Attributes.defineAvaloniaPropertyWidget HeaderedContentControl.HeaderProperty
    let HeaderString = Attributes.defineAvaloniaProperty<string, obj> HeaderedContentControl.HeaderProperty box ScalarAttributeComparers.equalityCompare