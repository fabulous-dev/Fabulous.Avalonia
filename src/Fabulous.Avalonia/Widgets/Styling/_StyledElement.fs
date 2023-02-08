namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Collections
open Avalonia.Styling
open Fabulous
open Fabulous.StackAllocatedCollections

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

    let Classes =
        Attributes.defineSimpleScalarWithEquality<string list> "StyledElement_Classes" (fun _ newValueOpt node ->
            let target = node.Target :?> StyledElement

            match newValueOpt with
            | ValueNone -> target.Classes.Clear()
            | ValueSome classes ->
                let coll = AvaloniaList<string>()
                classes |> List.iter coll.Add
                target.Classes.AddRange coll)

    let Styles =
        Attributes.defineAvaloniaListWidgetCollection "StyledElement_Styles" (fun target -> (target :?> StyledElement).Styles)

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

    [<Extension>]
    static member inline styles(this: WidgetBuilder<'msg, #IFabStyledElement>) =
        AttributeCollectionBuilder<'msg, #IFabStyledElement, IFabStyle>(this, StyledElement.Styles)

    [<Extension>]
    static member inline classes(this: WidgetBuilder<'msg, #IFabStyledElement>, classes: string list) =
        this.AddScalar(StyledElement.Classes.WithValue(classes))

    [<Extension>]
    static member inline style(this: WidgetBuilder<'msg, #IFabElement>, fn: WidgetBuilder<'msg, #IFabElement> -> WidgetBuilder<'msg, #IFabElement>) = fn this

[<Extension>]
type StyledElementCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'marker :> IFabStyledElement and 'itemType :> IFabStyle>
        (
            _: AttributeCollectionBuilder<'msg, 'marker, IFabStyle>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'marker :> IFabStyledElement and 'itemType :> IFabStyle>
        (
            _: AttributeCollectionBuilder<'msg, 'marker, IFabStyle>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
