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

    let IsChecked =
        Attributes.defineAvaloniaPropertyWithEquality ToggleButton.IsCheckedProperty

    let CheckedChanged =
        Attributes.defineEvent "ToggleButton_IsCheckedChanged" (fun target -> (target :?> ToggleButton).IsCheckedChanged)

    let IsThreeState =
        Attributes.defineAvaloniaPropertyWithEquality ToggleButton.IsThreeStateProperty

    let ThreeStateCheckedChanged =
        Attributes.defineAvaloniaPropertyWithChangedEvent' "ToggleButton_CheckedChanged" ToggleButton.IsCheckedProperty

[<AutoOpen>]
module ToggleButtonBuilders =
    type Fabulous.Avalonia.View with

        static member inline ToggleButton<'msg>(text: string, isChecked: bool, onValueChanged: bool -> 'msg) =
            WidgetBuilder<'msg, IFabToggleButton>(
                ToggleButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                ToggleButton.IsChecked.WithValue(isChecked),
                ToggleButton.CheckedChanged.WithValue(fun args ->
                    let control = args.Source :?> ToggleButton
                    let isChecked = Nullable.op_Explicit(control.IsChecked)
                    onValueChanged isChecked |> box)
            )

        static member inline ThreeStateToggleButton<'msg>(text: string, isChecked: bool option, onValueChanged: bool option -> 'msg) =
            WidgetBuilder<'msg, IFabToggleButton>(
                ToggleButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                ToggleButton.IsThreeState.WithValue(true),
                ToggleButton.ThreeStateCheckedChanged.WithValue(
                    ValueEventData.createVOption (ThreeState.fromOption(isChecked)) (fun args -> onValueChanged(ThreeState.toOption args) |> box)
                )
            )

        static member inline ToggleButton(isChecked: bool, onValueChanged: bool -> 'msg, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabToggleButton>(
                ToggleButton.WidgetKey,
                AttributesBundle(
                    StackList.two(
                        ToggleButton.CheckedChanged.WithValue(fun args ->
                            let control = args.Source :?> ToggleButton
                            let isChecked = Nullable.op_Explicit(control.IsChecked)
                            onValueChanged isChecked |> box),
                        ToggleButton.IsChecked.WithValue(isChecked)
                    ),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

        static member inline ThreeStateToggleButton(isChecked: bool option, onValueChanged: bool option -> 'msg, content: WidgetBuilder<'msg, #IFabControl>) =
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
    /// <summary>Link a ViewRef to access the direct ToggleButton control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabToggleButton>, value: ViewRef<ToggleButton>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
