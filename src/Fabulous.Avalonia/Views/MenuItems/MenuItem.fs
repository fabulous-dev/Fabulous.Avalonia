namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls

open Avalonia.Input
open Avalonia.Interactivity
open Fabulous
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabMenuItem =
    inherit IFabHeaderedSelectingItemsControl

module MenuItem =
    let WidgetKey = Widgets.register<MenuItem>()

    let HotKey = Attributes.defineAvaloniaPropertyWithEquality MenuItem.HotKeyProperty

    let Icon = Attributes.defineAvaloniaPropertyWidget MenuItem.IconProperty

    let InputGesture =
        Attributes.defineAvaloniaPropertyWithEquality MenuItem.InputGestureProperty

    let IsSelected =
        Attributes.defineAvaloniaPropertyWithEquality MenuItem.IsSelectedProperty

    let IsSubMenuOpen =
        Attributes.defineAvaloniaPropertyWithEquality MenuItem.IsSubMenuOpenProperty

    let StaysOpenOnClick =
        Attributes.defineAvaloniaPropertyWithEquality MenuItem.StaysOpenOnClickProperty

    let Clicked =
        Attributes.defineEvent "MenuItem_Clicked" (fun target -> (target :?> MenuItem).Click)

    let PointerEnteredItem =
        Attributes.defineEvent "MenuItem_PointerEnteredItem" (fun target -> (target :?> MenuItem).PointerEnteredItem)

    let PointerExitedItem =
        Attributes.defineEvent "MenuItem_PointerExitedItem" (fun target -> (target :?> MenuItem).PointerExitedItem)

    let SubmenuOpened =
        Attributes.defineEvent "MenuItem_SubmenuOpened" (fun target -> (target :?> MenuItem).SubmenuOpened)

[<AutoOpen>]
module MenuItemBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a MenuItem widget.</summary>
        /// <param name="header">The header of the menu item.</param>
        static member MenuItem(header: string) =
            WidgetBuilder<'msg, IFabMenuItem>(MenuItem.WidgetKey, HeaderedContentControl.HeaderString.WithValue(header))

        /// <summary>Creates a MenuItem widget.</summary>
        /// <param name="header">The header of the menu item.</param>
        /// <param name="onClick">Raised when the menu item is clicked.</param>
        static member MenuItem(header: string, onClick: 'msg) =
            WidgetBuilder<'msg, IFabMenuItem>(
                MenuItem.WidgetKey,
                HeaderedContentControl.HeaderString.WithValue(header),
                MenuItem.Clicked.WithValue(fun _ -> box onClick)
            )

        /// <summary>Creates a MenuItem widget.</summary>
        /// <param name="header">The header of the menu item.</param>
        static member MenuItem(header: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabMenuItem>(
                MenuItem.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| HeaderedContentControl.HeaderWidget.WithValue(header.Compile()) |], ValueNone)
            )

        /// <summary>Creates a MenuItem widget.</summary>
        /// <param name="header">The header of the menu item.</param>
        /// <param name="onClick">Raised when the menu item is clicked.</param>
        static member MenuItem(header: WidgetBuilder<'msg, #IFabControl>, onClick: 'msg) =
            WidgetBuilder<'msg, IFabMenuItem>(
                MenuItem.WidgetKey,
                AttributesBundle(
                    StackList.one(MenuItem.Clicked.WithValue(fun _ -> box onClick)),
                    ValueSome [| HeaderedContentControl.HeaderWidget.WithValue(header.Compile()) |],
                    ValueNone
                )
            )

