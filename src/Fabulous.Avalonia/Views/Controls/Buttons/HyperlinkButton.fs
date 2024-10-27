namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabHyperlinkButton =
    inherit IFabButton

module HyperlinkButton =
    let WidgetKey = Widgets.register<HyperlinkButton>()

    let NavigateUri =
        Attributes.defineAvaloniaPropertyWithEquality HyperlinkButton.NavigateUriProperty

    let IsVisited =
        Attributes.defineAvaloniaPropertyWithEquality HyperlinkButton.IsVisitedProperty

type HyperlinkButtonModifiers =

    /// <summary>Sets the IsVisited property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsVisited value.</param>
    [<Extension>]
    static member inline isVisited(this: WidgetBuilder<'msg, #IFabHyperlinkButton>, value: bool) =
        this.AddScalar(HyperlinkButton.IsVisited.WithValue(value))

    /// <summary>Link a ViewRef to access the direct HyperlinkButton control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabHyperlinkButton>, value: ViewRef<HyperlinkButton>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
