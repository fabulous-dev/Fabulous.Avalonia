namespace Fabulous.Avalonia

open System.Collections.Generic
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabItemsControl =
    inherit IFabTemplatedControl

module ItemsControl =
    let Items =
        Attributes.defineListWidgetCollection "ItemsControl_Items" (fun target -> (target :?> ItemsControl).Items :?> IList<_>)

    let ItemCount =
        Attributes.defineAvaloniaPropertyWithEquality ItemsControl.ItemCountProperty

    let AreHorizontalSnapPointsRegular =
        Attributes.defineAvaloniaPropertyWithEquality ItemsControl.AreHorizontalSnapPointsRegularProperty

    let AreVerticalSnapPointsRegular =
        Attributes.defineAvaloniaPropertyWithEquality ItemsControl.AreVerticalSnapPointsRegularProperty

    let HorizontalSnapPointsChanged =
        Attributes.defineEvent "ItemsControl_HorizontalSnapPointsChanged" (fun target -> (target :?> ItemsControl).HorizontalSnapPointsChanged)

    let VerticalSnapPointsChanged =
        Attributes.defineEvent "ItemsControl_VerticalSnapPointsChanged" (fun target -> (target :?> ItemsControl).VerticalSnapPointsChanged)

[<Extension>]
type ItemsControlModifiers =
    [<Extension>]
    static member inline itemsCount(this: WidgetBuilder<'msg, #IFabItemsControl>, value: int) =
        this.AddScalar(ItemsControl.ItemCount.WithValue(value))

    [<Extension>]
    static member inline areHorizontalSnapPointsRegular(this: WidgetBuilder<'msg, #IFabItemsControl>, value: bool) =
        this.AddScalar(ItemsControl.AreHorizontalSnapPointsRegular.WithValue(value))

    [<Extension>]
    static member inline areVerticalSnapPointsRegular(this: WidgetBuilder<'msg, #IFabItemsControl>, value: bool) =
        this.AddScalar(ItemsControl.AreVerticalSnapPointsRegular.WithValue(value))

    [<Extension>]
    static member inline onHorizontalSnapPointsChanged(this: WidgetBuilder<'msg, #IFabItemsControl>, onHorizontalSnapPointsChanged: 'msg) =
        this.AddScalar(ItemsControl.HorizontalSnapPointsChanged.WithValue(fun _ -> onHorizontalSnapPointsChanged |> box))

    [<Extension>]
    static member inline onVerticalSnapPointsChanged(this: WidgetBuilder<'msg, #IFabItemsControl>, onVerticalSnapPointsChanged: 'msg) =
        this.AddScalar(ItemsControl.VerticalSnapPointsChanged.WithValue(fun _ -> onVerticalSnapPointsChanged |> box))
