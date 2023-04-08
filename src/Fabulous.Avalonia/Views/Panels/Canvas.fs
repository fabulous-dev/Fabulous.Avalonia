namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

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

        static member Canvas<'msg>(viewRef: ViewRef<Canvas>) =
            WidgetBuilder<'msg, IFabCanvas>(Canvas.WidgetKey, ViewRefAttributes.ViewRef.WithValue(viewRef.Unbox))

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

    /// <summary>Link a ViewRef to access the direct Canvas control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCanvas>, value: ViewRef<Canvas>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
