namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuSplitButton =
    inherit IFabMvuContentControl
    inherit IFabSplitButton

module MvuSplitButton =
    let Clicked =
        Attributes.defineEvent "SplitButton_Clicked" (fun target -> (target :?> SplitButton).Click)

[<AutoOpen>]
module MvuSplitButtonBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a SplitButton widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="fn">Raised when the SplitButton is clicked.</param>
        static member SplitButton(text: string, fn: RoutedEventArgs -> 'msg) =
            WidgetBuilder<'msg, IFabMvuSplitButton>(SplitButton.WidgetKey, ContentControl.ContentString.WithValue(text), MvuSplitButton.Clicked.WithValue(fn))

        /// <summary>Creates a SplitButton widget.</summary>
        /// <param name="fn">Raised when the SplitButton is clicked.</param>
        /// <param name="content">The content to display in the flyout.</param>
        static member SplitButton(fn: RoutedEventArgs -> 'msg, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabMvuSplitButton>(
                SplitButton.WidgetKey,
                AttributesBundle(
                    StackList.one(MvuSplitButton.Clicked.WithValue(fn)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )
