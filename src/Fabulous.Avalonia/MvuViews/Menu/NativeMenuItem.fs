namespace Fabulous.Avalonia.Mvu

open System
open System.IO
open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Input
open Avalonia.Media.Imaging
open Fabulous
open Fabulous.Avalonia

type IFabMvuNativeMenuItem =
    inherit IFabMvuElement
    inherit IFabNativeMenuItem

module MvuNativeMenuItem =

    let Click =
        MvuAttributes.defineEventNoArg "NativeMenuItem_Click" (fun target -> (target :?> NativeMenuItem).Click)

[<AutoOpen>]
module MvuNativeMenuItemBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a NativeMenuItem widget.</summary>
        /// <param name="header">The header of the Flyout.</param>
        static member NativeMenuItem(header: string) =
            WidgetBuilder<unit, IFabMvuNativeMenuItem>(NativeMenuItem.WidgetKey, NativeMenuItem.Header.WithValue(header))

        /// <summary>Creates a NativeMenuItem widget.</summary>
        /// <param name="header">The header of the Flyout.</param>
        /// <param name="onClicked">Raised when the menu item is clicked.</param>
        static member NativeMenuItem(header: string, onClicked: 'msg) =
            WidgetBuilder<unit, IFabMvuNativeMenuItem>(
                NativeMenuItem.WidgetKey,
                NativeMenuItem.Header.WithValue(header),
                MvuNativeMenuItem.Click.WithValue(MsgValue onClicked)
            )

type MvuNativeMenuItemModifiers =
    /// <summary>Link a ViewRef to access the direct NativeMenuItem control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabNativeMenuItem>, value: ViewRef<NativeMenuItem>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
