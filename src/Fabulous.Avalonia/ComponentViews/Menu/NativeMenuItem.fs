namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

type IFabComponentNativeMenuItem =
    inherit IFabComponentElement
    inherit IFabNativeMenuItem

module ComponentNativeMenuItem =

    let Click =
        Attributes.defineEventNoArgNoDispatch "NativeMenuItem_Click" (fun target -> (target :?> NativeMenuItem).Click)

[<AutoOpen>]
module NativeMenuItemBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a NativeMenuItem widget.</summary>
        /// <param name="header">The header of the Flyout.</param>
        static member NativeMenuItem(header: string) =
            WidgetBuilder<unit, IFabComponentNativeMenuItem>(NativeMenuItem.WidgetKey, NativeMenuItem.Header.WithValue(header))

        /// <summary>Creates a NativeMenuItem widget.</summary>
        /// <param name="header">The header of the Flyout.</param>
        /// <param name="onClicked">Raised when the menu item is clicked.</param>
        static member NativeMenuItem(header: string, onClicked: unit -> unit) =
            WidgetBuilder<unit, IFabComponentNativeMenuItem>(
                NativeMenuItem.WidgetKey,
                NativeMenuItem.Header.WithValue(header),
                ComponentNativeMenuItem.Click.WithValue(onClicked)
            )

type ComponentNativeMenuItemModifiers =
    /// <summary>Link a ViewRef to access the direct NativeMenuItem control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabNativeMenuItem>, value: ViewRef<NativeMenuItem>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
