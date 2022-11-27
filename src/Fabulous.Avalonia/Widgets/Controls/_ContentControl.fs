namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous

type IFabContentControl =
    inherit IFabTemplatedControl

module ContentControl =
    let Content = Attributes.defineAvaloniaPropertyWidget ContentControl.ContentProperty

    let ContentString =
        Attributes.defineAvaloniaProperty<string, obj>
            ContentControl.ContentProperty
            box
            ScalarAttributeComparers.equalityCompare
