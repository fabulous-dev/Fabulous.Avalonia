namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous

type IFabStackPanel =
    inherit IFabPanel

module StackPanel =
    let WidgetKey = Widgets.register<StackPanel>()

    let Spacing =
        Attributes.defineAvaloniaPropertyWithEquality StackPanel.SpacingProperty

    let Orientation =
        Attributes.defineAvaloniaPropertyWithEquality StackPanel.OrientationProperty

    let AreHorizontalSnapPointsRegular =
        Attributes.defineAvaloniaPropertyWithEquality StackPanel.AreHorizontalSnapPointsRegularProperty

    let AreVerticalSnapPointsRegular =
        Attributes.defineAvaloniaPropertyWithEquality StackPanel.AreVerticalSnapPointsRegularProperty

    let HorizontalSnapPointsChanged =
        Attributes.defineEvent "StackPanel_HorizontalSnapPointsChanged" (fun target -> (target :?> StackPanel).HorizontalSnapPointsChanged)

    let VerticalSnapPointsChanged =
        Attributes.defineEvent "StackPanel_VerticalSnapPointsChanged" (fun target -> (target :?> StackPanel).VerticalSnapPointsChanged)

[<Extension>]
type StackPanelModifiers =
    [<Extension>]
    static member inline areHorizontalSnapPointsRegular(this: WidgetBuilder<'msg, #IFabStackPanel>, value: bool) =
        this.AddScalar(StackPanel.AreHorizontalSnapPointsRegular.WithValue(value))

    [<Extension>]
    static member inline areVerticalSnapPointsRegular(this: WidgetBuilder<'msg, #IFabStackPanel>, value: bool) =
        this.AddScalar(StackPanel.AreVerticalSnapPointsRegular.WithValue(value))

    [<Extension>]
    static member inline onHorizontalSnapPointsChanged(this: WidgetBuilder<'msg, #IFabStackPanel>, onHorizontalSnapPointsChanged: RoutedEventArgs -> 'msg) =
        this.AddScalar(StackPanel.HorizontalSnapPointsChanged.WithValue(fun args -> onHorizontalSnapPointsChanged args |> box))

    [<Extension>]
    static member inline onVerticalSnapPointsChanged(this: WidgetBuilder<'msg, #IFabStackPanel>, onVerticalSnapPointsChanged: RoutedEventArgs -> 'msg) =
        this.AddScalar(StackPanel.VerticalSnapPointsChanged.WithValue(fun args -> onVerticalSnapPointsChanged args |> box))

    /// <summary>Link a ViewRef to access the direct StackPanel control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabStackPanel>, value: ViewRef<StackPanel>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
