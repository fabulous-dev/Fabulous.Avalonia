namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Fabulous

type IFabPath =
    inherit IFabShape

module Path =
    let WidgetKey = Widgets.register<Path>()

    let DataWidget = Attributes.defineAvaloniaPropertyWidget Path.DataProperty

    let DataString = Attributes.defineAvaloniaPropertyWithEquality Path.DataProperty


type PathModifiers =
    /// <summary>Link a ViewRef to access the direct Path control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabPath>, value: ViewRef<Path>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
