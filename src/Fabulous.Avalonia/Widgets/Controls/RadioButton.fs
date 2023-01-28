namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabRadioButton =
    inherit IFabToggleButton

module RadioButton =
    let WidgetKey = Widgets.register<RadioButton>()

    let IsChecked =
        Attributes.defineAvaloniaPropertyWithEquality RadioButton.IsCheckedProperty

    let GroupName =
        Attributes.defineAvaloniaPropertyWithEquality RadioButton.GroupNameProperty

    let Checked =
        Attributes.defineEvent "RadioButton_Checked" (fun target -> (target :?> RadioButton).Checked)

    let Unchecked =
        Attributes.defineEvent "RadioButton_Unchecked" (fun target -> (target :?> RadioButton).Unchecked)

[<AutoOpen>]
module RadioButtonBuilders =
    type Fabulous.Avalonia.View with

        static member inline RadioButton<'msg>(text: string, isChecked: bool) =
            WidgetBuilder<'msg, IFabRadioButton>(
                RadioButton.WidgetKey,
                ToggleButton.IsThreeState.WithValue(false),
                ContentControl.ContentString.WithValue(text),
                RadioButton.IsChecked.WithValue(isChecked)
            )

        static member inline ThreeStateRadioButton<'msg>(text: string, isChecked: bool option) =
            WidgetBuilder<'msg, IFabRadioButton>(
                RadioButton.WidgetKey,
                ToggleButton.IsThreeState.WithValue(true),
                ContentControl.ContentString.WithValue(text),
                RadioButton.IsChecked.WithValue(Option.toNullable(isChecked))
            )

        static member inline RadioButton(isChecked: bool, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabRadioButton>(
                RadioButton.WidgetKey,
                AttributesBundle(
                    StackList.two(RadioButton.IsChecked.WithValue(isChecked), ToggleButton.IsThreeState.WithValue(false)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

        static member inline ThreeStateRadioButton(isChecked: bool option, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabRadioButton>(
                RadioButton.WidgetKey,
                AttributesBundle(
                    StackList.two(RadioButton.IsChecked.WithValue(ThreeState.fromOption'(isChecked)), ToggleButton.IsThreeState.WithValue(true)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

[<Extension>]
type RadioButtonModifiers =
    [<Extension>]
    static member inline groupName(this: WidgetBuilder<'msg, #IFabControl>, value: string) =
        this.AddScalar(RadioButton.GroupName.WithValue(value))


    [<Extension>]
    static member inline onChecked(this: WidgetBuilder<'msg, #IFabRadioButton>, onChecked: 'msg) =
        this.AddScalar(RadioButton.Checked.WithValue(fun _ -> onChecked |> box))

    [<Extension>]
    static member inline onUnchecked(this: WidgetBuilder<'msg, #IFabRadioButton>, onUnchecked: 'msg) =
        this.AddScalar(RadioButton.Unchecked.WithValue(fun _ -> onUnchecked |> box))
