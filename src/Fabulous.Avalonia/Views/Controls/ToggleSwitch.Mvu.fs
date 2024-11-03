namespace Fabulous.Avalonia

open Avalonia.Animation
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module MvuToggleSwitch =
    let KnobTransitions =
        Attributes.defineAvaloniaListWidgetCollection "ToggleSwitch_KnobTransitions" (fun target ->
            let target = (target :?> ToggleSwitch)

            if target.Transitions = null then
                let newColl = Transitions()
                target.Transitions <- newColl
                newColl
            else
                target.Transitions)

[<AutoOpen>]
module MvuToggleSwitchBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ToggleSwitch widget.</summary>
        /// <param name="isChecked">Whether the ToggleSwitch is checked.</param>
        /// <param name="fn">Raised when the ToggleSwitch value changes.</param>
        static member ToggleSwitch(isChecked: bool, fn: bool -> 'msg) =
            WidgetBuilder<'msg, IFabToggleSwitch>(
                ToggleSwitch.WidgetKey,
                ToggleButton.IsThreeState.WithValue(false),
                MvuToggleButton.CheckedChanged.WithValue(MvuValueEventData.create isChecked fn)
            )

        /// <summary>Creates a ThreeStateToggleSwitch widget.</summary>
        /// <param name="isChecked">Whether the ToggleSwitch is checked.</param>
        /// <param name="fn">Raised when the ToggleSwitch value changes.</param>
        static member ThreeStateToggleSwitch(isChecked: bool option, fn: bool option -> 'msg) =
            WidgetBuilder<'msg, IFabToggleSwitch>(
                ToggleSwitch.WidgetKey,
                ToggleButton.IsThreeState.WithValue(true),
                MvuToggleButton.ThreeStateCheckedChanged.WithValue(
                    MvuValueEventData.createVOption (ThreeState.fromOption(isChecked)) (ThreeState.toOption >> fn)
                )
            )
