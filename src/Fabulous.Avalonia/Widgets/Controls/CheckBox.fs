namespace Fabulous.Avalonia

open System
open Avalonia.Controls
open Fabulous

type IFabCheckBox =
    inherit IFabTemplatedControl

module CheckBox =
    let WidgetKey =
        Widgets.registerWithFactory(fun () -> CheckBox(IsThreeState = false))

    let IsChecked =
        Attributes.defineAvaloniaPropertyWithChangedEvent
            "CheckBox_IsChecked"
            CheckBox.IsCheckedProperty
            Nullable
            Nullable.op_Explicit

[<AutoOpen>]
module CheckBoxBuilders =
    type Fabulous.Avalonia.View with

        static member inline CheckBox<'msg>(value: bool, onValueChanged: bool -> 'msg) =
            WidgetBuilder<'msg, IFabCheckBox>(
                CheckBox.WidgetKey,
                CheckBox.IsChecked.WithValue(ValueEventData.create value (fun args -> onValueChanged args |> box))
            )
