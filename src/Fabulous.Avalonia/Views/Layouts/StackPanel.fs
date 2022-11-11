namespace Fabulous.Avalonia

open Avalonia.Controls
open Avalonia.Layout
open Fabulous

type IFabStackPanel = inherit IFabPanel

module StackPanel =
    let WidgetKey = Widgets.register<StackPanel>()
    
    let Orientation = Attributes.defineStyledWithEquality StackPanel.OrientationProperty
    
[<AutoOpen>]
module StackPanelBuilders =
    type Fabulous.Avalonia.View with
        static member VStack<'msg>() =
            CollectionBuilder<'msg, IFabStackPanel, IFabControl>(
                StackPanel.WidgetKey,
                Panel.Children,
                StackPanel.Orientation.WithValue(Orientation.Vertical)
            )
            
        static member HStack<'msg>() =
            CollectionBuilder<'msg, IFabStackPanel, IFabControl>(
                StackPanel.WidgetKey,
                Panel.Children,
                StackPanel.Orientation.WithValue(Orientation.Horizontal)
            )

