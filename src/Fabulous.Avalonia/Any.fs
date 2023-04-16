namespace Fabulous.Avalonia

open Fabulous

[<AutoOpen>]
module AnyBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>
        /// Downcast widget to IFabControl to allow to return different types of views in a single expression (e.g. if/else, match with pattern, etc.).
        /// <example>
        /// <code lang="fsharp">
        /// match remote with
        /// | NotAsked
        /// | Loading -> AnyView(LoadingView())
        /// | Failure _ -> AnyView(errorView())
        /// | Success data -> AnyView(SuccessView(data))
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="widget">Widget to downcast.</param>
        static member AnyView<'msg, 'marker when 'marker :> IFabControl>(widget: WidgetBuilder<'msg, 'marker>) =
            WidgetBuilder<'msg, IFabControl>(widget.Key, widget.Attributes)
