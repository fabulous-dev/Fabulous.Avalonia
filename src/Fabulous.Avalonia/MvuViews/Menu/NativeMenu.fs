namespace Fabulous.Avalonia.Mvu

open System
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabMvuNativeMenu =
    inherit IFabMvuNativeMenuItemBase
    inherit IFabNativeMenu

module MvuNativeMenu =
    let WidgetKey = Widgets.register<NativeMenu>()

    let Items =
        Attributes.defineListWidgetCollection "NativeMenu_Items" (fun target -> (target :?> NativeMenu).Items)

    let Opening =
        Attributes.defineEvent "NativeMenu_Opening" (fun target -> (target :?> NativeMenu).Opening)

    let Closed =
        Attributes.defineEvent "NativeMenu_Opening" (fun target -> (target :?> NativeMenu).Closed)

    let NeedsUpdate =
        Attributes.defineEvent "NativeMenu_NeedsUpdate" (fun target -> (target :?> NativeMenu).NeedsUpdate)

module NativeMenuAttached =
    let NativeMenu = Attributes.defineAvaloniaPropertyWidget NativeMenu.MenuProperty

    let IsNativeMenuExported =
        Attributes.defineAvaloniaPropertyWithEquality Avalonia.Controls.NativeMenu.IsNativeMenuExportedProperty

[<AutoOpen>]
module MvuNativeMenuBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a NativeMenu widget</summary>
        static member NativeMenu() =
            CollectionBuilder<'msg, IFabMvuNativeMenu, IFabMvuNativeMenuItem>(NativeMenu.WidgetKey, MvuNativeMenu.Items)

type NativeMenuModifiers =
    /// <summary>Listens to the NativeMenu Opening event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the Opening event fires.</param>
    [<Extension>]
    static member inline onOpening(this: WidgetBuilder<'msg, #IFabNativeMenu>, msg: EventArgs -> 'msg) =
        this.AddScalar(MvuNativeMenu.Opening.WithValue(msg))

    /// <summary>Listens to the NativeMenu Closed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the Closed event fires.</param>
    [<Extension>]
    static member inline onClosed(this: WidgetBuilder<'msg, #IFabNativeMenu>, msg: EventArgs -> 'msg) =
        this.AddScalar(MvuNativeMenu.Closed.WithValue(msg))

    /// <summary>Listens to the NativeMenu NeedsUpdate event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the NeedsUpdate event fires.</param>
    [<Extension>]
    static member inline onNeedsUpdate(this: WidgetBuilder<'msg, #IFabNativeMenu>, msg: EventArgs -> 'msg) =
        this.AddScalar(MvuNativeMenu.NeedsUpdate.WithValue(msg))

type NativeMenuAttachedModifiers =
    /// <summary>Sets the IsNativeMenuExported property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsNativeMenuExported value.</param>
    [<Extension>]
    static member inline isNativeMenuExported(this: WidgetBuilder<'msg, #IFabTopLevel>, value: bool) =
        this.AddScalar(NativeMenuAttached.IsNativeMenuExported.WithValue(value))

    /// <summary>Sets the Menu property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Menu value.</param>
    [<Extension>]
    static member inline menu(this: WidgetBuilder<'msg, #IFabNativeMenuItem>, value: WidgetBuilder<'msg, #IFabNativeMenu>) =
        this.AddWidget(NativeMenuItem.Menu.WithValue(value.Compile()))

type MvuWindowMenuAttachedModifiers =
    /// <summary>Sets the NativeMenu property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The NativeMenu value.</param>
    [<Extension>]
    static member inline menu(this: WidgetBuilder<'msg, #IFabWindow>, value: WidgetBuilder<'msg, #IFabNativeMenu>) =
        this.AddWidget(NativeMenuAttached.NativeMenu.WithValue(value.Compile()))

type MvuNativeViewYieldExtensions =
    [<Extension>]
    static member inline Yield(_: CollectionBuilder<'msg, #IFabMvuNativeMenu, IFabMvuNativeMenuItem>, x: WidgetBuilder<'msg, #IFabMvuNativeMenuItem>) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield
        (_: CollectionBuilder<'msg, #IFabMvuNativeMenu, IFabMvuNativeMenuItem>, x: WidgetBuilder<'msg, Memo.Memoized<#IFabMvuNativeMenuItem>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
