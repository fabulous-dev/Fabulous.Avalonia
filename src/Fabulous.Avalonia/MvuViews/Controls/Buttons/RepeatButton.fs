namespace Fabulous.Avalonia.Mvu

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
        static member RepeatButton(text: string, msg: RoutedEventArgs -> 'msg) =
            WidgetBuilder<'msg, IFabMvuRepeatButton>(RepeatButton.WidgetKey, ContentControl.ContentString.WithValue(text), MvuButton.Clicked.WithValue(msg))

        /// <summary>Creates a RepeatButton widget.</summary>
        /// <param name="content">The content to display.</param>
        /// M<param name="fn">Raised when the button is clicked.</param>
        static member RepeatButton(fn: RoutedEventArgs -> 'msg, content: WidgetBuilder<'msg, #IFabMvuControl>) =
            WidgetBuilder<'msg, IFabMvuRepeatButton>(
                RepeatButton.WidgetKey,
                AttributesBundle(
                    StackList.one(MvuButton.Clicked.WithValue(fn)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )
