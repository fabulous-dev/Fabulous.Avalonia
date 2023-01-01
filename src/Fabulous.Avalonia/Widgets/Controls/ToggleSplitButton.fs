namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabToggleSplitButton =
    inherit IFabSplitButton

module ToggleSplitButton =
    let WidgetKey = Widgets.register<ToggleSplitButton> ()

    let CheckedChanged =
        Attributes.defineAvaloniaPropertyWithChangedEvent'
            "ToggleSplitButton_CheckedChanged"
            ToggleSplitButton.IsCheckedProperty

[<AutoOpen>]
module ToggleSplitButtonBuilders =
    type Fabulous.Avalonia.View with

        static member inline ToggleSplitButton(text: string, onClicked: 'msg) =
            WidgetBuilder<'msg, IFabToggleSplitButton>(
                ToggleSplitButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                SplitButton.Clicked.WithValue(fun _ -> box onClicked)
            )

        static member inline ToggleSplitButton(content: WidgetBuilder<'msg, #IFabControl>, onClicked: 'msg) =
            WidgetBuilder<'msg, IFabToggleSplitButton>(
                ToggleSplitButton.WidgetKey,
                AttributesBundle(
                    StackList.one (SplitButton.Clicked.WithValue(fun _ -> box onClicked)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

[<Extension>]
type ToggleSplitButtonModifiers =
    [<Extension>]
    static member inline onCheckedChanged
        (
            splitButton: WidgetBuilder<'msg, #IFabToggleSplitButton>,
            isChecked: bool,
            onCheckedChanged: bool -> 'msg
        ) =
        splitButton.AddScalar(
            ToggleSplitButton.CheckedChanged.WithValue(
                ValueEventData.create isChecked (fun args -> onCheckedChanged args |> box)
            )
        )
