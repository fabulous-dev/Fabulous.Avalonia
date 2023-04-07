namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabNativeMenuBar =
    inherit IFabTemplatedControl

module NativeMenuBar =

    let WidgetKey = Widgets.register<NativeMenuBar>()

    let EnableMenuItemClickForwarding =
        Attributes.defineAvaloniaPropertyWithEquality NativeMenuBar.EnableMenuItemClickForwardingProperty

[<AutoOpen>]
module NativeMenuBarBuilders =
    type Fabulous.Avalonia.View with

        static member inline NativeMenuBar() =
            WidgetBuilder<'msg, IFabNativeMenuBar>(NativeMenuBar.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

[<Extension>]
type NativeMenuBarAttachedModifiers =

    [<Extension>]
    static member inline enableMenuItemClickForwarding(this: WidgetBuilder<'msg, #IFabMenuItem>, value: bool) =
        this.AddScalar(NativeMenuBar.EnableMenuItemClickForwarding.WithValue(value))
