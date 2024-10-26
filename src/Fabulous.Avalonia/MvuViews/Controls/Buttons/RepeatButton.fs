namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuRepeatButton =
    inherit IFabMvuButton
    inherit IFabRepeatButton


[<AutoOpen>]
module MvuRepeatButtonBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a RepeatButton widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="msg">Raised when the button is clicked.</param>
        static member RepeatButton(text: string, msg: RoutedEventArgs -> unit) =
            WidgetBuilder<unit, IFabMvuRepeatButton>(RepeatButton.WidgetKey, ContentControl.ContentString.WithValue(text), MvuButton.Clicked.WithValue(msg))

        /// <summary>Creates a RepeatButton widget.</summary>
        /// <param name="content">The content to display.</param>
        /// M<param name="fn">Raised when the button is clicked.</param>
        static member RepeatButton(fn: RoutedEventArgs -> unit, content: WidgetBuilder<unit, #IFabMvuControl>) =
            WidgetBuilder<unit, IFabMvuRepeatButton>(
                RepeatButton.WidgetKey,
                AttributesBundle(
                    StackList.one(MvuButton.Clicked.WithValue(fn)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

type MvuRepeatButtonModifiers =

    /// <summary>Link a ViewRef to access the direct RepeatButton control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMvuRepeatButton>, value: ViewRef<RepeatButton>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
