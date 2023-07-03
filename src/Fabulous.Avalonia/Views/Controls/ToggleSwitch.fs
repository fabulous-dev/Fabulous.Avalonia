namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia.Animation
open Avalonia.Controls
open Fabulous

type IFabToggleSwitch =
    inherit IFabToggleButton

module ToggleSwitch =
    let WidgetKey = Widgets.register<ToggleSwitch>()

    let OffContent =
        Attributes.defineAvaloniaProperty<string, obj> ToggleSwitch.OffContentProperty box ScalarAttributeComparers.equalityCompare

    let OffContentWidget =
        Attributes.defineAvaloniaPropertyWidget ToggleSwitch.OffContentProperty

    let OnContent =
        Attributes.defineAvaloniaProperty<string, obj> ToggleSwitch.OnContentProperty box ScalarAttributeComparers.equalityCompare

    let OnContentWidget =
        Attributes.defineAvaloniaPropertyWidget ToggleSwitch.OnContentProperty

    let KnobTransitions =
        Attributes.defineAvaloniaListWidgetCollection "ToggleSwitch_KnobTransitions" (fun target ->
            let target = (target :?> ToggleSwitch)

            if target.Transitions = null then
                let newColl = Transitions()
                target.Transitions <- newColl
                newColl
            else
                target.Transitions)

[<AutoOpen>]
module ToggleSwitchBuilders =
    type Fabulous.Avalonia.View with

        static member inline ToggleSwitch<'msg>(isChecked: bool, onValueChanged: bool -> 'msg) =
            WidgetBuilder<'msg, IFabToggleSwitch>(
                ToggleSwitch.WidgetKey,
                ToggleButton.IsThreeState.WithValue(false),
                ToggleButton.CheckedChanged.WithValue(ValueEventData.create isChecked (fun args -> onValueChanged args |> box))
            )

        static member inline ThreeStateToggleSwitch<'msg>(isChecked: bool option, onValueChanged: bool option -> 'msg) =
            WidgetBuilder<'msg, IFabToggleSwitch>(
                ToggleSwitch.WidgetKey,
                ToggleButton.IsThreeState.WithValue(true),
                ToggleButton.ThreeStateCheckedChanged.WithValue(
                    ValueEventData.createVOption (ThreeState.fromOption(isChecked)) (fun args -> onValueChanged(ThreeState.toOption args) |> box)
                )
            )

[<Extension>]
type ToggleSwitchModifiers =
    [<Extension>]
    static member inline offContent(this: WidgetBuilder<'msg, #IFabToggleSwitch>, value: string) =
        this.AddScalar(ToggleSwitch.OffContent.WithValue(value))

    [<Extension>]
    static member inline offContent(this: WidgetBuilder<'msg, #IFabToggleSwitch>, content: WidgetBuilder<'msg, #IFabControl>) =
        this.AddWidget(ToggleSwitch.OffContentWidget.WithValue(content.Compile()))

    [<Extension>]
    static member inline onContent(this: WidgetBuilder<'msg, #IFabToggleSwitch>, value: string) =
        this.AddScalar(ToggleSwitch.OnContent.WithValue(value))

    [<Extension>]
    static member inline onContent(this: WidgetBuilder<'msg, #IFabToggleSwitch>, content: WidgetBuilder<'msg, #IFabControl>) =
        this.AddWidget(ToggleSwitch.OnContentWidget.WithValue(content.Compile()))

    [<Extension>]
    static member inline content(this: WidgetBuilder<'msg, #IFabToggleSwitch>, value: string) =
        this.AddScalar(ContentControl.ContentString.WithValue(value))

    [<Extension>]
    static member inline content(this: WidgetBuilder<'msg, #IFabToggleSwitch>, content: WidgetBuilder<'msg, #IFabControl>) =
        this.AddWidget(ContentControl.ContentWidget.WithValue(content.Compile()))

    [<Extension>]
    static member inline knobTransitions(this: WidgetBuilder<'msg, #IFabToggleSwitch>) =
        AttributeCollectionBuilder<'msg, #IFabToggleSwitch, IFabTransition>(this, ToggleSwitch.KnobTransitions)

    [<Extension>]
    static member inline knobTransition(this: WidgetBuilder<'msg, #IFabToggleSwitch>, transition: WidgetBuilder<'msg, #IFabTransition>) =
        AttributeCollectionBuilder<'msg, #IFabToggleSwitch, IFabTransition>(this, ToggleSwitch.KnobTransitions) { transition }

    /// <summary>Link a ViewRef to access the direct ToggleSwitch control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabToggleSwitch>, value: ViewRef<ToggleSwitch>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
