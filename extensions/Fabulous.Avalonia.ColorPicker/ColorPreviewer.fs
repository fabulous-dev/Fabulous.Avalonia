﻿namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.Avalonia.Mvu
open Fabulous.StackAllocatedCollections.StackList

type IFabColorPreviewer =
    inherit IFabMvuTemplatedControl

module ColorPreviewer =
    let WidgetKey = Widgets.register<ColorPreviewer>()

    let HsvColor =
        Attributes.defineAvaloniaPropertyWithEquality ColorPreviewer.HsvColorProperty

    let IsAccentColorsVisible =
        Attributes.defineAvaloniaPropertyWithEquality ColorPreviewer.IsAccentColorsVisibleProperty

    let ColorChanged =
        Attributes.defineEvent "ColorPreviewer_ColorChanged" (fun target -> (target :?> ColorPreviewer).ColorChanged)

[<AutoOpen>]
module ColorPreviewerBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a ColorPreviewer widget.</summary>
        static member ColorPreviewer() =
            WidgetBuilder<'msg, IFabColorPreviewer>(ColorPreviewer.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

        /// <summary>Creates a ColorPreviewer widget.</summary>
        /// <param name="fn">Raised when the color changes.</param>
        static member ColorPreviewer(fn: ColorChangedEventArgs -> 'msg) =
            WidgetBuilder<'msg, IFabColorPreviewer>(ColorPreviewer.WidgetKey, ColorPreviewer.ColorChanged.WithValue(fn))

type ColorPreviewerModifiers =
    /// <summary>Link a ViewRef to access the direct ColorSlider control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabColorPreviewer>, value: ViewRef<ColorPreviewer>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

    /// <summary>Set the HsvColor property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HsvColor value.</param>
    [<Extension>]
    static member inline hsvColor(this: WidgetBuilder<'msg, IFabColorPreviewer>, value: HsvColor) =
        this.AddScalar(ColorPreviewer.HsvColor.WithValue(value))

    /// <summary>Set the IsAccentColorsVisible property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsAccentColorsVisible value.</param>
    [<Extension>]
    static member inline isAccentColorsVisible(this: WidgetBuilder<'msg, IFabColorPreviewer>, value: bool) =
        this.AddScalar(ColorPreviewer.IsAccentColorsVisible.WithValue(value))
