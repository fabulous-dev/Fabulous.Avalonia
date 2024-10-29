namespace Fabulous.Avalonia

open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open Fabulous.Avalonia.Mvu
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuColorView =
    inherit IFabMvuTemplatedControl
    inherit IFabColorView

module MvuColorView =
    let ColorChanged =
        MvuAttributes.defineAvaloniaPropertyWithChangedEvent' "ColorView_ColorChanged" ColorView.ColorProperty

[<AutoOpen>]
module MvuColorViewBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a ColorView widget.</summary>
        static member ColorView() =
            WidgetBuilder<'msg, IFabMvuColorView>(ColorView.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

        /// <summary>Creates a ColorView widget.</summary>
        /// <param name="color">The Color value.</param>
        static member ColorView(color: Color) =
            WidgetBuilder<'msg, IFabMvuColorView>(ColorView.WidgetKey, AttributesBundle(StackList.one(ColorView.Color.WithValue(color)), ValueNone, ValueNone))

        /// <summary>Creates a ColorView widget.</summary>
        /// <param name="color">The Color value.</param>
        /// <param name="fn">Raised when the color changes.</param>
        static member ColorView(color: Color, fn: Color -> 'msg) =
            WidgetBuilder<'msg, IFabMvuColorView>(ColorView.WidgetKey, MvuColorView.ColorChanged.WithValue(MvuValueEventData.create color fn))
