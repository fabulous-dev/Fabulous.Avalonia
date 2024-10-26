namespace Fabulous.Avalonia.Mvu

open System
open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Controls.Primitives.PopupPositioning
open Avalonia.Input
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuPopup =
    inherit IFabMvuControl
    inherit IFabPopup

module MvuPopup =
    let Closed =
        Attributes.defineEvent "Popup_Closed" (fun target -> (target :?> Popup).Closed)

    let Opened =
       Attributes.defineEventNoArg "Popup_Opened" (fun target -> (target :?> Popup).Opened)

[<AutoOpen>]
module MvuPopupBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a Popup widget.</summary>
        /// <param name="isOpen">Whether the popup is open or not.</param>
        /// <param name="content">The content of the popup.</param>
        static member Popup(isOpen: bool, content: WidgetBuilder<unit, #IFabMvuControl>) =
            WidgetBuilder<unit, IFabMvuPopup>(
                Popup.WidgetKey,
                AttributesBundle(StackList.one(Popup.IsOpen.WithValue(isOpen)), ValueSome [| Popup.Child.WithValue(content.Compile()) |], ValueNone)
            )

type MvuPopupModifiers =
    /// <summary>Listens to the Popup Closed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the Popup is closed.</param>
    [<Extension>]
    static member inline onClosed(this: WidgetBuilder<unit, #IFabMvuPopup>, msg: 'msg) =
        this.AddScalar(MvuPopup.Closed.WithValue(fun _ -> msg))

    /// <summary>Listens to the Popup Opened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the Popup is opened.</param>
    [<Extension>]
    static member inline onOpened(this: WidgetBuilder<unit, #IFabMvuPopup>, msg: 'msg) =
        this.AddScalar(MvuPopup.Opened.WithValue(MsgValue msg))

    /// <summary>Link a ViewRef to access the direct Popup control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuPopup>, value: ViewRef<Popup>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
