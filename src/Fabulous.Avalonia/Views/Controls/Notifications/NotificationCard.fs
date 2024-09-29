namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Notifications
open Avalonia.Interactivity
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabNotificationCard =
    inherit IFabContentControl

module NotificationCard =
    let WidgetKey = Widgets.register<NotificationCard>()

    let NotificationType =
        Attributes.defineAvaloniaPropertyWithEquality NotificationCard.NotificationTypeProperty

    let IsClosed =
        Attributes.defineAvaloniaPropertyWithEquality NotificationCard.IsClosedProperty

    let CloseOnClick =
        Attributes.defineAvaloniaPropertyWithEquality NotificationCard.CloseOnClickProperty


type NotificationCardModifiers =

    /// <summary>Sets the NotificationType property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The NotificationType value.</param>
    [<Extension>]
    static member inline notificationType(this: WidgetBuilder<'msg, #IFabNotificationCard>, value: NotificationType) =
        this.AddScalar(NotificationCard.NotificationType.WithValue(value))

    /// <summary>Link a ViewRef to access the direct NotificationCard control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabNotificationCard>, value: ViewRef<NotificationCard>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type NotificationCardAttachedModifiers =

    /// <summary>Sets the CloseOnClick property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CloseOnClick value.</param>
    [<Extension>]
    static member inline closeOnClick(this: WidgetBuilder<'msg, #IFabButton>, value: bool) =
        this.AddScalar(NotificationCard.CloseOnClick.WithValue(value))
