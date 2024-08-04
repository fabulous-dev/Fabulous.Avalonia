namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentTranslateTransform =
    inherit IFabComponentTransform
    inherit IFabTranslateTransform

[<AutoOpen>]
module ComponentTranslateTransformBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a TranslateTransform widget.</summary>
        /// <param name="x">The X offset.</param>
        /// <param name="y">The Y offset.</param>
        static member TranslateTransform(x: float, y: float) =
            WidgetBuilder<'msg, IFabComponentTranslateTransform>(TranslateTransform.WidgetKey, TranslateTransform.X.WithValue(x), TranslateTransform.Y.WithValue(y))

        /// <summary>Creates a TranslateTransform widget.</summary>
        /// <param name="x">The X offset.</param>
        static member TranslateTransform(x: float) =
            WidgetBuilder<'msg, IFabComponentTranslateTransform>(TranslateTransform.WidgetKey, TranslateTransform.X.WithValue(x))

        /// <summary>Creates a TranslateTransform widget.</summary>
        static member TranslateTransform() =
            WidgetBuilder<'msg, IFabComponentTranslateTransform>(TranslateTransform.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

type ComponentTranslateTransformModifiers =
    /// <summary>Link a ViewRef to access the direct TranslateTransform control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabComponentTranslateTransform>, value: ViewRef<TranslateTransform>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
