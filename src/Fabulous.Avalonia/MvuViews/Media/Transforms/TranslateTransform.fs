namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuTranslateTransform =
    inherit IFabMvuTransform
    inherit IFabTranslateTransform

[<AutoOpen>]
module MvuTranslateTransformBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a TranslateTransform widget.</summary>
        /// <param name="x">The X offset.</param>
        /// <param name="y">The Y offset.</param>
        static member TranslateTransform(x: float, y: float) =
            WidgetBuilder<'msg, IFabMvuTranslateTransform>(TranslateTransform.WidgetKey, TranslateTransform.X.WithValue(x), TranslateTransform.Y.WithValue(y))

        /// <summary>Creates a TranslateTransform widget.</summary>
        /// <param name="x">The X offset.</param>
        static member TranslateTransform(x: float) =
            WidgetBuilder<'msg, IFabMvuTranslateTransform>(TranslateTransform.WidgetKey, TranslateTransform.X.WithValue(x))

        /// <summary>Creates a TranslateTransform widget.</summary>
        static member TranslateTransform() =
            WidgetBuilder<'msg, IFabMvuTranslateTransform>(TranslateTransform.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

type MvuTranslateTransformModifiers =
    /// <summary>Link a ViewRef to access the direct TranslateTransform control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMvuTranslateTransform>, value: ViewRef<TranslateTransform>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
