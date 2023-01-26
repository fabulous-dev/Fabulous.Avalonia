namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabToggleButton =
    inherit IFabButton

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

module ToggleButton =
    let WidgetKey = Widgets.register<ToggleButton>()

    let Indeterminate =
        Attributes.defineEvent "ToggleButton_Indeterminate" (fun target -> (target :?> ToggleButton).Indeterminate)

    let IsThreeState =
        Attributes.defineAvaloniaPropertyWithEquality ToggleButton.IsThreeStateProperty

    let CheckedChanged =
        Attributes.defineAvaloniaPropertyWithChangedEvent "ToggleButton_CheckedChanged" ToggleButton.IsCheckedProperty Nullable Nullable.op_Explicit

    let ThreeStateCheckedChanged =
        Attributes.defineAvaloniaPropertyWithChangedEvent' "ToggleButton_CheckedChanged" ToggleButton.IsCheckedProperty

[<AutoOpen>]
module ToggleButtonBuilders =
    type Fabulous.Avalonia.View with

        static member inline ToggleButton<'msg>(text: string, onValueChanged: bool -> 'msg, isChecked: bool) =
            WidgetBuilder<'msg, IFabToggleButton>(
                ToggleButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                ToggleButton.IsThreeState.WithValue(false),
                ToggleButton.CheckedChanged.WithValue(ValueEventData.create isChecked (fun args -> onValueChanged args |> box))
            )

        static member inline ThreeStateToggleButton<'msg>(text: string, onValueChanged: bool option -> 'msg, isChecked: bool option) =
            WidgetBuilder<'msg, IFabToggleButton>(
                ToggleButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                ToggleButton.IsThreeState.WithValue(true),
                ToggleButton.ThreeStateCheckedChanged.WithValue(
                    ValueEventData.createVOption (ThreeState.fromOption(isChecked)) (fun args -> onValueChanged(ThreeState.toOption args) |> box)
                )
            )

        static member inline ToggleButton(onValueChanged: bool -> 'msg, isChecked: bool, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabToggleButton>(
                ToggleButton.WidgetKey,
                AttributesBundle(
                    StackList.two(
                        ToggleButton.CheckedChanged.WithValue(ValueEventData.create isChecked (fun args -> onValueChanged args |> box)),
                        ToggleButton.IsThreeState.WithValue(false)
                    ),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

        static member inline ThreeStateToggleButton(onValueChanged: bool option -> 'msg, isChecked: bool option, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabToggleButton>(
                ToggleButton.WidgetKey,
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

[<Extension>]
type ToggleButtonModifiers =
    [<Extension>]
    static member inline onIndeterminate(this: WidgetBuilder<'msg, #IFabToggleButton>, onIndeterminate: 'msg) =
        this.AddScalar(ToggleButton.Indeterminate.WithValue(fun _ -> onIndeterminate |> box))
