namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Fabulous

type IFabInlineUIContainer =
    inherit IFabInline

module InlineUIContainer =
    let WidgetKey = Widgets.register<InlineUIContainer>()

    let Children =
        Attributes.defineAvaloniaPropertyWidget InlineUIContainer.ChildProperty

type InlineUIContainerModifiers =
    /// <summary>Link a ViewRef to access the direct InlineUIContainer control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabInlineUIContainer>, value: ViewRef<InlineUIContainer>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
