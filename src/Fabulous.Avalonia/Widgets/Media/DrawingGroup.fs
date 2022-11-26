namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabDrawingGroup =
    inherit IFabDrawing

module DrawingGroup =
    let WidgetKey = Widgets.register<DrawingGroup>()
    
    let Opacity = Attributes.defineAvaloniaPropertyWithEquality DrawingGroup.OpacityProperty
    
    // FIXME Wrap all the Transform widgets
    let Transform = Attributes.defineAvaloniaPropertyWidget DrawingGroup.TransformProperty
    
     // FIXME Wrap all the Transform widgets
    let ClipGeometry = Attributes.defineAvaloniaPropertyWidget DrawingGroup.ClipGeometryProperty
    
    let OpacityMask = Attributes.defineAvaloniaPropertyWidget DrawingGroup.OpacityMaskProperty
    
    let Children =
        Attributes.defineAvaloniaListWidgetCollection
         "DrawingGroup_Children"
            (fun target -> (target :?> DrawingGroup).Children)
    
    
[<AutoOpen>]
module DrawingGroupBuilders =
    type Fabulous.Avalonia.View with
        static member DrawingGroup<'msg>() =
            CollectionBuilder<'msg, IFabDrawingGroup, IFabDrawing>(
                DrawingGroup.WidgetKey,
                DrawingGroup.Children
            )
            
             
[<Extension>]             
type DrawingGroupModifiers =
    [<Extension>]
    static member inline opacity(this: WidgetBuilder<'msg, #IFabDrawingGroup>, value: float) =
        this.AddScalar(DrawingGroup.Opacity.WithValue(value))
        

[<Extension>]
type DrawingGroupCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'marker :> IFabDrawing and 'itemType :> IFabControl>
        (
            _: CollectionBuilder<'msg, 'marker, IFabDrawing>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
        
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'marker :> IFabDrawing and 'itemType :> IFabControl>
        (
            _: CollectionBuilder<'msg, 'marker, IFabDrawing>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
