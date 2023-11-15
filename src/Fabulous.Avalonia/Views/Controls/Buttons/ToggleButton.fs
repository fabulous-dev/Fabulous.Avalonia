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

    let CheckedChanged =
        Attributes.defineAvaloniaPropertyWithChangedEvent "ToggleButton_IsCheckedChanged" ToggleButton.IsCheckedProperty Nullable Nullable.op_Explicit

    let IsThreeState =
        Attributes.defineAvaloniaPropertyWithEquality ToggleButton.IsThreeStateProperty

    let ThreeStateCheckedChanged =
        Attributes.defineAvaloniaPropertyWithChangedEvent' "ToggleButton_CheckedChanged" ToggleButton.IsCheckedProperty

[<AutoOpen>]
module ToggleButtonBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ToggleButton widget.</summary>
        /// <param name="text">The text of the ToggleButton.</param>
        /// <param name="isChecked">Whether the ToggleButton is checked.</param>
        /// <param name="fn">Raised when the ToggleButton is clicked.</param>
        static member inline ToggleButton<'msg>(text: string, isChecked: bool, fn: bool -> 'msg) =
            WidgetBuilder<'msg, IFabToggleButton>(
                ToggleButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                ToggleButton.CheckedChanged.WithValue(ValueEventData.create isChecked fn)
            )

        /// <summary>Creates a ThreeStateToggleButton widget.</summary>
        /// <param name="text">The text of the ThreeStateToggleButton.</param>
        /// <param name="isChecked">Whether the ThreeStateToggleButton is checked.</param>
        /// <param name="fn">Raised when the ThreeStateToggleButton is clicked.</param>
        static member inline ThreeStateToggleButton<'msg>(text: string, isChecked: bool option, fn: bool option -> 'msg) =
            WidgetBuilder<'msg, IFabToggleButton>(
                ToggleButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                ToggleButton.IsThreeState.WithValue(true),
                ToggleButton.ThreeStateCheckedChanged.WithValue(ValueEventData.createVOption (ThreeState.fromOption(isChecked)) (ThreeState.toOption >> fn))
            )

        /// <summary>Creates a ToggleButton widget.</summary>
        /// <param name="isChecked">Whether the ToggleButton is checked.</param>
        /// <param name="fn">Raised when the ToggleButton is clicked.</param>
        /// <param name="content">The content of the ToggleButton.</param>
        static member inline ToggleButton(isChecked: bool, fn: bool -> 'msg, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabToggleButton>(
                ToggleButton.WidgetKey,
                AttributesBundle(
                    StackList.one(ToggleButton.CheckedChanged.WithValue(ValueEventData.create isChecked fn)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a ThreeStateToggleButton widget.</summary>
        /// <param name="isChecked">Whether the ThreeStateToggleButton is checked.</param>
        /// <param name="fn">Raised when the ThreeStateToggleButton is clicked.</param>
        /// <param name="content">The content of the ThreeStateToggleButton.</param>
        static member inline ThreeStateToggleButton(isChecked: bool option, fn: bool option -> 'msg, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabToggleButton>(
                ToggleButton.WidgetKey,
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

type ToggleButtonModifiers =
    /// <summary>Link a ViewRef to access the direct ToggleButton control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabToggleButton>, value: ViewRef<ToggleButton>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
