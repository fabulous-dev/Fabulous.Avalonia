namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls.Notifications
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuNotificationCard =
    inherit IFabMvuContentControl
    inherit IFabNotificationCard

module MvuNotificationCard =
    let NotificationClosed =
        Attributes.defineEvent "NotificationCard_NotificationClosed" (fun target -> (target :?> NotificationCard).NotificationClosed)

[<AutoOpen>]
module MvuNotificationCardBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a NotificationCard widget.</summary>
        /// <param name="isClosed">Whether the NotificationCard is closed.</param>
        /// <param name="content">The content of the NotificationCard.</param>
        static member NotificationCard(isClosed: bool, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<unit, IFabMvuNotificationCard>(
                NotificationCard.WidgetKey,
                AttributesBundle(
                    StackList.one(NotificationCard.IsClosed.WithValue(isClosed)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

        /// <summary>Creates a NotificationCard widget.</summary>
        /// <param name="isClosed">Whether the NotificationCard is closed.</param>
        /// <param name="content">The content of the NotificationCard.</param>
        static member NotificationCard(isClosed: bool, content: string) =
            WidgetBuilder<unit, IFabMvuNotificationCard>(
                NotificationCard.WidgetKey,
                NotificationCard.IsClosed.WithValue(isClosed),
                ContentControl.ContentString.WithValue(content)
            )

type MvuNotificationCardModifiers =
    /// <summary>Listens to the NotificationCard NotificationClosed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the NotificationCard is closed.</param>
    [<Extension>]
    static member inline onNotificationClosed(this: WidgetBuilder<unit, #IFabNotificationCard>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(MvuNotificationCard.NotificationClosed.WithValue(fn))

    /// <summary>Link a ViewRef to access the direct NotificationCard control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuNotificationCard>, value: ViewRef<NotificationCard>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
