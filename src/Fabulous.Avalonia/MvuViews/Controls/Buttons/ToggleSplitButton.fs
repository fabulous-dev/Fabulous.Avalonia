namespace Fabulous.Avalonia.Mvu

open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuToggleSplitButton =
    inherit IFabMvuSplitButton
    inherit IFabToggleSplitButton

module MvuToggleSplitButton =
    let CheckedChanged =
        MvuAttributes.defineAvaloniaPropertyWithChangedEvent' "ToggleSplitButton_CheckedChanged" ToggleSplitButton.IsCheckedProperty

[<AutoOpen>]
module MvuToggleSplitButtonBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a ToggleSplitButton widget.</summary>
        /// <param name="text">The text of the ToggleSplitButton.</param>
        /// <param name="isChecked">Whether the ToggleSplitButton is checked.</param>
        /// <param name="fn">Raised when the ToggleSplitButton is checked or unchecked.</param>
        static member ToggleSplitButton(text: string, isChecked: bool, fn: bool -> 'msg) =
            WidgetBuilder<'msg, IFabMvuToggleSplitButton>(
                ToggleSplitButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                MvuToggleSplitButton.CheckedChanged.WithValue(MvuValueEventData.create isChecked fn)
            )

        /// <summary>Creates a ToggleSplitButton widget.</summary>
        /// <param name="isChecked">Whether the ToggleSplitButton is checked.</param>
        /// <param name="fn">Raised when the ToggleSplitButton is checked or unchecked.</param>
        /// <param name="content">The content of the ToggleSplitButton.</param>
        static member ToggleSplitButton(isChecked: bool, fn: bool -> 'msg, content: WidgetBuilder<'msg, #IFabMvuControl>) =
            WidgetBuilder<'msg, IFabMvuToggleSplitButton>(
                ToggleSplitButton.WidgetKey,
                AttributesBundle(
                    StackList.one(MvuToggleSplitButton.CheckedChanged.WithValue(MvuValueEventData.create isChecked fn)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )
