namespace Fabulous.Avalonia

open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabPathIcon =
    inherit IFabIconElement

module PathIcon =
    let WidgetKey = Widgets.register<PathIcon>()

    let DataWidget = Attributes.defineAvaloniaPropertyWidget PathIcon.DataProperty

    let DataString = Attributes.defineAvaloniaPropertyWithEquality PathIcon.DataProperty

[<AutoOpen>]
module PathIconBuilders =
    type Fabulous.Avalonia.View with

        static member PathIcon(content: WidgetBuilder<'msg, #IFabGeometry>) =
            WidgetBuilder<'msg, IFabPathIcon>(
                PathIcon.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| PathIcon.DataWidget.WithValue(content.Compile()) |], ValueNone)
            )

        static member PathIcon(pathData: string) =
            WidgetBuilder<'msg, IFabPathIcon>(PathIcon.WidgetKey, PathIcon.DataString.WithValue(Geometry.Parse(pathData)))
