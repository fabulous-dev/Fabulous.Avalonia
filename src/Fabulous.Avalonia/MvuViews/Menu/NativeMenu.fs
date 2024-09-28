namespace Fabulous.Avalonia.Components

open System
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabComponentNativeMenu =
    inherit IFabComponentNativeMenuItemBase
    inherit IFabNativeMenu

module ComponentNativeMenu =
    let WidgetKey = Widgets.register<NativeMenu>()

    let Items =
        ComponentAttributes.defineListWidgetCollection "NativeMenu_Items" (fun target -> (target :?> NativeMenu).Items)

    let Opening =
        ComponentAttributes.defineEvent "NativeMenu_Opening" (fun target -> (target :?> NativeMenu).Opening)

    let Closed =
        ComponentAttributes.defineEvent "NativeMenu_Opening" (fun target -> (target :?> NativeMenu).Closed)

    let NeedsUpdate =
        ComponentAttributes.defineEvent "NativeMenu_NeedsUpdate" (fun target -> (target :?> NativeMenu).NeedsUpdate)

module NativeMenuAttached =
    let NativeMenu = Attributes.defineAvaloniaPropertyWidget NativeMenu.MenuProperty

    let IsNativeMenuExported =
        Attributes.defineAvaloniaPropertyWithEquality Avalonia.Controls.NativeMenu.IsNativeMenuExportedProperty

[<AutoOpen>]
module ComponentNativeMenuBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a NativeMenu widget</summary>
        static member NativeMenu() =
            CollectionBuilder<'msg, IFabComponentNativeMenu, IFabComponentNativeMenuItem>(NativeMenu.WidgetKey, ComponentNativeMenu.Items)

type NativeMenuModifiers =
    /// <summary>Listens to the NativeMenu Opening event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the Opening event fires.</param>
    [<Extension>]
    static member inline onOpening(this: WidgetBuilder<'msg, #IFabNativeMenu>, msg: EventArgs -> unit) =
        this.AddScalar(ComponentNativeMenu.Opening.WithValue(msg))

    /// <summary>Listens to the NativeMenu Closed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the Closed event fires.</param>
    [<Extension>]
    static member inline onClosed(this: WidgetBuilder<'msg, #IFabNativeMenu>, msg: EventArgs -> unit) =
        this.AddScalar(ComponentNativeMenu.Closed.WithValue(msg))

    /// <summary>Listens to the NativeMenu NeedsUpdate event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the NeedsUpdate event fires.</param>
    [<Extension>]
    static member inline onNeedsUpdate(this: WidgetBuilder<'msg, #IFabNativeMenu>, msg: EventArgs -> unit) =
        this.AddScalar(ComponentNativeMenu.NeedsUpdate.WithValue(msg))

    /// <summary>Link a ViewRef to access the direct NativeMenu control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComponentNativeMenu>, value: ViewRef<NativeMenu>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

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

type ComponentWindowMenuAttachedModifiers =
    /// <summary>Sets the NativeMenu property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The NativeMenu value.</param>
    [<Extension>]
    static member inline menu(this: WidgetBuilder<'msg, #IFabWindow>, value: WidgetBuilder<'msg, #IFabNativeMenu>) =
        this.AddWidget(NativeMenuAttached.NativeMenu.WithValue(value.Compile()))

type NativeViewYieldExtensions =
    [<Extension>]
    static member inline Yield(_: CollectionBuilder<'msg, #IFabNativeMenu, IFabNativeMenuItem>, x: WidgetBuilder<'msg, #IFabNativeMenuItem>) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield
        (_: CollectionBuilder<'msg, #IFabNativeMenu, IFabNativeMenuItem>, x: WidgetBuilder<'msg, Memo.Memoized<#IFabNativeMenuItem>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
