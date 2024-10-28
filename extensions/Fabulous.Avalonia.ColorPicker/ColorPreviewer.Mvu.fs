namespace Fabulous.Avalonia

open Avalonia.Controls
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia
open Fabulous.Avalonia.Mvu
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuColorPreviewer =
    inherit IFabMvuTemplatedControl
    inherit IFabColorPreviewer

module MvuColorPreviewer =
    let ColorChanged =
        Attributes.defineEvent "ColorPreviewer_ColorChanged" (fun target -> (target :?> ColorPreviewer).ColorChanged)

[<AutoOpen>]
module MvuColorPreviewerBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a ColorPreviewer widget.</summary>
        static member ColorPreviewer() =
            WidgetBuilder<'msg, IFabMvuColorPreviewer>(ColorPreviewer.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

        /// <summary>Creates a ColorPreviewer widget.</summary>
        /// <param name="fn">Raised when the color changes.</param>
        static member ColorPreviewer(fn: ColorChangedEventArgs -> 'msg) =
            WidgetBuilder<'msg, IFabMvuColorPreviewer>(ColorPreviewer.WidgetKey, MvuColorPreviewer.ColorChanged.WithValue(fn))
