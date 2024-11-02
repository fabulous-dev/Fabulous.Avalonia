namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module ComponentNativeMenuItem =

    let Click =
        Attributes.defineEventNoArgNoDispatch "NativeMenuItem_Click" (fun target -> (target :?> NativeMenuItem).Click)

[<AutoOpen>]
module NativeMenuItemBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a NativeMenuItem widget.</summary>
        /// <param name="header">The header of the Flyout.</param>
        static member NativeMenuItem(header: string) =
            WidgetBuilder<unit, IFabNativeMenuItem>(NativeMenuItem.WidgetKey, NativeMenuItem.Header.WithValue(header))

        /// <summary>Creates a NativeMenuItem widget.</summary>
        /// <param name="header">The header of the Flyout.</param>
        /// <param name="onClicked">Raised when the menu item is clicked.</param>
        static member NativeMenuItem(header: string, onClicked: unit -> unit) =
            WidgetBuilder<unit, IFabNativeMenuItem>(
                NativeMenuItem.WidgetKey,
                NativeMenuItem.Header.WithValue(header),
                ComponentNativeMenuItem.Click.WithValue(onClicked)
            )
