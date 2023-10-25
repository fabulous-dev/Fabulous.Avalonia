namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabColorSpectrum =
    inherit IFabTemplatedControl

module ColorSpectrum =
    let WidgetKey = Widgets.register<ColorSpectrum>()

    let Color =
        Attributes.defineAvaloniaPropertyWithEquality ColorSpectrum.ColorProperty

    let Components =
        Attributes.defineAvaloniaPropertyWithEquality ColorSpectrum.ComponentsProperty

    let HsvColor =
        Attributes.defineAvaloniaPropertyWithEquality ColorSpectrum.HsvColorProperty

    let MaxHue =
        Attributes.defineAvaloniaPropertyWithEquality ColorSpectrum.MaxHueProperty

    let MaxSaturation =
        Attributes.defineAvaloniaPropertyWithEquality ColorSpectrum.MaxSaturationProperty

    let MaxValue =
        Attributes.defineAvaloniaPropertyWithEquality ColorSpectrum.MaxValueProperty

    let MinHue =
        Attributes.defineAvaloniaPropertyWithEquality ColorSpectrum.MinHueProperty

    let MinSaturation =
        Attributes.defineAvaloniaPropertyWithEquality ColorSpectrum.MinSaturationProperty

    let MinValue =
        Attributes.defineAvaloniaPropertyWithEquality ColorSpectrum.MinValueProperty

    let Shape =
        Attributes.defineAvaloniaPropertyWithEquality ColorSpectrum.ShapeProperty

    let ColorChanged =
        Attributes.defineEvent "ColorView_ColorChanged" (fun target -> (target :?> ColorView).ColorChanged)

[<AutoOpen>]
module ColorSpectrumBuilders =
    type Fabulous.Avalonia.View with

        static member ColorSpectrum<'msg>() =
            WidgetBuilder<'msg, IFabColorSpectrum>(ColorSpectrum.WidgetKey, AttributesBundle(StackList.empty(), ValueNone, ValueNone))

[<Extension>]
type ColorSpectrumModifiers =
    /// <summary>Link a ViewRef to access the direct ColorSpectrum control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabColorSpectrum>, value: ViewRef<ColorSpectrum>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
