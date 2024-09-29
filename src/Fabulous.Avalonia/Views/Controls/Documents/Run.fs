namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Fabulous

type IFabRun =
    inherit IFabInline

module Run =
    let WidgetKey = Widgets.register<Run>()

    let Text = Attributes.defineAvaloniaPropertyWithEquality Run.TextProperty

type RunModifiers =
    /// <summary>Link a ViewRef to access the direct Run control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabRun>, value: ViewRef<Run>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
