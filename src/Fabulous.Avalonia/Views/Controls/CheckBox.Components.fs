namespace Fabulous.Avalonia

open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

[<AutoOpen>]
module ComponentCheckBoxBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a CheckBox widget.</summary>
        /// <param name="isChecked">Whether the CheckBox is checked.</param>
        /// <param name="fn">Raised when the CheckBox is clicked.</param>
        static member CheckBox(isChecked: bool, fn: bool -> unit) =
            WidgetBuilder<unit, IFabCheckBox>(CheckBox.WidgetKey, ComponentToggleButton.CheckedChanged.WithValue(ComponentValueEventData.create isChecked fn))

        /// <summary>Creates a CheckBox widget.</summary>
        /// <param name="text">The CheckBox text.</param>
        /// <param name="isChecked">Whether the CheckBox is checked.</param>
        /// <param name="fn">Raised when the CheckBox is clicked.</param>
        static member CheckBox(text: string, isChecked: bool, fn: bool -> unit) =
            WidgetBuilder<unit, IFabCheckBox>(
                CheckBox.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                ComponentToggleButton.CheckedChanged.WithValue(ComponentValueEventData.create isChecked fn)
            )

        /// <summary>Creates a CheckBox widget</summary>
        /// <param name="isChecked">Whether the CheckBox is checked.</param>
        /// <param name="fn">Raised when the CheckBox is clicked.</param>
        /// <param name="content">The CheckBox content.</param>
        static member CheckBox(isChecked: bool, fn: bool -> unit, content: WidgetBuilder<unit, #IFabControl>) =
            WidgetBuilder<unit, IFabCheckBox>(
                CheckBox.WidgetKey,
                AttributesBundle(
                    StackList.one(ComponentToggleButton.CheckedChanged.WithValue(ComponentValueEventData.create isChecked fn)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a ThreeStateCheckBox widget.</summary>
        /// <param name="isChecked">Whether the ThreeStateCheckBox is checked.</param>
        /// <param name="fn">Raised when the ThreeStateCheckBox is clicked.</param>
        static member inline ThreeStateCheckBox(isChecked: bool option, fn: bool option -> unit) =
            WidgetBuilder<unit, IFabCheckBox>(
                CheckBox.WidgetKey,
                ToggleButton.IsThreeState.WithValue(true),
                ComponentToggleButton.ThreeStateCheckedChanged.WithValue(
                    ComponentValueEventData.createVOption (ThreeState.fromOption(isChecked)) (ThreeState.toOption >> fn)
                )
            )

        /// <summary>Creates a ThreeStateCheckBox widget.</summary>
        /// <param name="text">The ThreeStateCheckBox text.</param>
        /// <param name="isChecked">Whether the ThreeStateCheckBox is checked.</param>
        /// <param name="fn">Raised when the ThreeStateCheckBox is clicked.</param>
        static member inline ThreeStateCheckBox(text: string, isChecked: bool option, fn: bool option -> unit) =
            WidgetBuilder<unit, IFabCheckBox>(
                CheckBox.WidgetKey,
                ToggleButton.IsThreeState.WithValue(true),
                ContentControl.ContentString.WithValue(text),
                ComponentToggleButton.ThreeStateCheckedChanged.WithValue(
                    ComponentValueEventData.createVOption (ThreeState.fromOption(isChecked)) (ThreeState.toOption >> fn)
                )
            )

        /// <summary>Creates a ThreeStateCheckBox widget.</summary>
        /// <param name="isChecked">Whether the ThreeStateCheckBox is checked.</param>
        /// <param name="fn">Raised when the ThreeStateCheckBox is clicked.</param>
        /// <param name="content">The ThreeStateCheckBox content.</param>
        static member inline ThreeStateCheckBox(isChecked: bool option, fn: bool option -> unit, content: WidgetBuilder<unit, #IFabControl>) =
            WidgetBuilder<unit, IFabCheckBox>(
                CheckBox.WidgetKey,
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
