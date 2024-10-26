namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentRadioButton =
    inherit IFabComponentToggleButton
    inherit IFabRadioButton


[<AutoOpen>]
module RadioButtonBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a RadioButton widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="isChecked">Whether the RadioButton is checked.</param>
        /// <param name="fn">Raised when the RadioButton is clicked.</param>
        static member RadioButton(text: string, isChecked: bool, fn: bool -> 'msg) =
            WidgetBuilder<unit, IFabComponentRadioButton>(
                RadioButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                ComponentToggleButton.CheckedChanged.WithValue(ComponentValueEventData.create isChecked fn)
            )

        /// <summary>Creates a ThreeStateRadioButton widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="isChecked">Whether the ThreeStateRadioButton is checked.</param>
        /// <param name="fn">Raised when the ThreeStateRadioButton is clicked.</param>
        static member ThreeStateRadioButton(text: string, isChecked: bool option, fn: bool option -> unit) =
            WidgetBuilder<unit, IFabComponentRadioButton>(
                RadioButton.WidgetKey,
                ToggleButton.IsThreeState.WithValue(true),
                ContentControl.ContentString.WithValue(text),
                ComponentToggleButton.ThreeStateCheckedChanged.WithValue(
                    ComponentValueEventData.createVOption (ThreeState.fromOption(isChecked)) (ThreeState.toOption >> fn)
                )
            )

        /// <summary>Creates a RadioButton widget.</summary>
        /// <param name="isChecked">Whether the RadioButton is checked.</param>
        /// <param name="fn">Raised when the RadioButton is clicked.</param>
        /// <param name="content">The content of the RadioButton.</param>
        static member RadioButton(isChecked: bool, fn: bool -> unit, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<unit, IFabComponentRadioButton>(
                RadioButton.WidgetKey,
                AttributesBundle(
                    StackList.one(ComponentToggleButton.CheckedChanged.WithValue(ComponentValueEventData.create isChecked fn)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a ThreeStateRadioButton widget.</summary>
        /// <param name="isChecked">Whether the ThreeStateRadioButton is checked.</param>
        /// <param name="fn">Raised when the ThreeStateRadioButton is clicked.</param>
        /// <param name="content">The content of the ThreeStateRadioButton.</param>
        static member ThreeStateRadioButton(isChecked: bool option, fn: bool option -> 'msg, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<unit, IFabRadioButton>(
                RadioButton.WidgetKey,
                AttributesBundle(
                    StackList.two(
                        ComponentToggleButton.ThreeStateCheckedChanged.WithValue(
                            ComponentValueEventData.createVOption (ThreeState.fromOption(isChecked)) (ThreeState.toOption >> fn)
                        ),
                        ToggleButton.IsThreeState.WithValue(true)
                    ),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

type ComponentRadioButtonAttachedModifiers =
    /// <summary>Link a ViewRef to access the direct RadioButton control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComponentRadioButton>, value: ViewRef<RadioButton>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))