namespace Fabulous.Avalonia

open Avalonia.Controls
open Avalonia.Layout
open Fabulous

type IFabStackPanel =
    inherit IFabPanel

module StackPanel =
    let WidgetKey = Widgets.register<StackPanel> ()

    let Spacing =
        Attributes.defineAvaloniaPropertyWithEquality StackPanel.SpacingProperty
        
    let Orientation =
        Attributes.defineAvaloniaPropertyWithEquality StackPanel.OrientationProperty

[<AutoOpen>]
module StackPanelBuilders =
    type Fabulous.Avalonia.View with

        static member VStack<'msg>(?spacing: float) =
            match spacing with
            | Some spacing ->
                CollectionBuilder<'msg, IFabStackPanel, IFabControl>(
                    StackPanel.WidgetKey,
                    Panel.Children,
                    StackPanel.Orientation.WithValue(Orientation.Vertical),
                    StackPanel.Spacing.WithValue(spacing)
                )
            | None ->
                CollectionBuilder<'msg, IFabStackPanel, IFabControl>(
                    StackPanel.WidgetKey,
                    Panel.Children,
                    StackPanel.Orientation.WithValue(Orientation.Vertical),
                    StackPanel.Spacing.WithValue(0.)
                )

        static member HStack<'msg>(?spacing: float) =
            match spacing with
            | Some spacing ->
                CollectionBuilder<'msg, IFabStackPanel, IFabControl>(
                    StackPanel.WidgetKey,
                    Panel.Children,
                    StackPanel.Orientation.WithValue(Orientation.Horizontal),
                    StackPanel.Spacing.WithValue(spacing)
                )
            | None ->
                CollectionBuilder<'msg, IFabStackPanel, IFabControl>(
                    StackPanel.WidgetKey,
                    Panel.Children,
                    StackPanel.Orientation.WithValue(Orientation.Horizontal),
                    StackPanel.Spacing.WithValue(0.)
                )
