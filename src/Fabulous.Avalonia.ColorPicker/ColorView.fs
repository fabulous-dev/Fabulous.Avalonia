namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Layout
open Fabulous
open Fabulous.Avalonia

type IFabColorView =
    inherit IFabTemplatedControl
    
module ColorView =
    
    let Color = Attributes.defineAvaloniaPropertyWithEquality ColorView.ColorProperty
    
    let ColorModel = Attributes.defineAvaloniaPropertyWithEquality ColorView.ColorModelProperty
    
    let ColorSpectrumComponents = Attributes.defineAvaloniaPropertyWithEquality ColorView.ColorSpectrumComponentsProperty
    
    let ColorSpectrumShape = Attributes.defineAvaloniaPropertyWithEquality ColorView.ColorSpectrumShapeProperty
    
    let HexInputAlphaPosition = Attributes.defineAvaloniaPropertyWithEquality ColorView.HexInputAlphaPositionProperty
    
    let HsvColor = Attributes.defineAvaloniaPropertyWithEquality ColorView.HsvColorProperty
    
    let IsAccentColorsVisible = Attributes.defineAvaloniaPropertyWithEquality ColorView.IsAccentColorsVisibleProperty
    
    let IsAlphaEnabled = Attributes.defineAvaloniaPropertyWithEquality ColorView.IsAlphaEnabledProperty
    
    let IsAlphaVisible = Attributes.defineAvaloniaPropertyWithEquality ColorView.IsAlphaVisibleProperty
    
    let IsColorComponentsVisible = Attributes.defineAvaloniaPropertyWithEquality ColorView.IsColorComponentsVisibleProperty
    
    let IsColorModelVisible = Attributes.defineAvaloniaPropertyWithEquality ColorView.IsColorModelVisibleProperty
    
    let IsColorPaletteVisible = Attributes.defineAvaloniaPropertyWithEquality ColorView.IsColorPaletteVisibleProperty
    
    let IsColorPreviewVisible = Attributes.defineAvaloniaPropertyWithEquality ColorView.IsColorPreviewVisibleProperty
    
    let IsColorSpectrumVisible = Attributes.defineAvaloniaPropertyWithEquality ColorView.IsColorSpectrumVisibleProperty
    
    let IsColorSpectrumSliderVisible = Attributes.defineAvaloniaPropertyWithEquality ColorView.IsColorSpectrumSliderVisibleProperty
    
    let IsComponentSliderVisible = Attributes.defineAvaloniaPropertyWithEquality ColorView.IsComponentSliderVisibleProperty
    
    let IsComponentTextInputVisible = Attributes.defineAvaloniaPropertyWithEquality ColorView.IsComponentTextInputVisibleProperty
    
    let IsHexInputVisible = Attributes.defineAvaloniaPropertyWithEquality ColorView.IsHexInputVisibleProperty
    
    let MaxHue = Attributes.defineAvaloniaPropertyWithEquality ColorView.MaxHueProperty
    
    let MaxSaturation = Attributes.defineAvaloniaPropertyWithEquality ColorView.MaxSaturationProperty
    
    let MaxValue = Attributes.defineAvaloniaPropertyWithEquality ColorView.MaxValueProperty
    
    let MinHue = Attributes.defineAvaloniaPropertyWithEquality ColorView.MinHueProperty
    
    let MinSaturation = Attributes.defineAvaloniaPropertyWithEquality ColorView.MinSaturationProperty
    
    let PaletteColumnCount = Attributes.defineAvaloniaPropertyWithEquality ColorView.PaletteColumnCountProperty
    
    let Palette = Attributes.defineAvaloniaPropertyWithEquality ColorView.PaletteProperty
    
    let SelectedIndex = Attributes.defineAvaloniaPropertyWithEquality ColorView.SelectedIndexProperty
    
    let ColorChanged =
        Attributes.defineEvent "ColorView_ColorChanged" (fun target -> (target :?> ColorView).ColorChanged)
        
    let PaletteColors =
        Attributes.defineAvaloniaPropertyWithEquality ColorView.PaletteColorsProperty

// [<Extension>]
// type ItemsRepeaterModifiers =
//
//     /// <summary>Set the HorizontalCacheLength property.</summary>
//     /// <param name="this">Current widget.</param>
//     /// <param name="value">The HorizontalCacheLength value.</param>
//     [<Extension>]
//     static member inline horizontalCacheLength(this: WidgetBuilder<'msg, IFabItemsRepeater>, value: float) =
//         this.AddScalar(ColorPicker.HorizontalCacheLength.WithValue(value))
//
//     /// <summary>Set the VerticalCacheLength property.</summary>
//     /// <param name="this">Current widget.</param>
//     /// <param name="value">The VerticalCacheLength value.</param>
//     [<Extension>]
//     static member inline verticalCacheLength(this: WidgetBuilder<'msg, IFabItemsRepeater>, value: float) =
//         this.AddScalar(ColorPicker.VerticalCacheLength.WithValue(value))
//
//     /// <summary>Set the Layout property.</summary>
//     /// <param name="this">Current widget.</param>
//     /// <param name="value">The Layout value.</param>
//     [<Extension>]
//     static member inline layout(this: WidgetBuilder<'msg, IFabItemsRepeater>, value: AttachedLayout) =
//         this.AddScalar(ColorPicker.Layout.WithValue(value))
