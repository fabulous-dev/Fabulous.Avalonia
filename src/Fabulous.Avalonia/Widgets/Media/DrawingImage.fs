namespace Fabulous.Avalonia

open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabDrawingImage = inherit IFabControl

module DrawingImage =
    let WidgetKey = Widgets.register<DrawingImage>()
    
    let Drawing = Attributes.defineAvaloniaPropertyWithEquality DrawingImage.DrawingProperty
    
    let Invalidated = Attributes.defineEventNoArg "" (fun target -> (target :?> DrawingImage).Invalidated)
    
[<AutoOpen>]
module DrawingImageBuilders =
    type Fabulous.Avalonia.View with
        static member DrawingImage(drawing: Drawing) =
             WidgetBuilder<'msg, IFabDrawingImage>(
                DrawingImage.WidgetKey,
                AttributesBundle(
                    StackList.one(DrawingImage.Drawing.WithValue(drawing)),
                    ValueNone,
                    ValueNone)
                )
