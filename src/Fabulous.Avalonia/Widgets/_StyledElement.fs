namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Styling
open Fabulous

type IFabStyledElement =
    inherit IFabAnimatable

module StyledElement =

    let Name = Attributes.defineAvaloniaPropertyWithEquality StyledElement.NameProperty

    let ActualThemeVariant =
        Attributes.defineAvaloniaPropertyWithEquality StyledElement.ActualThemeVariantProperty

    let RequestedThemeVariant =
        Attributes.defineAvaloniaPropertyWithEquality StyledElement.RequestedThemeVariantProperty

    let ActualThemeVariantChanged =
        Attributes.defineAvaloniaPropertyWithChangedEvent' "StyledElement_ActualThemeVariantChangedEvent" StyledElement.ActualThemeVariantProperty

    let RequestedThemeVariantChanged =
        Attributes.defineAvaloniaPropertyWithChangedEvent' "StyledElement_RequestedThemeVariantChangedEvent" StyledElement.RequestedThemeVariantProperty

[<Extension>]
type StyledElementModifiers =
    [<Extension>]
    static member inline name(this: WidgetBuilder<'msg, #IFabStyledElement>, name: string) =
        this.AddScalar(StyledElement.Name.WithValue(name))

    [<Extension>]
    static member inline actualThemeVariant(this: WidgetBuilder<'msg, #IFabStyledElement>, themeVariant: ThemeVariant) =
        this.AddScalar(StyledElement.ActualThemeVariant.WithValue(themeVariant))

    [<Extension>]
    static member inline requestedThemeVariant(this: WidgetBuilder<'msg, #IFabStyledElement>, themeVariant: ThemeVariant) =
        this.AddScalar(StyledElement.RequestedThemeVariant.WithValue(themeVariant))

    [<Extension>]
    static member inline onActualThemeVariantChanged(this: WidgetBuilder<'msg, #IFabStyledElement>, theme: ThemeVariant, onThemeChanged: ThemeVariant -> 'msg) =
        this.AddScalar(StyledElement.ActualThemeVariantChanged.WithValue(ValueEventData.create theme (fun args -> onThemeChanged args |> box)))

    [<Extension>]
    static member inline onRequestedThemeVariantChanged
        (
            this: WidgetBuilder<'msg, #IFabStyledElement>,
            theme: ThemeVariant,
            onThemeChanged: ThemeVariant -> 'msg
        ) =
        this.AddScalar(StyledElement.RequestedThemeVariantChanged.WithValue(ValueEventData.create theme (fun args -> onThemeChanged args |> box)))
