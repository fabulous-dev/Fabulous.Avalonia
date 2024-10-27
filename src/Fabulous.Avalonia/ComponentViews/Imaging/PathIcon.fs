namespace Fabulous.Avalonia.Components

open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentPathIcon =
    inherit IFabComponentIconElement
    inherit IFabPathIcon

[<AutoOpen>]
module ComponentPathIconBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a PathIcon widget.</summary>
        /// <param name="content">The content of the PathIcon.</param>
        static member PathIcon(content: WidgetBuilder<unit, #IFabComponentGeometry>) =
            WidgetBuilder<unit, IFabComponentPathIcon>(
                PathIcon.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| PathIcon.DataWidget.WithValue(content.Compile()) |], ValueNone)
            )

        /// <summary>Creates a PathIcon widget.</summary>
        /// <param name="path">The path of the PathIcon.</param>
        static member PathIcon(path: string) =
            WidgetBuilder<unit, IFabComponentPathIcon>(PathIcon.WidgetKey, PathIcon.DataString.WithValue(Geometry.Parse(path)))
