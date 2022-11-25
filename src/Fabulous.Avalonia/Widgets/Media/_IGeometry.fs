namespace Fabulous.Avalonia

open Avalonia.Media

type IFabGeometry =
    inherit IFabControl
    
module Geometry =
    
    let Transform = Attributes.defineAvaloniaPropertyWithEquality Geometry.TransformProperty
