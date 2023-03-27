namespace Fabulous.Avalonia

open System.Collections.Generic
open System.Runtime.CompilerServices
open Avalonia.Styling
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabStyle =
    inherit IFabElement

module Style =

    let WidgetKey = Widgets.register<Style>()

    let Animations =
        Attributes.defineListWidgetCollection "Style_Animations" (fun target -> (target :?> Style).Animations :> IList<_>)

    let Setters =
        Attributes.definePropertyWithGetSet<ISetter seq> "Style_Setters" (fun target -> (target :?> Style).Setters) (fun target value ->
            let target = (target :?> Style)
            target.Setters.Clear()

            for an in value do
                target.Setters.Add(an))

[<AutoOpen>]
module StyleBuilders =

    type Fabulous.Avalonia.View with

        static member Animations() =
            CollectionBuilder<'msg, IFabStyle, IFabAnimation>(Style.WidgetKey, Style.Animations)

[<Extension>]
type StyleCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabAnimation>
        (
            _: CollectionBuilder<'msg, 'marker, IFabAnimation>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabAnimation>
        (
            _: CollectionBuilder<'msg, 'marker, IFabAnimation>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
