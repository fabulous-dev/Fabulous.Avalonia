namespace Fabulous.Avalonia

open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

module ComponentButton =
    let Clicked =
        Attributes.defineEventNoDispatch "Button_Clicked" (fun target -> (target :?> Button).Click)

[<AutoOpen>]
module ComponentButtonBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Button widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="fn">Raised when the button is clicked.</param>
        static member Button(text: string, fn: RoutedEventArgs -> unit) =
            WidgetBuilder<unit, IFabButton>(Button.WidgetKey, ContentControl.ContentString.WithValue(text), ComponentButton.Clicked.WithValue(fn))

        /// <summary>Creates a Button widget.</summary>
        /// <param name="fn">Raised when the button is clicked.</param>
        /// <param name="content">The content to display.</param>
        static member Button(fn: RoutedEventArgs -> unit, content: WidgetBuilder<unit, #IFabControl>) =
            WidgetBuilder<unit, IFabButton>(
                Button.WidgetKey,
                AttributesBundle(
                    StackList.one(ComponentButton.Clicked.WithValue(fn)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )
