namespace Fabulous.Avalonia.Components

open Avalonia.Controls.Notifications
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentWindowNotificationManager =
    inherit IFabComponentTemplatedControl
    inherit IFabWindowNotificationManager

[<AutoOpen>]
module ComponentWindowNotificationManagerBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a WindowNotificationManager widget.</summary>
        static member WindowNotificationManager(viewRef: ViewRef<WindowNotificationManager>) =
            WidgetBuilder<unit, IFabComponentWindowNotificationManager>(
                WindowNotificationManager.WidgetKey,
                AttributesBundle(StackList.one(ViewRefAttributes.ViewRef.WithValue(viewRef.Unbox)), ValueNone, ValueNone)
            )
