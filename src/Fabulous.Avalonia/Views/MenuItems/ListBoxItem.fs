namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls

open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabListBoxItem =
    inherit IFabContentControl

module ListBoxItem =
    let WidgetKey = Widgets.register<ListBoxItem>()

    let IsSelected =
        Attributes.defineAvaloniaPropertyWithEquality ListBoxItem.IsSelectedProperty

type ListBoxItemModifiers =
    /// <summary>Link a ViewRef to access the direct MenuItem control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabListBoxItem>, value: ViewRef<ListBoxItem>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
