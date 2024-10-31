namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentSplitButton =
    inherit IFabComponentContentControl
    inherit IFabSplitButton

module ComponentSplitButton =
    let Clicked =
        Attributes.defineEventNoDispatch "SplitButton_Clicked" (fun target -> (target :?> SplitButton).Click)

[<AutoOpen>]
module ComponentSplitButtonBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a SplitButton widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="fn">Raised when the SplitButton is clicked.</param>
        static member SplitButton(text: string, fn: RoutedEventArgs -> unit) =
            WidgetBuilder<unit, IFabSplitButton>(
                SplitButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                ComponentSplitButton.Clicked.WithValue(fn)
            )

        /// <summary>Creates a SplitButton widget.</summary>
        /// <param name="fn">Raised when the SplitButton is clicked.</param>
        /// <param name="content">The content to display in the flyout.</param>
        static member SplitButton(fn: RoutedEventArgs -> unit, content: WidgetBuilder<unit, #IFabControl>) =
            WidgetBuilder<unit, IFabSplitButton>(
                SplitButton.WidgetKey,
                AttributesBundle(
                    StackList.one(ComponentSplitButton.Clicked.WithValue(fn)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )
