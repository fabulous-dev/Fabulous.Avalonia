namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabTransformGroup =
    inherit IFabTransform

module TransformGroup =

    let WidgetKey = Widgets.register<TransformGroup>()

    let Children =
        Attributes.defineAvaloniaListWidgetCollection "TransformGroup_Children" (fun target -> (target :?> TransformGroup).Children)

[<AutoOpen>]
module TransformGroupBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a TransformGroup widget.</summary>
        static member TransformGroup() =
            CollectionBuilder<'msg, IFabTransformGroup, IFabTransform>(TransformGroup.WidgetKey, TransformGroup.Children)

type TransformGroupCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabTransform>
        (
            _: CollectionBuilder<'msg, 'marker, IFabTransform>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabTransform>
        (
            _: CollectionBuilder<'msg, 'marker, IFabTransform>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
