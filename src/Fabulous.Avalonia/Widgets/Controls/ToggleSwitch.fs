namespace Fabulous.Avalonia

open System
open Avalonia.Controls
open Fabulous

type IFabToggleSwitch = inherit IFabTemplatedControl

module ToggleSwitch =
    let WidgetKey = Widgets.registerWithFactory(fun () -> ToggleSwitch(IsThreeState = false))
    
    let IsChecked =
        Attributes.defineAvaloniaPropertyWith2RoutedEvents
            "ToggleSwitch_IsChecked"
            ToggleSwitch.IsCheckedProperty
            (fun target -> (target :?> ToggleSwitch).Checked)
            (fun target -> (target :?> ToggleSwitch).Unchecked)
            Nullable
            true
            false
    
[<AutoOpen>]
module ToggleSwitchBuilders =
    type Fabulous.Avalonia.View with
        static member inline ToggleSwitch<'msg>(value: bool, onValueChanged: bool -> 'msg) =
            WidgetBuilder<'msg, IFabToggleSwitch>(
                ToggleSwitch.WidgetKey,
                ToggleSwitch.IsChecked.WithValue(ValueEventData.create value (fun args -> onValueChanged args |> box))
            )
