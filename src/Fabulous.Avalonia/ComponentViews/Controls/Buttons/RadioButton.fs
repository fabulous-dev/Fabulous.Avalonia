namespace Fabulous.Avalonia.Components

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

        /// <summary>Creates a RadioButton widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="isChecked">Whether the RadioButton is checked.</param>
        /// <param name="fn">Raised when the RadioButton is clicked.</param>
        static member RadioButton(text: string, isChecked: bool, fn: bool -> 'msg) =
            WidgetBuilder<'msg, IFabRadioButton>(
                RadioButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                ToggleButton.CheckedChanged.WithValue(ValueEventData.create isChecked fn)
            )

        /// <summary>Creates a ThreeStateRadioButton widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="isChecked">Whether the ThreeStateRadioButton is checked.</param>
        /// <param name="fn">Raised when the ThreeStateRadioButton is clicked.</param>
        static member ThreeStateRadioButton(text: string, isChecked: bool option, fn: bool option -> 'msg) =
            WidgetBuilder<'msg, IFabRadioButton>(
                RadioButton.WidgetKey,
                ToggleButton.IsThreeState.WithValue(true),
                ContentControl.ContentString.WithValue(text),
                ToggleButton.ThreeStateCheckedChanged.WithValue(ValueEventData.createVOption (ThreeState.fromOption(isChecked)) (ThreeState.toOption >> fn))
            )

        /// <summary>Creates a RadioButton widget.</summary>
        /// <param name="isChecked">Whether the RadioButton is checked.</param>
        /// <param name="fn">Raised when the RadioButton is clicked.</param>
        /// <param name="content">The content of the RadioButton.</param>
        static member RadioButton(isChecked: bool, fn: bool -> 'msg, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabRadioButton>(
                RadioButton.WidgetKey,
                AttributesBundle(
                    StackList.one(ToggleButton.CheckedChanged.WithValue(ValueEventData.create isChecked fn)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a ThreeStateRadioButton widget.</summary>
        /// <param name="isChecked">Whether the ThreeStateRadioButton is checked.</param>
        /// <param name="fn">Raised when the ThreeStateRadioButton is clicked.</param>
        /// <param name="content">The content of the ThreeStateRadioButton.</param>
        static member ThreeStateRadioButton(isChecked: bool option, fn: bool option -> 'msg, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabRadioButton>(
                RadioButton.WidgetKey,
                AttributesBundle(
                    StackList.two(
                        ToggleButton.ThreeStateCheckedChanged.WithValue(
                            ValueEventData.createVOption (ThreeState.fromOption(isChecked)) (ThreeState.toOption >> fn)
                        ),
                        ToggleButton.IsThreeState.WithValue(true)
                    ),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

type RadioButtonAttachedModifiers =
    /// <summary>Sets the GroupName property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The GroupName value.</param>
    [<Extension>]
    static member inline groupName(this: WidgetBuilder<'msg, #IFabControl>, value: string) =
        this.AddScalar(RadioButton.GroupName.WithValue(value))

    /// <summary>Link a ViewRef to access the direct RadioButton control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabRadioButton>, value: ViewRef<RadioButton>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
