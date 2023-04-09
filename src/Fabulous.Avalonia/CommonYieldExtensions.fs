namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections

[<Extension>]
type CommonYieldExtensions =
    [<Extension>]
    static member inline Yield(_: AttributeCollectionBuilder<'msg, 'parent, 'child>, x: WidgetBuilder<'msg, 'child>) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield(_: AttributeCollectionBuilder<'msg, 'parent, 'child>, x: WidgetBuilder<'msg, Memo.Memoized<'child>>) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'parent, 'itemType>(_: CollectionBuilder<'msg, 'parent, 'itemType>, x: WidgetBuilder<'msg, 'itemType>) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'parent, 'itemType>
        (
            _: CollectionBuilder<'msg, 'parent, 'itemType>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
