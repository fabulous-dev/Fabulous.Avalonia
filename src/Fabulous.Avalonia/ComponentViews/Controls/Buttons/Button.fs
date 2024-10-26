namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentButton =
    inherit IFabComponentContentControl
    inherit IFabButton

module ComponentButton =
    let Clicked =
        Attributes.defineEventNoDispatch "Button_Clicked" (fun target -> (target :?> Button).Click)

[<AutoOpen>]
module ComponentButtonBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Button widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="fn">Raised when the button is clicked.</param>
        static member Button(text: string, fn: RoutedEventArgs -> unit) =
            WidgetBuilder<unit, IFabComponentAutoCompleteBox>(
                Button.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                ComponentButton.Clicked.WithValue(fn)
            )

        /// <summary>Creates a Button widget.</summary>
        /// <param name="fn">Raised when the button is clicked.</param>
        /// <param name="content">The content to display.</param>
        static member Button(fn: RoutedEventArgs -> unit, content: WidgetBuilder<unit, #IFabControl>) =
            WidgetBuilder<unit, IFabComponentAutoCompleteBox>(
                Button.WidgetKey,
                AttributesBundle(
                    StackList.one(ComponentButton.Clicked.WithValue(fn)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

type ComponentButtonModifiers =
    /// <summary>Link a ViewRef to access the direct Button control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComponentAutoCompleteBox>, value: ViewRef<Button>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
