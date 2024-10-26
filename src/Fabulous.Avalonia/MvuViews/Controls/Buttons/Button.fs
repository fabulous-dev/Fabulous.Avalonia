namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuButton =
    inherit IFabMvuContentControl
    inherit IFabButton

module MvuButton =
    let Clicked =
        Attributes.defineEvent "Button_Clicked" (fun target -> (target :?> Button).Click)

[<AutoOpen>]
module MvuButtonBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Button widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="fn">Raised when the button is clicked.</param>
        static member Button(text: string, fn: 'msg) =
            WidgetBuilder<'msg, IFabMvuButton>(
                Button.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                MvuButton.Clicked.WithValue(fun _ -> fn)
            )

        /// <summary>Creates a Button widget.</summary>
        /// <param name="fn">Raised when the button is clicked.</param>
        /// <param name="content">The content to display.</param>
        static member Button(fn: 'msg, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabMvuButton>(
                Button.WidgetKey,
                AttributesBundle(
                    StackList.one(MvuButton.Clicked.WithValue(fun _ -> fn)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

type MvuButtonModifiers =
    /// <summary>Link a ViewRef to access the direct Button control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMvuButton>, value: ViewRef<Button>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
