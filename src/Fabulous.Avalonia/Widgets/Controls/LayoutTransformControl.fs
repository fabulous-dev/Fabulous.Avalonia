namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabLayoutTransformControl =
    inherit IFabDecorator

module LayoutTransformControl =
    let WidgetKey = Widgets.register<LayoutTransformControl>()

    let RenderTransformWidget =
        Attributes.defineAvaloniaPropertyWidget LayoutTransformControl.RenderTransformProperty

    let RenderTransform =
        Attributes.defineAvaloniaPropertyWithEquality LayoutTransformControl.RenderTransformProperty

    let UseRenderTransform =
        Attributes.defineAvaloniaPropertyWithEquality LayoutTransformControl.UseRenderTransformProperty

[<AutoOpen>]
module LayoutTransformControlBuilders =
    type Fabulous.Avalonia.View with

        static member LayoutTransformControl(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabLayoutTransformControl>(
                LayoutTransformControl.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| Decorator.Child.WithValue(content.Compile()) |], ValueNone)
            )

[<Extension>]
type LayoutTransformControlModifiers =
    [<Extension>]
    static member inline layoutTransform(this: WidgetBuilder<'msg, #IFabLayoutTransformControl>, transform: WidgetBuilder<'msg, #IFabTransform>) =
        this.AddWidget(LayoutTransformControl.RenderTransformWidget.WithValue(transform.Compile()))

    [<Extension>]
    static member inline layoutTransform(this: WidgetBuilder<'msg, #IFabLayoutTransformControl>, transform: ITransform) =
        this.AddScalar(LayoutTransformControl.RenderTransform.WithValue(transform))

    [<Extension>]
    static member inline useRenderTransform(this: WidgetBuilder<'msg, #IFabLayoutTransformControl>, value: bool) =
        this.AddScalar(LayoutTransformControl.UseRenderTransform.WithValue(value))
