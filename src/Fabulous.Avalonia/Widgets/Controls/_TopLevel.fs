namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabTopLevel =
    inherit IFabContentControl

module TopLevel =

    let TransparencyLevelHint =
        Attributes.defineAvaloniaPropertyWithEquality TopLevel.TransparencyLevelHintProperty

    let TransparencyBackgroundFallback =
        Attributes.defineAvaloniaPropertyWidget TopLevel.TransparencyBackgroundFallbackProperty

    let Opened =
        Attributes.defineEventNoArg "TopLevel_OpenedEvent" (fun target -> (target :?> TopLevel).Opened)

    let Closed =
        Attributes.defineEventNoArg "TopLevel_ClosedEvent" (fun target -> (target :?> TopLevel).Closed)

[<Extension>]
type TopLevelModifiers =
    [<Extension>]
    static member inline transparencyLevelHint
        (
            this: WidgetBuilder<'msg, #IFabTopLevel>,
            alignment: WindowTransparencyLevel
        ) =
        this.AddScalar(TopLevel.TransparencyLevelHint.WithValue(alignment))

    [<Extension>]
    static member inline transparencyBackgroundFallback
        (
            this: WidgetBuilder<'msg, #IFabTopLevel>,
            content: WidgetBuilder<'msg, #IFabBrush>
        ) =
        this.AddWidget(TopLevel.TransparencyBackgroundFallback.WithValue(content.Compile()))

    [<Extension>]
    static member inline onOpened(this: WidgetBuilder<'msg, #IFabTopLevel>, onOpened: 'msg) =
        this.AddScalar(TopLevel.Opened.WithValue(onOpened))

    [<Extension>]
    static member inline onClosed(this: WidgetBuilder<'msg, #IFabTopLevel>, onClosed: 'msg) =
        this.AddScalar(TopLevel.Closed.WithValue(onClosed))
