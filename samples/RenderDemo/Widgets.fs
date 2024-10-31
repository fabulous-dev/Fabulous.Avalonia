namespace RenderDemo

open System.Runtime.CompilerServices
open Avalonia.Media
open Controls.HamburgerMenu
open Fabulous
open Fabulous.Avalonia
open Fabulous.Avalonia.Mvu
open Fabulous.StackAllocatedCollections.StackList

type IFabHamburgerMenu =
    inherit IFabMvuTabControl

module HamburgerMenu =
    let WidgetKey = Widgets.register<HamburgerMenu>()

    let PaneBackground =
        Attributes.defineAvaloniaPropertyWithEquality HamburgerMenu.PaneBackgroundProperty

    let ContentBackground =
        Attributes.defineAvaloniaPropertyWithEquality HamburgerMenu.ContentBackgroundProperty

    let ExpandedModeThresholdWidth =
        Attributes.defineAvaloniaPropertyWithEquality HamburgerMenu.ExpandedModeThresholdWidthProperty

[<AutoOpen>]
module HamburgerMenuBuilders =

    type Fabulous.Avalonia.Mvu.View with

        static member HamburgerMenu() =
            CollectionBuilder<'msg, IFabHamburgerMenu, IFabMvuTabItem>(HamburgerMenu.WidgetKey, MvuItemsControl.Items)


type HamburgerMenuModifiers =
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabHamburgerMenu>, value: ViewRef<HamburgerMenu>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

    [<Extension>]
    static member inline paneBackground(this: WidgetBuilder<'msg, #IFabHamburgerMenu>, value: IBrush) =
        this.AddScalar(HamburgerMenu.PaneBackground.WithValue(value))

    [<Extension>]
    static member inline contentBackground(this: WidgetBuilder<'msg, #IFabHamburgerMenu>, value: IBrush) =
        this.AddScalar(HamburgerMenu.ContentBackground.WithValue(value))

    [<Extension>]
    static member inline expandedModeThresholdWidth(this: WidgetBuilder<'msg, #IFabHamburgerMenu>, value: int) =
        this.AddScalar(HamburgerMenu.ExpandedModeThresholdWidth.WithValue(value))

[<AutoOpen>]
module EmptyBorderBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a empty Border widget.</summary>
        static member EmptyBorder() =
            WidgetBuilder<'msg, IFabMvuBorder>(Border.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))
