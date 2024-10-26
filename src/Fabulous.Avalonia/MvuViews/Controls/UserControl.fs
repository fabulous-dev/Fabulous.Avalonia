namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuUserControl =
    inherit IFabMvuContentControl
    inherit IFabUserControl

[<AutoOpen>]
module MvuUserControlBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a UserControl widget.</summary>
        /// <param name="content">The content of the UserControl.</param>
        static member UserControl(content: WidgetBuilder<'msg, #IFabMvuControl>) =
            WidgetBuilder<'msg, IFabMvuUserControl>(
                UserControl.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |], ValueNone)
            )
