namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabDatePicker = inherit IFabTemplatedControl

// TODO: Add Header and missing Events
module DatePicker =
    let WidgetKey = Widgets.register<DatePicker>()
    let SelectedDate =
        Attributes.defineAvaloniaProperty<DateTimeOffset option, Nullable<DateTimeOffset>>
            DatePicker.SelectedDateProperty
            Option.toNullable
            ScalarAttributeComparers.equalityCompare
    
    let DayVisible = Attributes.defineAvaloniaPropertyWithEquality DatePicker.DayVisibleProperty
    
    let MonthVisible =
        Attributes.defineAvaloniaPropertyWithEquality DatePicker.MonthVisibleProperty
        
    let YearVisible =
        Attributes.defineAvaloniaPropertyWithEquality DatePicker.YearVisibleProperty
        
    let DayFormat =
        Attributes.defineAvaloniaPropertyWithEquality DatePicker.DayFormatProperty
        
    let MonthFormat =
        Attributes.defineAvaloniaPropertyWithEquality DatePicker.MonthFormatProperty
        
    let YearFormat =
        Attributes.defineAvaloniaPropertyWithEquality DatePicker.YearFormatProperty
        
    let MinYear =
        Attributes.defineAvaloniaPropertyWithEquality DatePicker.MinYearProperty
        
    let MaxYear = Attributes.defineAvaloniaPropertyWithEquality DatePicker.MaxYearProperty
    
            
[<AutoOpen>]
module DatePickerBuilders =
    type Fabulous.Avalonia.View with
        static member inline DatePicker(date: DateTimeOffset option) =
            WidgetBuilder<'msg, IFabDatePicker>(
                DatePicker.WidgetKey,
                DatePicker.SelectedDate.WithValue(date)
            )
            
[<Extension>]
type DatePickerModifiers =
    [<Extension>]
    static member inline dayVisible(this: WidgetBuilder<'msg, #IFabDatePicker>, value: bool) =
        this.AddScalar(DatePicker.DayVisible.WithValue(value))
        
    [<Extension>]
    static member inline monthVisible(this: WidgetBuilder<'msg, #IFabDatePicker>, value: bool) =
        this.AddScalar(DatePicker.MonthVisible.WithValue(value))
        
    [<Extension>]
    static member inline yearVisible(this: WidgetBuilder<'msg, #IFabDatePicker>, value: bool) =
        this.AddScalar(DatePicker.YearVisible.WithValue(value))
        
    [<Extension>]
    static member inline dayFormat(this: WidgetBuilder<'msg, #IFabDatePicker>, value: string) =
        this.AddScalar(DatePicker.DayFormat.WithValue(value))
    
    [<Extension>]
    static member inline monthFormat(this: WidgetBuilder<'msg, #IFabDatePicker>, value: string) =
        this.AddScalar(DatePicker.MonthFormat.WithValue(value))
        
    [<Extension>]
    static member inline yearFormat(this: WidgetBuilder<'msg, #IFabDatePicker>, value: string) =
        this.AddScalar(DatePicker.YearFormat.WithValue(value))
        
    [<Extension>]
    static member inline minYear(this: WidgetBuilder<'msg, #IFabDatePicker>, value: DateTimeOffset) =
        this.AddScalar(DatePicker.MinYear.WithValue(value))
        
    [<Extension>]
    static member inline maxYear(this: WidgetBuilder<'msg, #IFabDatePicker>, value: DateTimeOffset) =
        this.AddScalar(DatePicker.MaxYear.WithValue(value))    