[<AutoOpen>]
module MenuItemsBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a MenuItems widget.</summary>
        static member MenuItems() =
            CollectionBuilder<'msg, IFabMenuItem, IFabMenuItem>(MenuItem.WidgetKey, ItemsControl.Items)

        /// <summary>Creates a MenuItems widget.</summary>
        static member MenuItems(header: WidgetBuilder<'msg, #IFabControl>) =
            CollectionBuilder<'msg, IFabMenuItem, IFabMenuItem>(
                MenuItem.WidgetKey,
                ItemsControl.Items,
                AttributesBundle(StackList.empty(), ValueSome [| HeaderedContentControl.HeaderWidget.WithValue(header.Compile()) |], ValueNone)
            )

        static member MenuItems(header: WidgetBuilder<'msg, #IFabControl>, onClick: 'msg) =
            CollectionBuilder<'msg, IFabMenuItem, IFabMenuItem>(
                MenuItem.WidgetKey,
                ItemsControl.Items,
                AttributesBundle(
                    StackList.one(MenuItem.Clicked.WithValue(fun _ -> box onClick)),
                    ValueSome [| HeaderedContentControl.HeaderWidget.WithValue(header.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a MenuItems widget.</summary>
        static member MenuItems(header: string) =
            CollectionBuilder<'msg, IFabMenuItem, IFabMenuItem>(
                MenuItem.WidgetKey,
                ItemsControl.Items,
                AttributesBundle(StackList.one(HeaderedContentControl.HeaderString.WithValue(header)), ValueNone, ValueNone)
            )

        static member MenuItems(header: string, onClick: 'msg) =
            CollectionBuilder<'msg, IFabMenuItem, IFabMenuItem>(
                MenuItem.WidgetKey,
                ItemsControl.Items,
                AttributesBundle(
                    StackList.two(MenuItem.Clicked.WithValue(fun _ -> box onClick), HeaderedContentControl.HeaderString.WithValue(header)),
                    ValueNone,
                    ValueNone
                )
            )

        /// <summary>Creates a MenuItems widget.</summary>
        /// <param name="onClick">Raised when the menu item is clicked.</param>
        static member inline MenuItems(onClick: 'msg) =
            CollectionBuilder<'msg, IFabMenuItem, IFabMenuItem>(MenuItem.WidgetKey, ItemsControl.Items, MenuItem.Clicked.WithValue(fun _ -> box onClick))

type MenuItemModifiers =
    /// <summary>Sets the HotKey property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HotKey value.</param>
    [<Extension>]
    static member inline hotKey(this: WidgetBuilder<'msg, #IFabMenuItem>, value: KeyGesture) =
        this.AddScalar(MenuItem.HotKey.WithValue(value))

    /// <summary>Sets the Icon property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Icon value.</param>
    [<Extension>]
    static member inline icon(this: WidgetBuilder<'msg, #IFabMenuItem>, value: WidgetBuilder<'msg, #IFabControl>) =
        this.AddWidget(MenuItem.Icon.WithValue(value.Compile()))

    /// <summary>Sets the InputGesture property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The InputGesture value.</param>
    [<Extension>]
    static member inline inputGesture(this: WidgetBuilder<'msg, #IFabMenuItem>, value: KeyGesture) =
        this.AddScalar(MenuItem.InputGesture.WithValue(value))

    /// <summary>Sets the IsSelected property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsSelected value.</param>
    [<Extension>]
    static member inline isSelected(this: WidgetBuilder<'msg, #IFabMenuItem>, value: bool) =
        this.AddScalar(MenuItem.IsSelected.WithValue(value))

    /// <summary>Sets the IsSubmenuOpen property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsSubmenuOpen value.</param>
    [<Extension>]
    static member inline isSubMenuOpen(this: WidgetBuilder<'msg, #IFabMenuItem>, value: bool) =
        this.AddScalar(MenuItem.IsSubMenuOpen.WithValue(value))

    /// <summary>Sets the StaysOpenOnClick property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The StaysOpenOnClick value.</param>
    [<Extension>]
    static member inline staysOpenOnClick(this: WidgetBuilder<'msg, #IFabMenuItem>, value: bool) =
        this.AddScalar(MenuItem.StaysOpenOnClick.WithValue(value))

    /// <summary>Listens to the MenuItem PointerEnteredItem event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PointerEnteredItem event is fired.</param>
    [<Extension>]
    static member inline onPointerEnteredItem(this: WidgetBuilder<'msg, #IFabMenuItem>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(MenuItem.PointerEnteredItem.WithValue(fn))

    /// <summary>Listens to the MenuItem PointerExitedItem event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PointerExitedItem event is fired.</param>
    [<Extension>]
    static member inline onPointerExitedItem(this: WidgetBuilder<'msg, #IFabMenuItem>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(MenuItem.PointerExitedItem.WithValue(fn))

    /// <summary>Listens to the MenuItem SubmenuClosed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the SubmenuClosed event is fired.</param>
    [<Extension>]
    static member inline onSubmenuOpened(this: WidgetBuilder<'msg, #IFabMenuItem>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(MenuItem.SubmenuOpened.WithValue(fn))

    /// <summary>Link a ViewRef to access the direct MenuItem control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMenuItem>, value: ViewRef<MenuItem>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type MenuItemCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabMenuItem>
        (
            _: CollectionBuilder<'msg, 'marker, IFabMenuItem>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabMenuItem>
        (
            _: CollectionBuilder<'msg, 'marker, IFabMenuItem>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
