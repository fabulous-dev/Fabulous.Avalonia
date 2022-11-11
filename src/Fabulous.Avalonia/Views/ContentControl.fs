namespace Fabulous.Avalonia

open Avalonia.Controls

type IFabContentControl = inherit IFabTemplatedControl

module ContentControl =
    let Content = Attributes.defineStyledWidget ContentControl.ContentProperty