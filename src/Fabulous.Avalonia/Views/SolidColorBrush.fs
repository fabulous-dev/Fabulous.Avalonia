namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous

type IFabSolidColorBrush =
    inherit IFabBrush

module SolidColorBrush =
    let WidgetKey = Widgets.register<SolidColorBrush>()

    let Color =
        Attributes.defineAvaloniaPropertyWithEquality SolidColorBrush.ColorProperty

type SolidColorBrushModifiers =
    /// <summary>Link a ViewRef to access the direct SolidColorBrush control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabSolidColorBrush>, value: ViewRef<SolidColorBrush>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
