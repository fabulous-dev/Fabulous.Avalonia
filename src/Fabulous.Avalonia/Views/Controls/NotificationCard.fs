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

    let IsClosed =
        Attributes.defineAvaloniaPropertyWithEquality NotificationCard.IsClosedProperty

    let CloseOnClick =
        Attributes.defineAvaloniaPropertyWithEquality NotificationCard.CloseOnClickProperty

    let NotificationClosed =
        Attributes.defineEvent "NotificationCard_NotificationClosed" (fun target -> (target :?> NotificationCard).NotificationClosed)

[<AutoOpen>]
module NotificationCardBuilders =
    type Fabulous.Avalonia.View with

        static member NotificationCard(isClosed: bool, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabNotificationCard>(
                ThemeVariantScope.WidgetKey,
                AttributesBundle(
                    StackList.one(NotificationCard.IsClosed.WithValue(isClosed)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

[<Extension>]
type NotificationCardModifiers =

    [<Extension>]
    static member inline onNotificationClosed(this: WidgetBuilder<'msg, #IFabNotificationCard>, onNotificationClosed: RoutedEventArgs -> 'msg) =
        this.AddScalar(NotificationCard.NotificationClosed.WithValue(fun args -> onNotificationClosed args |> box))

    /// <summary>Link a ViewRef to access the direct NotificationCard control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabNotificationCard>, value: ViewRef<NotificationCard>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type NotificationCardAttachedModifiers =

    [<Extension>]
    static member inline closeOnClick(this: WidgetBuilder<'msg, #IFabButton>, value: bool) =
        this.AddScalar(NotificationCard.CloseOnClick.WithValue(value))
