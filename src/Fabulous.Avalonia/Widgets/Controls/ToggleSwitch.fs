namespace Fabulous.Avalonia

open System
open Avalonia.Controls
open Fabulous

type IFabToggleSwitch =
    inherit IFabTemplatedControl

module ToggleSwitch =
    let WidgetKey =
        Widgets.registerWithFactory (fun () -> ToggleSwitch(IsThreeState = false))

    let IsChecked =
        Attributes.definePropertyWithChangedEvent
            "ToggleSwitch_IsChecked"
            ToggleSwitch.IsCheckedProperty
            Nullable
            Nullable.op_Explicit

[<AutoOpen>]
module ToggleSwitchBuilders =
    type Fabulous.Avalonia.View with

        static member inline ToggleSwitch<'msg>(value: bool, onValueChanged: bool -> 'msg) =
            WidgetBuilder<'msg, IFabToggleSwitch>(
                ToggleSwitch.WidgetKey,
                ToggleSwitch.IsChecked.WithValue(ValueEventData.create value (fun args -> onValueChanged args |> box))
            )
