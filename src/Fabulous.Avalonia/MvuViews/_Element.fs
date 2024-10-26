namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Avalonia

[<AbstractClass; Sealed>]
type View = class end

type IFabMvuElement =
    inherit IFabElement

// type ElementModifiers =
//     /// <summary>Listen to the widget being mounted</summary>
//     /// <param name="this">Current widget</param>
//     /// <param name="msg">Message to dispatch on trigger</param>
//     [<Extension>]
//     static member inline onMounted(this: WidgetBuilder<'msg, #IFabMvuElement>, msg: 'msg) =
//         this.AddScalar(MvuLifecycle.Mounted.WithValue(msg))
//
//     /// <summary>Listen to the widget being unmounted</summary>
//     /// <param name="this">Current widget</param>
//     /// <param name="msg">Message to dispatch on trigger</param>
//     [<Extension>]
//     static member inline onUnmounted(this: WidgetBuilder<'msg, #IFabMvuElement>, msg: 'msg) =
//         this.AddScalar(MvuLifecycle.Unmounted.WithValue(msg))
