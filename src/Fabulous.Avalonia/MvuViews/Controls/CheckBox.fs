namespace Fabulous.Avalonia.Mvu

open System
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuCheckBox =
    inherit IFabMvuToggleButton
    inherit IFabCheckBox

[<AutoOpen>]
module MvuCheckBoxBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a CheckBox widget.</summary>
        /// <param name="isChecked">Whether the CheckBox is checked.</param>
        /// <param name="fn">Raised when the CheckBox is clicked.</param>
        static member CheckBox(isChecked: bool, fn: bool -> unit) =
            WidgetBuilder<'msg, IFabMvuCheckBox>(CheckBox.WidgetKey, MvuToggleButton.CheckedChanged.WithValue(MvuValueEventData.create isChecked fn))

        /// <summary>Creates a CheckBox widget.</summary>
        /// <param name="text">The CheckBox text.</param>
        /// <param name="isChecked">Whether the CheckBox is checked.</param>
        /// <param name="fn">Raised when the CheckBox is clicked.</param>
        static member CheckBox(text: string, isChecked: bool, fn: bool -> unit) =
            WidgetBuilder<'msg, IFabMvuCheckBox>(
                CheckBox.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                MvuToggleButton.CheckedChanged.WithValue(MvuValueEventData.create isChecked fn)
            )

        /// <summary>Creates a CheckBox widget</summary>
        /// <param name="isChecked">Whether the CheckBox is checked.</param>
        /// <param name="fn">Raised when the CheckBox is clicked.</param>
        /// <param name="content">The CheckBox content.</param>
        static member CheckBox(isChecked: bool, fn: bool -> unit, content: WidgetBuilder<'msg, #IFabMvuControl>) =
            WidgetBuilder<unit, IFabCheckBox>(
                CheckBox.WidgetKey,
                AttributesBundle(
                    StackList.one(MvuToggleButton.CheckedChanged.WithValue(MvuValueEventData.create isChecked fn)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a ThreeStateCheckBox widget.</summary>
        /// <param name="isChecked">Whether the ThreeStateCheckBox is checked.</param>
        /// <param name="fn">Raised when the ThreeStateCheckBox is clicked.</param>
        static member inline ThreeStateCheckBox(isChecked: bool option, fn: bool option -> unit) =
            WidgetBuilder<unit, IFabMvuCheckBox>(
                CheckBox.WidgetKey,
                ToggleButton.IsThreeState.WithValue(true),
                MvuToggleButton.ThreeStateCheckedChanged.WithValue(
                    MvuValueEventData.createVOption (ThreeState.fromOption(isChecked)) (ThreeState.toOption >> fn)
                )
            )

        /// <summary>Creates a ThreeStateCheckBox widget.</summary>
        /// <param name="text">The ThreeStateCheckBox text.</param>
        /// <param name="isChecked">Whether the ThreeStateCheckBox is checked.</param>
        /// <param name="fn">Raised when the ThreeStateCheckBox is clicked.</param>
        static member inline ThreeStateCheckBox(text: string, isChecked: bool option, fn: bool option -> unit) =
            WidgetBuilder<unit, IFabMvuCheckBox>(
                CheckBox.WidgetKey,
                ToggleButton.IsThreeState.WithValue(true),
                ContentControl.ContentString.WithValue(text),
                MvuToggleButton.ThreeStateCheckedChanged.WithValue(
                    MvuValueEventData.createVOption (ThreeState.fromOption(isChecked)) (ThreeState.toOption >> fn)
                )
            )

        /// <summary>Creates a ThreeStateCheckBox widget.</summary>
        /// <param name="isChecked">Whether the ThreeStateCheckBox is checked.</param>
        /// <param name="fn">Raised when the ThreeStateCheckBox is clicked.</param>
        /// <param name="content">The ThreeStateCheckBox content.</param>
        static member inline ThreeStateCheckBox(isChecked: bool option, fn: bool option -> unit, content: WidgetBuilder<unit, #IFabMvuControl>) =
            WidgetBuilder<unit, IFabMvuCheckBox>(
                CheckBox.WidgetKey,
                AttributesBundle(
                    StackList.two(
                        MvuToggleButton.ThreeStateCheckedChanged.WithValue(
                            MvuValueEventData.createVOption (ThreeState.fromOption(isChecked)) (ThreeState.toOption >> fn)
                        ),
                        ToggleButton.IsThreeState.WithValue(true)
                    ),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )
