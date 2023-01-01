namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabRadioButton =
    inherit IFabToggleButton

module RadioButton =
    let WidgetKey =
        Widgets.registerWithFactory (fun () -> RadioButton(IsThreeState = false))

    let IsChecked =
        Attributes.defineAvaloniaPropertyWithEquality RadioButton.IsCheckedProperty

    let GroupName =
        Attributes.defineAvaloniaPropertyWithEquality RadioButton.GroupNameProperty

[<AutoOpen>]
module RadioButtonBuilders =
    type Fabulous.Avalonia.View with

        static member inline RadioButton(text: string, isChecked: bool) =
            WidgetBuilder<'msg, IFabRadioButton>(
                RadioButton.WidgetKey,
                RadioButton.IsChecked.WithValue(isChecked),
                ContentControl.ContentString.WithValue(text)
            )

        static member inline RadioButton(content: WidgetBuilder<'msg, #IFabRadioButton>, isChecked: bool) =
            WidgetBuilder<'msg, IFabRadioButton>(
                RadioButton.WidgetKey,
                AttributesBundle(
                    StackList.one (RadioButton.IsChecked.WithValue(isChecked)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

[<Extension>]
type RadioButtonModifiers =
    [<Extension>]
    static member inline groupName(this: WidgetBuilder<'msg, #IFabControl>, value: string) =
        this.AddScalar(RadioButton.GroupName.WithValue(value))
