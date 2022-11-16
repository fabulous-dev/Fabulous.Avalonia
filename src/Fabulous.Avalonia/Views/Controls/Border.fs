namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabBorder = inherit IFabDecorator

module Border =
    let WidgetKey = Widgets.register<Border>()

    let Background =
        Attributes.defineAvaloniaPropertyWithEquality Border.BackgroundProperty
     
    let BorderBrush =
        Attributes.defineAvaloniaPropertyWithEquality Border.BorderBrushProperty

    let BorderThickness =
        Attributes.defineAvaloniaPropertyWithEquality Border.BorderThicknessProperty
        
    let CornerRadius =
        Attributes.defineAvaloniaPropertyWithEquality Border.CornerRadiusProperty
        
    let BoxShadow =
        Attributes.defineAvaloniaPropertyWithEquality Border.BoxShadowProperty
        
    let BorderDashArray =
        Attributes.defineAvaloniaPropertyWithEquality Border.BorderDashArrayProperty
        
    let BorderLineCap =
        Attributes.defineAvaloniaPropertyWithEquality Border.BorderLineCapProperty
        
    let BorderLineJoin =
        Attributes.defineAvaloniaPropertyWithEquality Border.BorderLineJoinProperty
            
 [<AutoOpen>]
 module BorderBuilders =
     type Fabulous.Avalonia.View with
         static member Border(content: WidgetBuilder<'msg, #IFabControl>) =
             WidgetBuilder<'msg, IFabBorder>(
                 Border.WidgetKey,
                 AttributesBundle(
                     StackList.empty(),
                     ValueSome [|Decorator.Child.WithValue(content.Compile())|],
                     ValueNone
                 )
             )

[<Extension>]
type BorderModifiers =
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabBorder>, value: IBrush) =
        this.AddScalar(Border.Background.WithValue(value))
        
        
    [<Extension>]
    static member inline borderBrush(this: WidgetBuilder<'msg, #IFabBorder>, value: IBrush) =
        this.AddScalar(Border.BorderBrush.WithValue(value))
        
        
    [<Extension>]
    static member inline borderThickness(this: WidgetBuilder<'msg, #IFabBorder>, value: Thickness) =
        this.AddScalar(Border.BorderThickness.WithValue(value))
        
        
    [<Extension>]
    static member inline cornerRadius(this: WidgetBuilder<'msg, #IFabBorder>, value: CornerRadius) =
        this.AddScalar(Border.CornerRadius.WithValue(value))
        
        
    [<Extension>]
    static member inline boxShadow(this: WidgetBuilder<'msg, #IFabBorder>, value: BoxShadows) =
        this.AddScalar(Border.BoxShadow.WithValue(value))
