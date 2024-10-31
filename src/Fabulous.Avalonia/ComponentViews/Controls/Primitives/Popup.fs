namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentPopup =
    inherit IFabComponentControl
    inherit IFabPopup

module ComponentPopup =
    let Closed =
        Attributes.defineEventNoDispatch "Popup_Closed" (fun target -> (target :?> Popup).Closed)

    let Opened =
        Attributes.defineEventNoArgNoDispatch "Popup_Opened" (fun target -> (target :?> Popup).Opened)

[<AutoOpen>]
module ComponentPopupBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a Popup widget.</summary>
        /// <param name="isOpen">Whether the popup is open or not.</param>
        /// <param name="content">The content of the popup.</param>
        static member Popup(isOpen: bool, content: WidgetBuilder<unit, #IFabComponentControl>) =
            WidgetBuilder<unit, IFabComponentPopup>(
                Popup.WidgetKey,
                AttributesBundle(StackList.one(Popup.IsOpen.WithValue(isOpen)), ValueSome [| Popup.Child.WithValue(content.Compile()) |], ValueNone)
            )

type ComponentPopupModifiers =
    /// <summary>Listens to the Popup Closed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the Popup is closed.</param>
    [<Extension>]
    static member inline onClosed(this: WidgetBuilder<unit, #IFabComponentPopup>, msg: unit -> unit) =
        this.AddScalar(ComponentPopup.Closed.WithValue(fun _ -> msg()))

    /// <summary>Listens to the Popup Opened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the Popup is opened.</param>
    [<Extension>]
    static member inline onOpened(this: WidgetBuilder<unit, #IFabComponentPopup>, msg: unit -> unit) =
        this.AddScalar(ComponentPopup.Opened.WithValue(msg))
