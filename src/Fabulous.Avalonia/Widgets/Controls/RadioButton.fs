namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabRadioButton =
    inherit IFabToggleButton

module RadioButton =
    let WidgetKey = Widgets.register<RadioButton>()

    let GroupName =
        Attributes.defineAvaloniaPropertyWithEquality RadioButton.GroupNameProperty

[<AutoOpen>]
module RadioButtonBuilders =
    type Fabulous.Avalonia.View with

        static member inline RadioButton<'msg>(text: string, isChecked: bool, onValueChanged: bool -> 'msg) =
            WidgetBuilder<'msg, IFabRadioButton>(
                RadioButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                ToggleButton.IsChecked.WithValue(isChecked),
                ToggleButton.CheckedChanged.WithValue(fun args ->
                    let control = args.Source :?> RadioButton
                    let isChecked = Nullable.op_Explicit(control.IsChecked)
                    onValueChanged isChecked |> box)
            )

        static member inline ThreeStateRadioButton<'msg>(text: string, isChecked: bool option, onValueChanged: bool option -> 'msg) =
            WidgetBuilder<'msg, IFabRadioButton>(
                RadioButton.WidgetKey,
                ToggleButton.IsThreeState.WithValue(true),
                ContentControl.ContentString.WithValue(text),
                ToggleButton.ThreeStateCheckedChanged.WithValue(
                    ValueEventData.createVOption (ThreeState.fromOption(isChecked)) (fun args -> onValueChanged(ThreeState.toOption args) |> box)
                )
            )

        static member inline RadioButton(isChecked: bool, onValueChanged: bool -> 'msg, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabRadioButton>(
                RadioButton.WidgetKey,
                AttributesBundle(
                    StackList.two(
                        ToggleButton.IsChecked.WithValue(isChecked),
                        ToggleButton.CheckedChanged.WithValue(fun args ->
                            let control = args.Source :?> RadioButton
                            let isChecked = Nullable.op_Explicit(control.IsChecked)
                            onValueChanged isChecked |> box)
                    ),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

        static member inline ThreeStateRadioButton(isChecked: bool option, onValueChanged: bool option -> 'msg, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabRadioButton>(
                RadioButton.WidgetKey,
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
type RadioButtonAttachedModifiers =
    [<Extension>]
    static member inline groupName(this: WidgetBuilder<'msg, #IFabControl>, value: string) =
        this.AddScalar(RadioButton.GroupName.WithValue(value))
