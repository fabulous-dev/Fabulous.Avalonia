namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentRepeatButton =
    inherit IFabComponentButton
    inherit IFabRepeatButton


[<AutoOpen>]
module ComponentRepeatButtonBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a RepeatButton widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="msg">Raised when the button is clicked.</param>
        static member RepeatButton(text: string, msg: RoutedEventArgs -> unit) =
            WidgetBuilder<unit, IFabComponentRepeatButton>(
                RepeatButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                ComponentButton.Clicked.WithValue(msg)
            )

        /// <summary>Creates a RepeatButton widget.</summary>
        /// <param name="content">The content to display.</param>
        /// M<param name="fn">Raised when the button is clicked.</param>
        static member RepeatButton(fn: RoutedEventArgs -> unit, content: WidgetBuilder<unit, #IFabComponentControl>) =
            WidgetBuilder<unit, IFabComponentRepeatButton>(
                RepeatButton.WidgetKey,
                AttributesBundle(
                    StackList.one(ComponentButton.Clicked.WithValue(fn)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

type ComponentRepeatButtonModifiers =

    /// <summary>Link a ViewRef to access the direct RepeatButton control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComponentRepeatButton>, value: ViewRef<RepeatButton>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
