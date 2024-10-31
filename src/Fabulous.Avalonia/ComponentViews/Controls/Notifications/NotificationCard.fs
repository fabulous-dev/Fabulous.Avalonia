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
        Attributes.defineEventNoDispatch "NotificationCard_NotificationClosed" (fun target -> (target :?> NotificationCard).NotificationClosed)

[<AutoOpen>]
module ComponentNotificationCardBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a NotificationCard widget.</summary>
        /// <param name="isClosed">Whether the NotificationCard is closed.</param>
        /// <param name="content">The content of the NotificationCard.</param>
        static member NotificationCard(isClosed: bool, content: WidgetBuilder<unit, #IFabComponentControl>) =
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
    static member inline onNotificationClosed(this: WidgetBuilder<unit, #IFabComponentNotificationCard>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentNotificationCard.NotificationClosed.WithValue(fn))
