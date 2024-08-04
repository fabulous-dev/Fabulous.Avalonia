namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

type IFabComponentDashStyle =
    inherit IFabComponentAnimatable
    inherit IFabDashStyle

[<AutoOpen>]
module ComponentDashStyleBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a DashStyle widget.</summary>
        /// <param name="dashes">The length of alternating dashes and gaps.</param>
        /// <param name="offset">How far in the dash sequence the stroke will start.</param>
        static member DashStyle(dashes: float list, offset: float) =
            WidgetBuilder<unit, IFabComponentDashStyle>(DashStyle.WidgetKey, DashStyle.Dashes.WithValue(dashes), DashStyle.Offset.WithValue(offset))

type ComponentDashStyleModifiers =

    /// <summary>Link a ViewRef to access the direct DashStyle control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComponentDashStyle>, value: ViewRef<DashStyle>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
