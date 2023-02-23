namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous

type IFabTileBrush =
    inherit IFabBrush

module TileBrush =
    let AlignmentX =
        Attributes.defineAvaloniaPropertyWithEquality TileBrush.AlignmentXProperty

    let AlignmentY =
        Attributes.defineAvaloniaPropertyWithEquality TileBrush.AlignmentYProperty

    let DestinationRect =
        Attributes.defineAvaloniaPropertyWithEquality TileBrush.DestinationRectProperty

    let SourceRect =
        Attributes.defineAvaloniaPropertyWithEquality TileBrush.SourceRectProperty

    let Stretch =
        Attributes.defineAvaloniaPropertyWithEquality TileBrush.StretchProperty

    let TileMode =
        Attributes.defineAvaloniaPropertyWithEquality TileBrush.TileModeProperty

[<Extension>]
type TileBrushModifiers =

    [<Extension>]
    static member inline alignmentX(this: WidgetBuilder<'msg, #IFabTileBrush>, value: AlignmentX) =
        this.AddScalar(TileBrush.AlignmentX.WithValue(value))

    [<Extension>]
    static member inline alignmentY(this: WidgetBuilder<'msg, #IFabTileBrush>, value: AlignmentY) =
        this.AddScalar(TileBrush.AlignmentY.WithValue(value))

    [<Extension>]
    static member inline destinationRect(this: WidgetBuilder<'msg, #IFabTileBrush>, value: RelativeRect) =
        this.AddScalar(TileBrush.DestinationRect.WithValue(value))

    [<Extension>]
    static member inline destinationRect(this: WidgetBuilder<'msg, #IFabTileBrush>, rect: Rect, unit: RelativeUnit) =
        this.AddScalar(TileBrush.DestinationRect.WithValue(RelativeRect(rect, unit)))

    [<Extension>]
    static member inline destinationRect(this: WidgetBuilder<'msg, #IFabTileBrush>, point: Point, size: Size, unit: RelativeUnit) =
        this.AddScalar(TileBrush.DestinationRect.WithValue(RelativeRect(point, size, unit)))

    [<Extension>]
    static member inline sourceRect(this: WidgetBuilder<'msg, #IFabTileBrush>, value: RelativeRect) =
        this.AddScalar(TileBrush.SourceRect.WithValue(value))
        
    [<Extension>]
    static member inline sourceRect(this: WidgetBuilder<'msg, #IFabTileBrush>, rect: Rect, unit: RelativeUnit) =
        this.AddScalar(TileBrush.SourceRect.WithValue(RelativeRect(rect, unit)))

    [<Extension>]
    static member inline sourceRect(this: WidgetBuilder<'msg, #IFabTileBrush>, point: Point, size: Size, unit: RelativeUnit) =
        this.AddScalar(TileBrush.SourceRect.WithValue(RelativeRect(point, size, unit)))

    [<Extension>]
    static member inline stretch(this: WidgetBuilder<'msg, #IFabTileBrush>, value: Stretch) =
        this.AddScalar(TileBrush.Stretch.WithValue(value))

    [<Extension>]
    static member inline tileMode(this: WidgetBuilder<'msg, #IFabTileBrush>, value: TileMode) =
        this.AddScalar(TileBrush.TileMode.WithValue(value))
