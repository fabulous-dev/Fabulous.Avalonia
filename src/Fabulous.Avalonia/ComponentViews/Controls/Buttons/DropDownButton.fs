namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentDropDownButton =
    inherit IFabComponentButton
    inherit IFabDropDownButton

[<AutoOpen>]
module ComponentDropDownButtonBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a DropDownButton widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="msg">Raised when the DropDownButton is clicked.</param>
        static member DropDownButton(text: string, msg: RoutedEventArgs -> unit) =
            WidgetBuilder<unit, IFabComponentDropDownButton>(
                DropDownButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                ComponentButton.Clicked.WithValue(msg)
            )

        /// <summary>Creates a DropDownButton widget.</summary>
        /// <param name="msg">Raised when the DropDownButton is clicked.</param>
        /// <param name="content">The content of the DropDownButton.</param>
        static member DropDownButton(msg: RoutedEventArgs -> unit, content: WidgetBuilder<unit, #IFabComponentControl>) =
            WidgetBuilder<unit, IFabComponentDropDownButton>(
                DropDownButton.WidgetKey,
                AttributesBundle(
                    StackList.one(ComponentButton.Clicked.WithValue(msg)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )
