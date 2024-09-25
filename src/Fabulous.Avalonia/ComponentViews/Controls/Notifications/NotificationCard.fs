namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Notifications
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentNotificationCard =
    inherit IFabComponentContentControl
    inherit IFabNotificationCard

module ComponentNotificationCard =
    let NotificationClosed =
        ComponentAttributes.defineEvent "NotificationCard_NotificationClosed" (fun target -> (target :?> NotificationCard).NotificationClosed)

[<AutoOpen>]
module ComponentNotificationCardBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a NotificationCard widget.</summary>
        /// <param name="isClosed">Whether the NotificationCard is closed.</param>
        /// <param name="content">The content of the NotificationCard.</param>
        static member NotificationCard(isClosed: bool, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<unit, IFabComponentNotificationCard>(
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
            WidgetBuilder<unit, IFabComponentNotificationCard>(
                NotificationCard.WidgetKey,
                NotificationCard.IsClosed.WithValue(isClosed),
                ContentControl.ContentString.WithValue(content)
            )

type ComponentNotificationCardModifiers =
    /// <summary>Listens to the NotificationCard NotificationClosed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the NotificationCard is closed.</param>
    [<Extension>]
    static member inline onNotificationClosed(this: WidgetBuilder<unit, #IFabNotificationCard>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentNotificationCard.NotificationClosed.WithValue(fn))

    /// <summary>Link a ViewRef to access the direct NotificationCard control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabComponentNotificationCard>, value: ViewRef<NotificationCard>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
