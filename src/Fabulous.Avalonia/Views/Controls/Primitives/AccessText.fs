namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous

type IFabAccessText =
    inherit IFabTextBlock

module AccessText =
    let WidgetKey = Widgets.register<AccessText>()

    let ShowAccessKey =
        Attributes.defineAvaloniaPropertyWithEquality AccessText.ShowAccessKeyProperty

type AccessTextModifiers =
    /// <summary>Link a ViewRef to access the direct AccessText control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabAccessText>, value: ViewRef<AccessText>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
