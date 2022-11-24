namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabImage = inherit IFabControl

module Image =
    let WidgetKey = Widgets.register<Image>()
    
    let Source = Attributes.defineAvaloniaPropertyWidget Image.SourceProperty
    
    let Stretch = Attributes.defineAvaloniaPropertyWithEquality Image.StretchProperty
    
    let StretchDirection = Attributes.defineAvaloniaPropertyWithEquality Image.StretchDirectionProperty
    
[<AutoOpen>]
module ImageBuilders =
    type Fabulous.Avalonia.View with
        static member Image(source: WidgetBuilder<'msg, #IFabControl>) =
             WidgetBuilder<'msg, IFabImage>(
                Image.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome [| Image.Source.WithValue(source.Compile()) |],
                    ValueNone)
                )

[<Extension>]             
type ImageModifiers =
    [<Extension>]
    static member inline stretch(this: WidgetBuilder<'msg, #IFabImage>, value: Stretch) =
        this.AddScalar(Image.Stretch.WithValue(value))
        
    [<Extension>]
    static member inline stretchDirection(this: WidgetBuilder<'msg, #IFabImage>, value: StretchDirection) =
        this.AddScalar(Image.StretchDirection.WithValue(value))
