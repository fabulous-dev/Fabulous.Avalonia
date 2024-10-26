namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentToggleSplitButton =
    inherit IFabComponentSplitButton
    inherit IFabToggleSplitButton

module ComponentToggleSplitButton =
    let CheckedChanged =
        ComponentAttributes.defineAvaloniaPropertyWithChangedEvent' "ToggleSplitButton_CheckedChanged" ToggleSplitButton.IsCheckedProperty

[<AutoOpen>]
module ComponentToggleSplitButtonBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a ToggleSplitButton widget.</summary>
        /// <param name="text">The text of the ToggleSplitButton.</param>
        /// <param name="isChecked">Whether the ToggleSplitButton is checked.</param>
        /// <param name="fn">Raised when the ToggleSplitButton is checked or unchecked.</param>
        static member ToggleSplitButton(text: string, isChecked: bool, fn: bool -> unit) =
            WidgetBuilder<unit, IFabToggleSplitButton>(
                ToggleSplitButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                ComponentToggleSplitButton.CheckedChanged.WithValue(ComponentValueEventData.create isChecked fn)
            )

        /// <summary>Creates a ToggleSplitButton widget.</summary>
        /// <param name="isChecked">Whether the ToggleSplitButton is checked.</param>
        /// <param name="fn">Raised when the ToggleSplitButton is checked or unchecked.</param>
        /// <param name="content">The content of the ToggleSplitButton.</param>
        static member ToggleSplitButton(isChecked: bool, fn: bool -> unit, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<unit, IFabToggleSplitButton>(
                ToggleSplitButton.WidgetKey,
                AttributesBundle(
                    StackList.one(ComponentToggleSplitButton.CheckedChanged.WithValue(ComponentValueEventData.create isChecked fn)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

type ComponentToggleSplitButtonModifiers =
    /// <summary>Link a ViewRef to access the direct ToggleSplitButton control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComponentToggleSplitButton>, value: ViewRef<ToggleSplitButton>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
