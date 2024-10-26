namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type IFabMvuTransformGroup =
    inherit IFabMvuTransform
    inherit IFabTransformGroup

module MvuTransformGroup =

    let Children =
        MvuAttributes.defineAvaloniaListWidgetCollection "TransformGroup_Children" (fun target -> (target :?> TransformGroup).Children)

[<AutoOpen>]
module MvuTransformGroupBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a TransformGroup widget.</summary>
        static member TransformGroup() =
            CollectionBuilder<unit, IFabMvuTransformGroup, IFabMvuTransform>(TransformGroup.WidgetKey, MvuTransformGroup.Children)

type MvuTransformGroupCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabTransform>
        (_: CollectionBuilder<'msg, 'marker, IFabTransform>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabTransform>
        (_: CollectionBuilder<'msg, 'marker, IFabTransform>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

type TransformGroupModifiers =
    /// <summary>Link a ViewRef to access the direct TransformGroup control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTransformGroup>, value: ViewRef<TransformGroup>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
