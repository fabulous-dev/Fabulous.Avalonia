namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabCanvas =
    inherit IFabPanel

module Canvas =

    let WidgetKey = Widgets.register<Canvas>()

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
    static member inline canvasLeft(this: WidgetBuilder<'msg, #IFabControl>, value: float) =
        this.AddScalar(Canvas.Left.WithValue(value))

    [<Extension>]
    static member inline canvasTop(this: WidgetBuilder<'msg, #IFabControl>, value: float) =
        this.AddScalar(Canvas.Top.WithValue(value))

    [<Extension>]
    static member inline canvasRight(this: WidgetBuilder<'msg, #IFabControl>, value: float) =
        this.AddScalar(Canvas.Right.WithValue(value))

    [<Extension>]
    static member inline canvasBottom(this: WidgetBuilder<'msg, #IFabControl>, value: float) =
        this.AddScalar(Canvas.Bottom.WithValue(value))
