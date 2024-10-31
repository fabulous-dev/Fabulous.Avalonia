namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentUserControl =
    inherit IFabComponentContentControl
    inherit IFabUserControl

[<AutoOpen>]
module ComponentUserControlBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a UserControl widget.</summary>
        /// <param name="content">The content of the UserControl.</param>
        static member UserControl(content: WidgetBuilder<unit, #IFabComponentControl>) =
            WidgetBuilder<unit, IFabComponentUserControl>(
                UserControl.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )
