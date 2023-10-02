namespace RenderDemo

open System.Runtime.CompilerServices
open Avalonia.Media
open Controls.HamburgerMenu
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabHamburgerMenu =
    inherit IFabTabControl

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

    type Fabulous.Avalonia.View with

        static member inline HamburgerMenu() =
            CollectionBuilder<'msg, IFabHamburgerMenu, IFabTabItem>(HamburgerMenu.WidgetKey, ItemsControl.Items)


[<Extension>]
type HamburgerMenuModifiers =
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabHamburgerMenu>, value: ViewRef<HamburgerMenu>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

    [<Extension>]
    static member inline paneBackground(this: WidgetBuilder<'msg, IFabHamburgerMenu>, value: IBrush) =
        this.AddScalar(HamburgerMenu.PaneBackground.WithValue(value))

    [<Extension>]
    static member inline contentBackground(this: WidgetBuilder<'msg, IFabHamburgerMenu>, value: IBrush) =
        this.AddScalar(HamburgerMenu.ContentBackground.WithValue(value))

    [<Extension>]
    static member inline expandedModeThresholdWidth(this: WidgetBuilder<'msg, IFabHamburgerMenu>, value: int) =
        this.AddScalar(HamburgerMenu.ExpandedModeThresholdWidth.WithValue(value))

[<AutoOpen>]
module EmptyBorderBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a empty Border widget.</summary>
        static member EmptyBorder<'msg>() =
            WidgetBuilder<'msg, IFabBorder>(Border.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))
