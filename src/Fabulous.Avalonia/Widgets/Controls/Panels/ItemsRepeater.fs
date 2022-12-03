namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabItemsRepeater =
    inherit IFabPanel

module ItemsRepeater =
    let WidgetKey = Widgets.register<ItemsRepeater>()
    
    let HorizontalCacheLength =
        Attributes.defineAvaloniaPropertyWithEquality ItemsRepeater.HorizontalCacheLengthProperty
        
    let VerticalCacheLength =
        Attributes.defineAvaloniaPropertyWithEquality ItemsRepeater.VerticalCacheLengthProperty
    
    // FIXME : Add Items property wrapper
    // Add a Widget constructor

[<Extension>]
type ItemsRepeaterModifiers =
    [<Extension>]
    static member inline horizontalCacheLength(this: WidgetBuilder<'msg, #IFabItemsRepeater>, cacheLength: float) =
        this.AddScalar(ItemsRepeater.HorizontalCacheLength.WithValue(cacheLength))
        
    [<Extension>]
    static member inline verticalCacheLength(this: WidgetBuilder<'msg, #IFabItemsRepeater>, cacheLength: float) =
        this.AddScalar(ItemsRepeater.VerticalCacheLength.WithValue(cacheLength))
