namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabPathIcon =
    inherit IFabIconElement

module PathIcon =
    let WidgetKey = Widgets.register<PathIcon>()

    let DataWidget = Attributes.defineAvaloniaPropertyWidget PathIcon.DataProperty

    let DataString = Attributes.defineAvaloniaPropertyWithEquality PathIcon.DataProperty

type PathIconModifiers =
    /// <summary>Link a ViewRef to access the direct PathIcon control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabPathIcon>, value: ViewRef<PathIcon>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
