namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls

open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

module ComponentMenuItem =
    let Clicked =
        Attributes.defineEventNoDispatch "MenuItem_Clicked" (fun target -> (target :?> MenuItem).Click)

    let PointerEnteredItem =
        Attributes.defineEventNoDispatch "MenuItem_PointerEnteredItem" (fun target -> (target :?> MenuItem).PointerEnteredItem)

    let PointerExitedItem =
        Attributes.defineEventNoDispatch "MenuItem_PointerExitedItem" (fun target -> (target :?> MenuItem).PointerExitedItem)

    let SubmenuOpened =
        Attributes.defineEventNoDispatch "MenuItem_SubmenuOpened" (fun target -> (target :?> MenuItem).SubmenuOpened)

[<AutoOpen>]
module ComponentMenuItemBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a MenuItem widget.</summary>
        /// <param name="header">The header of the menu item.</param>
        static member MenuItem(header: string) =
            WidgetBuilder<'msg, IFabMenuItem>(MenuItem.WidgetKey, HeaderedContentControl.HeaderString.WithValue(header))

        /// <summary>Creates a MenuItem widget.</summary>
        /// <param name="header">The header of the menu item.</param>
        /// <param name="onClick">Raised when the menu item is clicked.</param>
        static member MenuItem(header: string, onClick: RoutedEventArgs -> unit) =
            WidgetBuilder<'msg, IFabMenuItem>(
                MenuItem.WidgetKey,
                HeaderedContentControl.HeaderString.WithValue(header),
                ComponentMenuItem.Clicked.WithValue(onClick)
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
        static member MenuItem(header: WidgetBuilder<'msg, #IFabControl>, onClick: RoutedEventArgs -> unit) =
            WidgetBuilder<'msg, IFabMenuItem>(
                MenuItem.WidgetKey,
                AttributesBundle(
                    StackList.one(ComponentMenuItem.Clicked.WithValue(onClick)),
                    ValueSome [| HeaderedContentControl.HeaderWidget.WithValue(header.Compile()) |],
                    ValueNone
                )
            )

[<AutoOpen>]
module ComponentMenuItemsBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a MenuItems widget.</summary>
        static member MenuItems() =
            CollectionBuilder<'msg, IFabMenuItem, IFabMenuItem>(MenuItem.WidgetKey, ComponentItemsControl.Items)

        /// <summary>Creates a MenuItems widget.</summary>
        static member MenuItems(header: WidgetBuilder<'msg, #IFabControl>) =
            CollectionBuilder<'msg, IFabMenuItem, IFabMenuItem>(
                MenuItem.WidgetKey,
                ComponentItemsControl.Items,
                AttributesBundle(StackList.empty(), ValueSome [| HeaderedContentControl.HeaderWidget.WithValue(header.Compile()) |], ValueNone)
            )

        /// <summary>Creates a MenuItems widget.</summary>
        /// <param name="header">The header of the menu item.</param>
        /// <param name="onClick">Raised when the menu item is clicked.</param>
        static member MenuItems(header: WidgetBuilder<'msg, #IFabControl>, onClick: RoutedEventArgs -> unit) =
            CollectionBuilder<'msg, IFabMenuItem, IFabMenuItem>(
                MenuItem.WidgetKey,
                ComponentItemsControl.Items,
                AttributesBundle(
                    StackList.one(ComponentMenuItem.Clicked.WithValue(onClick)),
                    ValueSome [| HeaderedContentControl.HeaderWidget.WithValue(header.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a MenuItems widget.</summary>
        /// <param name="header">The header of the menu item.</param>
        static member MenuItems(header: string) =
            CollectionBuilder<'msg, IFabMenuItem, IFabMenuItem>(
                MenuItem.WidgetKey,
                ComponentItemsControl.Items,
                AttributesBundle(StackList.one(HeaderedContentControl.HeaderString.WithValue(header)), ValueNone, ValueNone)
            )

        /// <summary>Creates a MenuItems widget.</summary>
        /// <param name="header">The header of the menu item.</param>
        /// <param name="onClick">Raised when the menu item is clicked.</param>
        static member MenuItems(header: string, onClick: RoutedEventArgs -> unit) =
            CollectionBuilder<unit, IFabMenuItem, IFabMenuItem>(
                MenuItem.WidgetKey,
                ComponentItemsControl.Items,
                AttributesBundle(
                    StackList.two(ComponentMenuItem.Clicked.WithValue(onClick), HeaderedContentControl.HeaderString.WithValue(header)),
                    ValueNone,
                    ValueNone
                )
            )

        /// <summary>Creates a MenuItems widget.</summary>
        /// <param name="onClick">Raised when the menu item is clicked.</param>
        static member inline MenuItems(onClick: RoutedEventArgs -> unit) =
            CollectionBuilder<unit, IFabMenuItem, IFabMenuItem>(MenuItem.WidgetKey, ComponentItemsControl.Items, ComponentMenuItem.Clicked.WithValue(onClick))

type ComponentMenuItemModifiers =
    /// <summary>Listens to the MenuItem PointerEnteredItem event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PointerEnteredItem event is fired.</param>
    [<Extension>]
    static member inline onPointerEnteredItem(this: WidgetBuilder<'msg, #IFabMenuItem>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentMenuItem.PointerEnteredItem.WithValue(fn))

    /// <summary>Listens to the MenuItem PointerExitedItem event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PointerExitedItem event is fired.</param>
    [<Extension>]
    static member inline onPointerExitedItem(this: WidgetBuilder<'msg, #IFabMenuItem>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentMenuItem.PointerExitedItem.WithValue(fn))

    /// <summary>Listens to the MenuItem SubmenuClosed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the SubmenuClosed event is fired.</param>
    [<Extension>]
    static member inline onSubmenuOpened(this: WidgetBuilder<'msg, #IFabMenuItem>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentMenuItem.SubmenuOpened.WithValue(fn))
