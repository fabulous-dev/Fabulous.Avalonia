namespace Fabulous.Avalonia.Tests

open Fabulous
open FsCheck
open NUnit.Framework
open FsUnit
open FsCheck.NUnit
open Fabulous.Avalonia

module Generators =
    // This is a hack to know how many widgets are currently registered
    // Fabulous needs to expose all the registered widget definitions
    let lastKey = WidgetDefinitionStore.getNextKey()
    
    let widgetKey =
        Arb.generate<int>
        |> Gen.where (fun v -> v > 0 && v < lastKey)
        
    let nonNullString =
        Arb.generate<string>
        |> Gen.where (fun v -> v <> null)

[<TestFixture>]
type ViewHelpers() =
    [<Property>]
    member _.``Existing Avalonia control can be reused if previous and current widgets are of the same type``() =
        let arb = Arb.fromGen Generators.widgetKey
        
        Prop.forAll arb (fun widgetKey ->
            let prev: Widget =
                { Key = widgetKey
                  DebugName = $"Widget-{widgetKey}"
                  ScalarAttributes = ValueNone
                  WidgetAttributes = ValueNone
                  WidgetCollectionAttributes = ValueNone }
                
            let curr: Widget =
                { Key = widgetKey
                  DebugName = $"Widget-{widgetKey}"
                  ScalarAttributes = ValueNone
                  WidgetAttributes = ValueNone
                  WidgetCollectionAttributes = ValueNone }
            
            let actual = ViewHelpers.canReuseView prev curr
            
            actual |> should equal true
        )
        
    [<Property>]
    member _.``Existing TextBlock control can not be reused if previous widget uses Text and current widget uses Inlines``() =
        let arb = Arb.fromGen Generators.nonNullString
        
        Prop.forAll arb (fun text ->
            let prev =
                { Key = TextBlock.WidgetKey
                  DebugName = "TextBlock"
                  ScalarAttributes =
                      ValueSome [|
                          { Key = TextBlock.Text.Key
                            DebugName = TextBlock.Text.Name
                            Value = text
                            NumericValue = 0uL }
                      |]
                  WidgetAttributes = ValueNone
                  WidgetCollectionAttributes = ValueNone }
                
            let curr =
                { Key = TextBlock.WidgetKey
                  DebugName = "TextBlock"
                  ScalarAttributes = ValueNone
                  WidgetAttributes = ValueNone
                  WidgetCollectionAttributes =
                      ValueSome [|
                          { Key = TextBlock.Inlines.Key
                            DebugName = TextBlock.Inlines.Name
                            Value = ArraySlice.emptyWithNull () }
                      |] }
            
            let actual = ViewHelpers.canReuseView prev curr
            
            actual |> should equal false
        )
        
    [<Property>]
    member _.``Existing TextBlock control can not be reused if previous widget uses Inlines and current widget uses Text``() =
        let arb = Arb.fromGen Generators.nonNullString
        
        Prop.forAll arb (fun text ->
            let prev =
                { Key = TextBlock.WidgetKey
                  DebugName = "TextBlock"
                  ScalarAttributes = ValueNone
                  WidgetAttributes = ValueNone
                  WidgetCollectionAttributes =
                      ValueSome [|
                          { Key = TextBlock.Inlines.Key
                            DebugName = TextBlock.Inlines.Name
                            Value = ArraySlice.emptyWithNull () }
                      |] }
                
            let curr =
                { Key = TextBlock.WidgetKey
                  DebugName = "TextBlock"
                  ScalarAttributes =
                      ValueSome [|
                          { Key = TextBlock.Text.Key
                            DebugName = TextBlock.Text.Name
                            Value = text
                            NumericValue = 0uL }
                      |]
                  WidgetAttributes = ValueNone
                  WidgetCollectionAttributes = ValueNone }
            
            let actual = ViewHelpers.canReuseView prev curr
            
            actual |> should equal false
        )
        