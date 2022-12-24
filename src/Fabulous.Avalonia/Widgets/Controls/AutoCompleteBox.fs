namespace Fabulous.Avalonia

open System.ComponentModel
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabAutoCompleteBox =
    inherit IFabTemplatedControl

module AutoCompleteBox =
    let WidgetKey = Widgets.register<AutoCompleteBox> ()
    
    let WatermarkProperty = Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.WatermarkProperty
    
    let MinimumPrefixLengthProperty = Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.MinimumPrefixLengthProperty
    
    let MinimumPopulateDelayProperty = Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.MinimumPopulateDelayProperty
    
    let MaxDropDownHeightProperty = Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.MaxDropDownHeightProperty
    
    let IsTextCompletionEnabledProperty = Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.IsTextCompletionEnabledProperty
    
    let IsDropDownOpenProperty = Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.IsDropDownOpenProperty
    
    //let SelectedItem = Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.SelectedItemProperty
    let SelectedItem<'T when 'T: equality> =
        Attributes.defineSimpleScalar<'T>
            "AutoCompleteBox_SelectedItem"
            ScalarAttributeComparers.equalityCompare
            (fun _ newValueOpt node ->
                let control = node.Target :?> AutoCompleteBox

                match newValueOpt with
                | ValueNone -> control.ClearValue(AutoCompleteBox.SelectedItemProperty)
                | ValueSome value -> control.SetValue(AutoCompleteBox.SelectedItemProperty, value))


    let Text = Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.TextProperty
    
    let SearchText = Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.SearchTextProperty
    
    let FilterMode = Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.FilterModeProperty
    
    let ItemFilter = Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.ItemFilterProperty
    
    let TextFilter = Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.TextFilterProperty
    
    let ItemSelector = Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.ItemSelectorProperty
    
    let TextSelector = Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.TextSelectorProperty
    
    let Items<'T when 'T: equality> =
        Attributes.defineSimpleScalar<'T>
            "AutoCompleteBox_Items"
            ScalarAttributeComparers.equalityCompare
            (fun _ newValueOpt node ->
                let autoCompleteBox = node.Target :?> AutoCompleteBox

                match newValueOpt with
                | ValueNone -> autoCompleteBox.ClearValue(AutoCompleteBox.ItemsProperty)
                | ValueSome value -> autoCompleteBox.SetValue(AutoCompleteBox.ItemsProperty, value) |> ignore)
         
    // FIXME
    let AsyncPopulator = Attributes.defineAvaloniaPropertyWithEquality AutoCompleteBox.AsyncPopulatorProperty

    // Events
    
    let TextChanged =
        Attributes.defineEvent<TextChangedEventArgs>
            "AutoCompleteBox_TextChanged"
            (fun target -> (target :?> AutoCompleteBox).TextChanged)
            
    let Populating =
        Attributes.defineEvent<PopulatingEventArgs>
            "AutoCompleteBox_Populating"
            (fun target -> (target :?> AutoCompleteBox).Populating)
            
    let Populated =
        Attributes.defineEvent<PopulatedEventArgs>
            "AutoCompleteBox_Populated"
            (fun target -> (target :?> AutoCompleteBox).Populated)
            
    let DropDownOpening =
        Attributes.defineEvent<CancelEventArgs>
            "AutoCompleteBox_DropDownOpening"
            (fun target -> (target :?> AutoCompleteBox).DropDownOpening)
            
            
    let DropDownOpened =
        Attributes.defineEventNoArg
            "AutoCompleteBox_DropDownOpened"
            (fun target -> (target :?> AutoCompleteBox).DropDownOpened)
            
    let DropDownClosing =
        Attributes.defineEvent<CancelEventArgs>
            "AutoCompleteBox_DropDownClosing"
            (fun target -> (target :?> AutoCompleteBox).DropDownClosing)
            
    let DropDownClosed =
        Attributes.defineEventNoArg
            "AutoCompleteBox_DropDownClosed"
            (fun target -> (target :?> AutoCompleteBox).DropDownClosed)
            
    let SelectionChanged =
        Attributes.defineEvent<SelectionChangedEventArgs>
            "AutoCompleteBox_SelectionChanged"
            (fun target -> (target :?> AutoCompleteBox).SelectionChanged)
            
[<AutoOpen>]
module AutoCompleteBoxBuilders =
    type Fabulous.Avalonia.View with

        static member AutoCompleteBox(items: string list) =
            WidgetBuilder<'msg, IFabAutoCompleteBox>(
                AutoCompleteBox.WidgetKey,
                AutoCompleteBox.Items.WithValue(items)
            )
