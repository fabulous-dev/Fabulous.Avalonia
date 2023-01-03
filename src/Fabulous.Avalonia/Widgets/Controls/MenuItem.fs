namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls

open Avalonia.Input
open Fabulous
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabMenuItem =
    inherit IFabHeaderedSelectingItemsControl

module MenuItem =
    let WidgetKey = Widgets.register<MenuItem> ()

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

    let SubmenuOpened =
        Attributes.defineEvent "MenuItem_SubmenuOpened" (fun target -> (target :?> MenuItem).SubmenuOpened)

[<AutoOpen>]
module MenuItemBuilders =
    type Fabulous.Avalonia.View with

        static member inline MenuItem(header: string) =
            WidgetBuilder<'msg, IFabMenuItem>(MenuItem.WidgetKey, HeaderedContentControl.HeaderString.WithValue(header))

        static member inline MenuItem(header: string, onClick: 'msg) =
            WidgetBuilder<'msg, IFabMenuItem>(
                MenuItem.WidgetKey,
                HeaderedContentControl.HeaderString.WithValue(header),
                MenuItem.Clicked.WithValue(fun _ -> box onClick)
            )

        static member MenuItem(header: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabMenuItem>(
                MenuItem.WidgetKey,
                AttributesBundle(
                    StackList.empty (),
                    ValueSome [| HeaderedContentControl.HeaderWidget.WithValue(header.Compile()) |],
                    ValueNone
                )
            )

        static member MenuItem(header: WidgetBuilder<'msg, #IFabControl>, onClick: 'msg) =
            WidgetBuilder<'msg, IFabMenuItem>(
                MenuItem.WidgetKey,
                AttributesBundle(
                    StackList.one (MenuItem.Clicked.WithValue(fun _ -> box onClick)),
                    ValueSome [| HeaderedContentControl.HeaderWidget.WithValue(header.Compile()) |],
                    ValueNone
                )
            )

        static member inline MenuItems(header: string) =
            CollectionBuilder<'msg, IFabMenuItem, IFabMenuItem>(
                MenuItem.WidgetKey,
                ItemsControl.Items,
                HeaderedContentControl.HeaderString.WithValue(header)
            )

        static member inline MenuItems(header: string, onClick: 'msg) =
            CollectionBuilder<'msg, IFabMenuItem, IFabMenuItem>(
                MenuItem.WidgetKey,
                ItemsControl.Items,
                HeaderedContentControl.HeaderString.WithValue(header),
                MenuItem.Clicked.WithValue(fun _ -> box onClick)
            )

        static member inline MenuItems(header: WidgetBuilder<'msg, #IFabMenuItem>) =
            WidgetHelpers.buildWidgets<'msg, #IFabMenuItem>
                MenuItem.WidgetKey
                (StackList.empty ())
                [| HeaderedContentControl.HeaderWidget.WithValue(header.Compile()) |]

        static member inline MenuItems(header: WidgetBuilder<'msg, #IFabMenuItem>, onClick: 'msg) =
            WidgetHelpers.buildWidgets<'msg, #IFabMenuItem>
                MenuItem.WidgetKey
                (StackList.one (MenuItem.Clicked.WithValue(fun _ -> box onClick)))
                [| HeaderedContentControl.HeaderWidget.WithValue(header.Compile()) |]

[<Extension>]
type MenuItemModifiers =
    [<Extension>]
    static member inline hotKey(this: WidgetBuilder<'msg, #IFabMenuItem>, value: KeyGesture) =
        this.AddScalar(MenuItem.HotKey.WithValue(value))

    [<Extension>]
    static member inline icon(this: WidgetBuilder<'msg, #IFabMenuItem>, content: WidgetBuilder<'msg, #IFabControl>) =
        this.AddWidget(MenuItem.Icon.WithValue(content.Compile()))

    [<Extension>]
    static member inline inputGesture(this: WidgetBuilder<'msg, #IFabMenuItem>, value: KeyGesture) =
        this.AddScalar(MenuItem.InputGesture.WithValue(value))

    [<Extension>]
    static member inline isSelected(this: WidgetBuilder<'msg, #IFabMenuItem>, value: bool) =
        this.AddScalar(MenuItem.IsSelected.WithValue(value))

    [<Extension>]
    static member inline isSubMenuOpen(this: WidgetBuilder<'msg, #IFabMenuItem>, value: bool) =
        this.AddScalar(MenuItem.IsSubMenuOpen.WithValue(value))

    [<Extension>]
    static member inline staysOpenOnClick(this: WidgetBuilder<'msg, #IFabMenuItem>, value: bool) =
        this.AddScalar(MenuItem.StaysOpenOnClick.WithValue(value))

    [<Extension>]
    static member inline onPointerEnteredItem
        (
            this: WidgetBuilder<'msg, #IFabMenuItem>,
            onPointerEnteredItem: PointerEventArgs -> 'msg
        ) =
        this.AddScalar(MenuItem.PointerEnteredItem.WithValue(fun args -> onPointerEnteredItem args |> box))

    [<Extension>]
    static member inline onSubmenuOpened(this: WidgetBuilder<'msg, #IFabMenuItem>, onSubmenuOpened: bool -> 'msg) =
        this.AddScalar(
            MenuItem.SubmenuOpened.WithValue(fun args ->
                let control = args.Source :?> MenuItem
                onSubmenuOpened control.IsSubMenuOpen |> box)
        )

[<Extension>]
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
