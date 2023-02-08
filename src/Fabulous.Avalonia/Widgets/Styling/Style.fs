namespace Fabulous.Avalonia

open System.Collections.Generic
open System.Runtime.CompilerServices
open Avalonia.Styling
open Fabulous
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabStyle =
    inherit IFabElement

module Style =

    let WidgetKey = Widgets.register<Style>()

    let Style =
        Attributes.definePropertyWithGetSet "" (fun target -> target :?> Style) (fun target value ->
            let target = (target :?> Style)

            for a in value.Setters do
                target.Setters.Add(a)

            for a in value.Animations do
                target.Animations.Add(a))

    let Animations =
        Attributes.defineListWidgetCollection "Style_Animations" (fun target -> (target :?> Style).Animations :> IList<_>)

    let Setters =
        Attributes.definePropertyWithGetSet<ISetter seq> "Style_Setters" (fun target -> (target :?> Style).Setters) (fun target value ->
            let target = (target :?> Style)
            target.Setters.Clear()

            for a in value do
                target.Setters.Add(a))

[<AutoOpen>]
module StyleBuilders =

    type Fabulous.Avalonia.View with

        static member Style() =
            WidgetBuilder<'msg, IFabStyle>(Style.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

        static member Style(setters: ISetter seq) =
            WidgetBuilder<'msg, IFabStyle>(Style.WidgetKey, Style.Style.WithValue(Style()), Style.Setters.WithValue(setters))

        static member Style(selector: string, setters: ISetter seq) =
            WidgetBuilder<'msg, IFabStyle>(Style.WidgetKey, Style.Style.WithValue(Style(fun x -> x.Class(selector))), Style.Setters.WithValue(setters))

[<Extension>]
type StyleModifiers =
    [<Extension>]
    static member inline animations(this: WidgetBuilder<'msg, #IFabStyle>) =
        AttributeCollectionBuilder<'msg, #IFabStyle, IFabAnimation>(this, Style.Animations)

[<Extension>]
type StyleCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabAnimation>
        (
            _: AttributeCollectionBuilder<'msg, 'marker, IFabAnimation>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IFabAnimation>
        (
            _: AttributeCollectionBuilder<'msg, 'marker, IFabAnimation>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
