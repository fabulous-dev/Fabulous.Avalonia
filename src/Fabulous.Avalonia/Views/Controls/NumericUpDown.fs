namespace Fabulous.Avalonia

open Avalonia.Controls
open Avalonia.Data.Converters
open Avalonia.Layout
open Fabulous
open System.Globalization
open System.Runtime.CompilerServices

type IFabNumericUpDown =
    inherit IFabTemplatedControl

module NumericUpDown =
    let WidgetKey = Widgets.register<NumericUpDown>()

    let AllowSpin =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.AllowSpinProperty

    let ButtonSpinnerLocation =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.ButtonSpinnerLocationProperty

    let ClipValueToMinMax =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.ClipValueToMinMaxProperty

    let FormatString =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.FormatStringProperty

    let HorizontalContentAlignment =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.HorizontalContentAlignmentProperty

    let VerticalContentAlignment =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.VerticalContentAlignmentProperty

    let Increment =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.IncrementProperty

    let IsReadOnly =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.IsReadOnlyProperty

    let Maximum =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.MaximumProperty

    let Minimum =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.MinimumProperty

    let NumberFormat =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.NumberFormatProperty

    let ParsingNumberStyle =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.ParsingNumberStyleProperty

    let ShowButtonSpinner =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.ShowButtonSpinnerProperty

    let Text = Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.TextProperty

    let TextConverter =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.TextConverterProperty

    let Watermark =
        Attributes.defineAvaloniaPropertyWithEquality NumericUpDown.WatermarkProperty

    let Value =
        Attributes.defineAvaloniaPropertyWithEqualityConverter NumericUpDown.ValueProperty Option.toNullable

    let ValueChanged =
        Attributes.defineAvaloniaPropertyWithChangedEvent "NumericUpDown_ValueChanged" NumericUpDown.ValueProperty Option.toNullable Option.ofNullable

[<AutoOpen>]
module NumericUpDownBuilders =
    type Fabulous.Avalonia.View with

        static member inline NumericUpDown<'msg>(value: decimal option, valueChanged: decimal option -> 'msg) =
            WidgetBuilder<'msg, IFabNumericUpDown>(
                NumericUpDown.WidgetKey,
                NumericUpDown.Value.WithValue(value),
                NumericUpDown.ValueChanged.WithValue(ValueEventData.create value (fun args -> valueChanged args |> box))
            )

[<Extension>]
type NumericUpDownModifiers =

    [<Extension>]
    static member inline allowSpin(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: bool) =
        this.AddScalar(NumericUpDown.AllowSpin.WithValue(value))

    [<Extension>]
    static member inline buttonSpinnerLocation(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: Location) =
        this.AddScalar(NumericUpDown.ButtonSpinnerLocation.WithValue(value))

    [<Extension>]
    static member inline clipValueToMinMax(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: bool) =
        this.AddScalar(NumericUpDown.ClipValueToMinMax.WithValue(value))

    [<Extension>]
    static member inline formatString(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: string) =
        this.AddScalar(NumericUpDown.FormatString.WithValue(value))

    [<Extension>]
    static member inline horizontalContentAlignment(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: HorizontalAlignment) =
        this.AddScalar(NumericUpDown.HorizontalContentAlignment.WithValue(value))

    [<Extension>]
    static member inline verticalContentAlignment(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: VerticalAlignment) =
        this.AddScalar(NumericUpDown.VerticalContentAlignment.WithValue(value))

    [<Extension>]
    static member inline increment(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: decimal) =
        this.AddScalar(NumericUpDown.Increment.WithValue(value))

    [<Extension>]
    static member inline isReadOnly(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: bool) =
        this.AddScalar(NumericUpDown.IsReadOnly.WithValue(value))

    [<Extension>]
    static member inline maximum(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: decimal) =
        this.AddScalar(NumericUpDown.Maximum.WithValue(value))

    [<Extension>]
    static member inline minimum(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: decimal) =
        this.AddScalar(NumericUpDown.Minimum.WithValue(value))

    [<Extension>]
    static member inline numberFormat(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: NumberFormatInfo) =
        this.AddScalar(NumericUpDown.NumberFormat.WithValue(value))

    [<Extension>]
    static member inline parsingNumberStyle(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: NumberStyles) =
        this.AddScalar(NumericUpDown.ParsingNumberStyle.WithValue(value))

    [<Extension>]
    static member inline showButtonSpinner(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: bool) =
        this.AddScalar(NumericUpDown.ShowButtonSpinner.WithValue(value))

    [<Extension>]
    static member inline text(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: string) =
        this.AddScalar(NumericUpDown.Text.WithValue(value))

    [<Extension>]
    static member inline textConverter(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: IValueConverter) =
        this.AddScalar(NumericUpDown.TextConverter.WithValue(value))

    [<Extension>]
    static member inline watermark(this: WidgetBuilder<'msg, #IFabNumericUpDown>, value: string) =
        this.AddScalar(NumericUpDown.Watermark.WithValue(value))

    /// <summary>Link a ViewRef to access the direct NumericUpDown control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabNumericUpDown>, value: ViewRef<NumericUpDown>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
