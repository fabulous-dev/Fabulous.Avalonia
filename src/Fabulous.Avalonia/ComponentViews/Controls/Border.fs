namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentBorder =
    inherit IFabComponentDecorator
    inherit IFabBorder

[<AutoOpen>]
module ComponentBorderBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Border widget.</summary>
        /// <param name="content">The content of the Border.</param>
        static member Border(content: WidgetBuilder<unit, #IFabControl>) =
            WidgetBuilder<unit, IFabComponentBorder>(
                Border.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| Decorator.ChildWidget.WithValue(content.Compile()) |], ValueNone)
            )
