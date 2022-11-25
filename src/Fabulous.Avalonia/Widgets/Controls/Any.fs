namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections

[<AutoOpen>]
module AnyBuilders =
    type Fabulous.Avalonia.View with
        /// Downcast to IView to allow to return different types of views in a single expression (e.g. if/else, match with pattern, etc.)
        static member AnyView<'msg, 'marker when 'marker :> IFabControl>(widget: WidgetBuilder<'msg, 'marker>) =
            WidgetBuilder<'msg, IFabControl>(widget.Key, widget.Attributes)
