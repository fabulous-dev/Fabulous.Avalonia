namespace Fabulous.Avalonia.Mvu

open System
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuToggleButton =
    inherit IFabMvuButton
    inherit IFabToggleButton

module ThreeState =
    let inline fromOption (value: bool option) =
        match value with
        | Some true -> ValueSome(Nullable(true))
        | Some false -> ValueSome(Nullable(false))
        | None -> ValueNone

    let inline fromOption' (value: bool option) =
        match value with
        | Some true -> Nullable(true)
        | Some false -> Nullable(false)
        | None -> Nullable()

    let inline toOption (value: Nullable<bool>) = Option.ofNullable value

module MvuToggleButton =

    let CheckedChanged =
        MvuAttributes.defineAvaloniaPropertyWithChangedEvent "ToggleButton_IsCheckedChanged" ToggleButton.IsCheckedProperty Nullable Nullable.op_Explicit

    let ThreeStateCheckedChanged =
        MvuAttributes.defineAvaloniaPropertyWithChangedEvent' "ToggleButton_CheckedChanged" ToggleButton.IsCheckedProperty

[<AutoOpen>]
module MvuToggleButtonBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a ToggleButton widget.</summary>
        /// <param name="text">The text of the ToggleButton.</param>
        /// <param name="isChecked">Whether the ToggleButton is checked.</param>
        /// <param name="fn">Raised when the ToggleButton is clicked.</param>
        static member ToggleButton(text: string, isChecked: bool, fn: bool -> 'msg) =
            WidgetBuilder<'msg, IFabMvuToggleButton>(
                ToggleButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                MvuToggleButton.CheckedChanged.WithValue(MvuValueEventData.create isChecked fn)
            )

        /// <summary>Creates a ThreeStateToggleButton widget.</summary>
        /// <param name="text">The text of the ThreeStateToggleButton.</param>
        /// <param name="isChecked">Whether the ThreeStateToggleButton is checked.</param>
        /// <param name="fn">Raised when the ThreeStateToggleButton is clicked.</param>
        static member ThreeStateToggleButton(text: string, isChecked: bool option, fn: bool option -> 'msg) =
            WidgetBuilder<'msg, IFabMvuToggleButton>(
                ToggleButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                ToggleButton.IsThreeState.WithValue(true),
                MvuToggleButton.ThreeStateCheckedChanged.WithValue(
                    MvuValueEventData.createVOption (ThreeState.fromOption(isChecked)) (ThreeState.toOption >> fn)
                )
            )

        /// <summary>Creates a ToggleButton widget.</summary>
        /// <param name="isChecked">Whether the ToggleButton is checked.</param>
        /// <param name="fn">Raised when the ToggleButton is clicked.</param>
        /// <param name="content">The content of the ToggleButton.</param>
        static member ToggleButton(isChecked: bool, fn: bool -> 'msg, content: WidgetBuilder<'msg, #IFabMvuControl>) =
            WidgetBuilder<'msg, IFabMvuToggleButton>(
                ToggleButton.WidgetKey,
                AttributesBundle(
                    StackList.one(MvuToggleButton.CheckedChanged.WithValue(MvuValueEventData.create isChecked fn)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a ThreeStateToggleButton widget.</summary>
        /// <param name="isChecked">Whether the ThreeStateToggleButton is checked.</param>
        /// <param name="fn">Raised when the ThreeStateToggleButton is clicked.</param>
        /// <param name="content">The content of the ThreeStateToggleButton.</param>
        static member ThreeStateToggleButton(isChecked: bool option, fn: bool option -> 'msg, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabMvuToggleButton>(
                ToggleButton.WidgetKey,
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
