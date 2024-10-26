namespace Fabulous.Avalonia.Components

open Fabulous

[<AutoOpen>]
module AnyBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Downcast widget to IFabControl to allow to return different types of views in a single expression (e.g. if/else, match with pattern, etc.).</summary>
        /// <param name="widget">Widget to downcast.</param>
        static member AnyView<'msg, 'marker when 'msg: equality and 'marker :> IFabComponentElement>(widget: WidgetBuilder<'msg, 'marker>) =
            WidgetBuilder<unit, IFabComponentControl>(widget.Key, widget.Attributes)
