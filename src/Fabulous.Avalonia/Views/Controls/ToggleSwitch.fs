namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous

type IFabToggleSwitch = inherit IFabTemplatedControl

module ToggleSwitch =
    let WidgetKey = Widgets.register<ToggleSwitch>()
    
    let IsChecked = Attributes.defineDirectWithEquality ToggleSwitch.IsCheckedProperty
    let Checked = Attributes.defineEvent "ToggleSwitch_Checked" (fun target -> (target :?> ToggleSwitch).Checked)
    
[<AutoOpen>]
module ToggleSwitchBuilders =
    type Fabulous.Avalonia.View with
        static member inline ToggleSwitch<'msg>(value: bool option, onValueChanged: bool option -> 'msg) =
            WidgetBuilder<'msg, IFabToggleSwitch>(
                ToggleSwitch.WidgetKey,
                ToggleSwitch.IsChecked.WithValue(Option.toNullable value),
                ToggleSwitch.Checked.WithValue(fun args ->
                    onValueChanged (Option.ofNullable (args.Source :?> ToggleSwitch).IsChecked) |> box
                )
            )
