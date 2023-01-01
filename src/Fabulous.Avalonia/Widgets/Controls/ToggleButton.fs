namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabToggleButton =
    inherit IFabButton

module ToggleButton =
    let WidgetKey = Widgets.register<ToggleButton> ()

    let IsThreeState =
        Attributes.defineAvaloniaPropertyWithEquality ToggleButton.IsThreeStateProperty

    let Indeterminate =
        Attributes.defineEvent "ToggleButton_Indeterminate" (fun target -> (target :?> ToggleButton).Indeterminate)

    let Checked =
        Attributes.defineEvent "ToggleButton_Checked" (fun target -> (target :?> ToggleButton).Checked)

    let Unchecked =
        Attributes.defineEvent "ToggleButton_Unchecked" (fun target -> (target :?> ToggleButton).Unchecked)

    let CheckedChanged =
        Attributes.defineAvaloniaPropertyWithChangedEvent
            "ToggleButton_CheckedChanged"
            ToggleButton.IsCheckedProperty
            Nullable
            Nullable.op_Explicit

[<AutoOpen>]
module ToggleButtonBuilders =
    type Fabulous.Avalonia.View with

        static member inline ToggleButton(text: string, onClicked: 'msg) =
            WidgetBuilder<'msg, IFabToggleButton>(
                ToggleButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                Button.Clicked.WithValue(fun _ -> box onClicked)
            )

        static member inline ToggleButton(content: WidgetBuilder<'msg, #IFabControl>, onClicked: 'msg) =
            WidgetBuilder<'msg, IFabToggleButton>(
                ToggleButton.WidgetKey,
                AttributesBundle(
                    StackList.one (Button.Clicked.WithValue(fun _ -> box onClicked)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

[<Extension>]
type ToggleButtonModifiers =
    [<Extension>]
    static member inline isThreeState(this: WidgetBuilder<'msg, #IFabToggleButton>, value: bool) =
        this.AddScalar(ToggleButton.IsThreeState.WithValue(value))

    [<Extension>]
    static member inline onIndeterminate(this: WidgetBuilder<'msg, #IFabToggleButton>, onIndeterminate: 'msg) =
        this.AddScalar(ToggleButton.Indeterminate.WithValue(fun _ -> onIndeterminate |> box))

    [<Extension>]
    static member inline onChecked(this: WidgetBuilder<'msg, #IFabToggleButton>, onChecked: 'msg) =
        this.AddScalar(ToggleButton.Checked.WithValue(fun _ -> onChecked |> box))

    [<Extension>]
    static member inline onUnchecked(this: WidgetBuilder<'msg, #IFabToggleButton>, onUnchecked: 'msg) =
        this.AddScalar(ToggleButton.Unchecked.WithValue(fun _ -> onUnchecked |> box))
