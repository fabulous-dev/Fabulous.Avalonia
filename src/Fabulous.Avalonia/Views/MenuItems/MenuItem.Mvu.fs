namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls

open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

module MvuMenuItem =
    let Clicked =
        Attributes.defineEvent "MenuItem_Clicked" (fun target -> (target :?> MenuItem).Click)

    let PointerEnteredItem =
        Attributes.defineEvent "MenuItem_PointerEnteredItem" (fun target -> (target :?> MenuItem).PointerEnteredItem)

    let PointerExitedItem =
        Attributes.defineEvent "MenuItem_PointerExitedItem" (fun target -> (target :?> MenuItem).PointerExitedItem)

    let SubmenuOpened =
        Attributes.defineEvent "MenuItem_SubmenuOpened" (fun target -> (target :?> MenuItem).SubmenuOpened)

[<AutoOpen>]
module MvuMenuItemBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a MenuItem widget.</summary>
        /// <param name="header">The header of the menu item.</param>
        static member MenuItem(header: string) =
            WidgetBuilder<'msg, IFabMenuItem>(MenuItem.WidgetKey, HeaderedContentControl.HeaderString.WithValue(header))

        /// <summary>Creates a MenuItem widget.</summary>
        /// <param name="header">The header of the menu item.</param>
        /// <param name="onClick">Raised when the menu item is clicked.</param>
        static member MenuItem(header: string, onClick: RoutedEventArgs -> 'msg) =
            WidgetBuilder<'msg, IFabMenuItem>(MenuItem.WidgetKey, HeaderedContentControl.HeaderString.WithValue(header), MvuMenuItem.Clicked.WithValue(onClick))

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
        static member MenuItem(header: WidgetBuilder<'msg, #IFabControl>, onClick: RoutedEventArgs -> 'msg) =
            WidgetBuilder<'msg, IFabMenuItem>(
                MenuItem.WidgetKey,
                AttributesBundle(
                    StackList.one(MvuMenuItem.Clicked.WithValue(onClick)),
                    ValueSome [| HeaderedContentControl.HeaderWidget.WithValue(header.Compile()) |],
                    ValueNone
                )
            )

[<AutoOpen>]
module MvuMenuItemsBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a MenuItems widget.</summary>
        static member MenuItems() =
            CollectionBuilder<'msg, IFabMenuItem, IFabMenuItem>(MenuItem.WidgetKey, MvuItemsControl.Items)

        /// <summary>Creates a MenuItems widget.</summary>
        static member MenuItems(header: WidgetBuilder<'msg, #IFabControl>) =
            CollectionBuilder<'msg, IFabMenuItem, IFabMenuItem>(
                MenuItem.WidgetKey,
                MvuItemsControl.Items,
                AttributesBundle(StackList.empty(), ValueSome [| HeaderedContentControl.HeaderWidget.WithValue(header.Compile()) |], ValueNone)
            )

        /// <summary>Creates a MenuItems widget.</summary>
        /// <param name="header">The header of the menu item.</param>
        /// <param name="onClick">Raised when the menu item is clicked.</param>
        static member MenuItems(header: WidgetBuilder<'msg, #IFabControl>, onClick: RoutedEventArgs -> 'msg) =
            CollectionBuilder<'msg, IFabMenuItem, IFabMenuItem>(
                MenuItem.WidgetKey,
                MvuItemsControl.Items,
                AttributesBundle(
                    StackList.one(MvuMenuItem.Clicked.WithValue(onClick)),
                    ValueSome [| HeaderedContentControl.HeaderWidget.WithValue(header.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a MenuItems widget.</summary>
        /// <param name="header">The header of the menu item.</param>
        static member MenuItems(header: string) =
            CollectionBuilder<'msg, IFabMenuItem, IFabMenuItem>(
                MenuItem.WidgetKey,
                MvuItemsControl.Items,
                AttributesBundle(StackList.one(HeaderedContentControl.HeaderString.WithValue(header)), ValueNone, ValueNone)
            )

        /// <summary>Creates a MenuItems widget.</summary>
        /// <param name="header">The header of the menu item.</param>
        /// <param name="onClick">Raised when the menu item is clicked.</param>
        static member MenuItems(header: string, onClick: RoutedEventArgs -> 'msg) =
            CollectionBuilder<'msg, IFabMenuItem, IFabMenuItem>(
                MenuItem.WidgetKey,
                MvuItemsControl.Items,
                AttributesBundle(
                    StackList.two(MvuMenuItem.Clicked.WithValue(onClick), HeaderedContentControl.HeaderString.WithValue(header)),
                    ValueNone,
                    ValueNone
                )
            )

        /// <summary>Creates a MenuItems widget.</summary>
        /// <param name="onClick">Raised when the menu item is clicked.</param>
        static member inline MenuItems(onClick: RoutedEventArgs -> 'msg) =
            CollectionBuilder<'msg, IFabMenuItem, IFabMenuItem>(MenuItem.WidgetKey, MvuItemsControl.Items, MvuMenuItem.Clicked.WithValue(onClick))

type MvuMenuItemModifiers =
    /// <summary>Listens to the MenuItem PointerEnteredItem event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PointerEnteredItem event is fired.</param>
    [<Extension>]
    static member inline onPointerEnteredItem(this: WidgetBuilder<'msg, #IFabMenuItem>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(MvuMenuItem.PointerEnteredItem.WithValue(fn))

    /// <summary>Listens to the MenuItem PointerExitedItem event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PointerExitedItem event is fired.</param>
    [<Extension>]
    static member inline onPointerExitedItem(this: WidgetBuilder<'msg, #IFabMenuItem>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(MvuMenuItem.PointerExitedItem.WithValue(fn))

    /// <summary>Listens to the MenuItem SubmenuClosed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the SubmenuClosed event is fired.</param>
    [<Extension>]
    static member inline onSubmenuOpened(this: WidgetBuilder<'msg, #IFabMenuItem>, fn: RoutedEventArgs -> 'msg) =
        this.AddScalar(MvuMenuItem.SubmenuOpened.WithValue(fn))
