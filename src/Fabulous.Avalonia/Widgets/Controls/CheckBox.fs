namespace Fabulous.Avalonia

open Avalonia.Controls
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabCheckBox =
    inherit IFabToggleButton

module CheckBox =
    let WidgetKey =
        Widgets.registerWithFactory (fun () -> CheckBox(IsThreeState = false))

[<AutoOpen>]
module CheckBoxBuilders =
    type Fabulous.Avalonia.View with

        static member inline CheckBox(isChecked: bool, onValueChanged: bool -> 'msg) =
            WidgetBuilder<'msg, IFabCheckBox>(
                CheckBox.WidgetKey,
                ToggleButton.CheckedChanged.WithValue(
                    ValueEventData.create isChecked (fun args -> onValueChanged args |> box)
                )
            )


        static member inline CheckBox(content: string, isChecked: bool, onValueChanged: bool -> 'msg) =
            WidgetBuilder<'msg, IFabCheckBox>(
                CheckBox.WidgetKey,
                ContentControl.ContentString.WithValue(content),
                ToggleButton.CheckedChanged.WithValue(
                    ValueEventData.create isChecked (fun args -> onValueChanged args |> box)
                )
            )

        static member inline CheckBox
            (
                content: WidgetBuilder<'msg, #IFabControl>,
                isChecked: bool,
                onValueChanged: bool -> 'msg
            ) =
            WidgetBuilder<'msg, IFabCheckBox>(
                CheckBox.WidgetKey,
                AttributesBundle(
                    StackList.one (
                        ToggleButton.CheckedChanged.WithValue(
                            ValueEventData.create isChecked (fun args -> onValueChanged args |> box)
                        )
                    ),

                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )
