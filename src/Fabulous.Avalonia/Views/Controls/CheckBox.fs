namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabCheckBox =
    inherit IFabToggleButton

module CheckBox =
    let WidgetKey = Widgets.register<CheckBox>()

[<AutoOpen>]
module CheckBoxBuilders =
    type Fabulous.Avalonia.View with

        static member inline CheckBox<'msg>(isChecked: bool, onValueChanged: bool -> 'msg) =
            WidgetBuilder<'msg, IFabCheckBox>(
                CheckBox.WidgetKey,
                ToggleButton.CheckedChanged.WithValue(ValueEventData.create isChecked (fun args -> onValueChanged args |> box))
            )

        static member inline CheckBox<'msg>(text: string, isChecked: bool, onValueChanged: bool -> 'msg) =
            WidgetBuilder<'msg, IFabCheckBox>(
                CheckBox.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                ToggleButton.CheckedChanged.WithValue(ValueEventData.create isChecked (fun args -> onValueChanged args |> box))
            )

        static member inline CheckBox(isChecked: bool, onValueChanged: bool -> 'msg, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabCheckBox>(
                CheckBox.WidgetKey,
                AttributesBundle(
                    StackList.one(ToggleButton.CheckedChanged.WithValue(ValueEventData.create isChecked (fun args -> onValueChanged args |> box))),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

        static member inline ThreeStateCheckBox<'msg>(isChecked: bool option, onValueChanged: bool option -> 'msg) =
            WidgetBuilder<'msg, IFabCheckBox>(
                CheckBox.WidgetKey,
                ToggleButton.IsThreeState.WithValue(true),
                ToggleButton.ThreeStateCheckedChanged.WithValue(
                    ValueEventData.createVOption (ThreeState.fromOption(isChecked)) (fun args -> onValueChanged(ThreeState.toOption args) |> box)
                )
            )

        static member inline ThreeStateCheckBox<'msg>(text: string, isChecked: bool option, onValueChanged: bool option -> 'msg) =
            WidgetBuilder<'msg, IFabCheckBox>(
                CheckBox.WidgetKey,
                ToggleButton.IsThreeState.WithValue(true),
                ContentControl.ContentString.WithValue(text),
                ToggleButton.ThreeStateCheckedChanged.WithValue(
                    ValueEventData.createVOption (ThreeState.fromOption(isChecked)) (fun args -> onValueChanged(ThreeState.toOption args) |> box)
                )
            )

        static member inline ThreeStateCheckBox(isChecked: bool option, onValueChanged: bool option -> 'msg, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabCheckBox>(
                CheckBox.WidgetKey,
                AttributesBundle(
                    StackList.two(
                        ToggleButton.ThreeStateCheckedChanged.WithValue(
                            ValueEventData.createVOption (ThreeState.fromOption(isChecked)) (fun args -> onValueChanged(ThreeState.toOption args) |> box)
                        ),
                        ToggleButton.IsThreeState.WithValue(true)
                    ),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

[<Extension>]
type CheckBoxModifiers =
    /// <summary>Link a ViewRef to access the direct CheckBox control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCheckBox>, value: ViewRef<CheckBox>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
