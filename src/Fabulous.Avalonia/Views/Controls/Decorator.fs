namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous

type IFabDecorator = inherit IFabControl

module Decorator =     
    let Child =
        Attributes.defineAvaloniaPropertyWidget Decorator.ChildProperty
        
    let Padding =
        Attributes.defineAvaloniaPropertyWithEquality Decorator.PaddingProperty
