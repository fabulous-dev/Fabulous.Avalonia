namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabToggleSplitButton =
    inherit IFabSplitButton

module ToggleSplitButton =
    let WidgetKey = Widgets.register<ToggleSplitButton>()

    let CheckedChanged =
        Attributes.defineAvaloniaPropertyWithChangedEvent' "ToggleSplitButton_CheckedChanged" ToggleSplitButton.IsCheckedProperty

[<AutoOpen>]
module ToggleSplitButtonBuilders =
    type Fabulous.Avalonia.View with

        static member inline ToggleSplitButton<'msg>(text: string, isChecked: bool, onValueChanged: bool -> 'msg) =
            WidgetBuilder<'msg, IFabToggleSplitButton>(
                ToggleSplitButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                ToggleSplitButton.CheckedChanged.WithValue(ValueEventData.create isChecked (fun args -> onValueChanged args |> box))
            )

        static member inline ToggleSplitButton(isChecked: bool, onValueChanged: bool -> 'msg, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabToggleSplitButton>(
                ToggleSplitButton.WidgetKey,
                AttributesBundle(
                    StackList.one(ToggleSplitButton.CheckedChanged.WithValue(ValueEventData.create isChecked (fun args -> onValueChanged args |> box))),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

[<Extension>]
type ToggleSplitButtonModifiers =
    /// <summary>Link a ViewRef to access the direct ToggleSplitButton control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabToggleSplitButton>, value: ViewRef<ToggleSplitButton>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
