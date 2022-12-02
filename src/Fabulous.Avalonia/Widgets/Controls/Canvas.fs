namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabCanvas =
    inherit IFabPanel

module Canvas =

    let WidgetKey = Widgets.register<Canvas> ()

    let Left = Attributes.defineAvaloniaPropertyWithEquality Canvas.LeftProperty

    let Top = Attributes.defineAvaloniaPropertyWithEquality Canvas.TopProperty

    let Right = Attributes.defineAvaloniaPropertyWithEquality Canvas.RightProperty

    let Bottom = Attributes.defineAvaloniaPropertyWithEquality Canvas.BottomProperty

[<AutoOpen>]
module CanvasBuilders =
    type Fabulous.Avalonia.View with

        static member Canvas<'msg>() =
            CollectionBuilder<'msg, IFabCanvas, IFabControl>(Canvas.WidgetKey, Panel.Children)

[<Extension>]
type CanvasModifiers =
    [<Extension>]
    static member inline left(this: WidgetBuilder<'msg, #IFabControl>, left: float) =
        this.AddScalar(Canvas.Left.WithValue(left))

    [<Extension>]
    static member inline top(this: WidgetBuilder<'msg, #IFabControl>, top: float) =
        this.AddScalar(Canvas.Top.WithValue(top))

    [<Extension>]
    static member inline right(this: WidgetBuilder<'msg, #IFabControl>, right: float) =
        this.AddScalar(Canvas.Right.WithValue(right))

    [<Extension>]
    static member inline bottom(this: WidgetBuilder<'msg, #IFabControl>, bottom: float) =
        this.AddScalar(Canvas.Bottom.WithValue(bottom))
