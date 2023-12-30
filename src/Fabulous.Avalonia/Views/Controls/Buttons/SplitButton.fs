namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabSplitButton =
    inherit IFabContentControl

module SplitButton =
    let WidgetKey = Widgets.register<SplitButton>()

    let Clicked =
        Attributes.defineEvent "SplitButton_Clicked" (fun target -> (target :?> SplitButton).Click)

    let Flyout = Attributes.defineAvaloniaPropertyWidget SplitButton.FlyoutProperty

[<AutoOpen>]
module SplitButtonBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a SplitButton widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="fn">Raised when the SplitButton is clicked.</param>
        static member inline SplitButton(text: string, fn: 'msg) =
            WidgetBuilder<'msg, IFabSplitButton>(
                SplitButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                SplitButton.Clicked.WithValue(fun _ -> box fn)
            )

        /// <summary>Creates a SplitButton widget.</summary>
        /// <param name="fn">Raised when the SplitButton is clicked.</param>
        /// <param name="content">The content to display in the flyout.</param>
        static member inline SplitButton(fn: 'msg, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabSplitButton>(
                SplitButton.WidgetKey,
                AttributesBundle(
                    StackList.one(SplitButton.Clicked.WithValue(fun _ -> box fn)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

[<Extension>]
type SplitButtonModifiers =
    /// <summary>Sets the Flyout property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Flyout value.</param>
    [<Extension>]
    static member inline flyout(this: WidgetBuilder<'msg, #IFabSplitButton>, value: WidgetBuilder<'msg, #IFabFlyoutBase>) =
        this.AddWidget(SplitButton.Flyout.WithValue(value.Compile()))

    /// <summary>Link a ViewRef to access the direct SplitButton control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabSplitButton>, value: ViewRef<SplitButton>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
