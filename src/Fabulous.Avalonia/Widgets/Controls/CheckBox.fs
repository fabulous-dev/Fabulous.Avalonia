namespace Fabulous.Avalonia

open System
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
                ToggleButton.IsChecked.WithValue(isChecked),
                ToggleButton.CheckedChanged.WithValue(fun args ->
                    let control = args.Source :?> CheckBox
                    let isChecked = Nullable.op_Explicit(control.IsChecked)
                    onValueChanged isChecked |> box)
            )

        static member inline CheckBox<'msg>(text: string, isChecked: bool, onValueChanged: bool -> 'msg) =
            WidgetBuilder<'msg, IFabCheckBox>(
                CheckBox.WidgetKey,
                ToggleButton.IsChecked.WithValue(isChecked),
                ContentControl.ContentString.WithValue(text),
                ToggleButton.CheckedChanged.WithValue(fun args ->
                    let control = args.Source :?> CheckBox
                    let isChecked = Nullable.op_Explicit(control.IsChecked)
                    onValueChanged isChecked |> box)
            )

        static member inline CheckBox(isChecked: bool, onValueChanged: bool -> 'msg, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabCheckBox>(
                CheckBox.WidgetKey,
                AttributesBundle(
                    StackList.two(
                        ToggleButton.IsChecked.WithValue(isChecked),
                        ToggleButton.CheckedChanged.WithValue(fun args ->
                            let control = args.Source :?> CheckBox
                            let isChecked = Nullable.op_Explicit(control.IsChecked)
                            onValueChanged isChecked |> box)
                    ),
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
