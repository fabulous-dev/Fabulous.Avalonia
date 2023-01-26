namespace Fabulous.Avalonia

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

        static member inline CheckBox<'msg>(onValueChanged: bool -> 'msg, isChecked: bool) =
            WidgetBuilder<'msg, IFabCheckBox>(
                CheckBox.WidgetKey,
                ToggleButton.IsThreeState.WithValue(false),
                ToggleButton.CheckedChanged.WithValue(ValueEventData.create isChecked (fun args -> onValueChanged args |> box))
            )

        static member inline ThreeStateCheckBox<'msg>(onValueChanged: bool option -> 'msg, isChecked: bool option) =
            WidgetBuilder<'msg, IFabCheckBox>(
                CheckBox.WidgetKey,
                ToggleButton.IsThreeState.WithValue(true),
                ToggleButton.ThreeStateCheckedChanged.WithValue(
                    ValueEventData.createVOption (ThreeState.fromOption(isChecked)) (fun args -> onValueChanged(ThreeState.toOption args) |> box)
                )
            )

        static member inline CheckBox<'msg>(text: string, onValueChanged: bool -> 'msg, isChecked: bool) =
            WidgetBuilder<'msg, IFabCheckBox>(
                CheckBox.WidgetKey,
                ToggleButton.IsThreeState.WithValue(false),
                ContentControl.ContentString.WithValue(text),
                ToggleButton.CheckedChanged.WithValue(ValueEventData.create isChecked (fun args -> onValueChanged(args) |> box))
            )

        static member inline ThreeStateCheckBox<'msg>(text: string, onValueChanged: bool option -> 'msg, isChecked: bool option) =
            WidgetBuilder<'msg, IFabCheckBox>(
                CheckBox.WidgetKey,
                ToggleButton.IsThreeState.WithValue(true),
                ContentControl.ContentString.WithValue(text),
                ToggleButton.ThreeStateCheckedChanged.WithValue(
                    ValueEventData.createVOption (ThreeState.fromOption(isChecked)) (fun args -> onValueChanged(ThreeState.toOption args) |> box)
                )
            )

        static member inline CheckBox(onValueChanged: bool -> 'msg, isChecked: bool, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabCheckBox>(
                CheckBox.WidgetKey,
                AttributesBundle(
                    StackList.two(
                        ToggleButton.CheckedChanged.WithValue(ValueEventData.create isChecked (fun args -> onValueChanged args |> box)),
                        ToggleButton.IsThreeState.WithValue(false)
                    ),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

        static member inline ThreeStateCheckBox(onValueChanged: bool option -> 'msg, isChecked: bool option, content: WidgetBuilder<'msg, #IFabControl>) =
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
