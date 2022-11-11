namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous

type IFabContentControl = inherit IFabTemplatedControl

module ContentControl =
    let Content = Attributes.defineStyledWidget ContentControl.ContentProperty
    let ContentString = Attributes.defineStyled<string, obj> ContentControl.ContentProperty box ScalarAttributeComparers.equalityCompare