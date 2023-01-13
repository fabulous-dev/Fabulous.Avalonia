namespace Fabulous.Avalonia

open Avalonia.Controls
open Avalonia.Layout
open Fabulous

type IFabStackPanel =
    inherit IFabPanel

module StackPanel =
    let WidgetKey = Widgets.register<StackPanel> ()

    let Spacing =
        Attributes.defineAvaloniaPropertyWithEquality StackPanel.SpacingProperty

    let Orientation =
        Attributes.defineAvaloniaPropertyWithEquality StackPanel.OrientationProperty
