namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Fabulous

type IFaDataValidationErrors =
    inherit IFabContentControl

module DataValidationErrors =
    let WidgetKey = Widgets.register<DataValidationErrors>()

    let Errors =
        Attributes.defineSimpleScalarWithEquality<Exception list> "DataValidationErrors_Errors" (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(DataValidationErrors.ErrorsProperty)
            | ValueSome errors -> target.SetValue(DataValidationErrors.ErrorsProperty, errors) |> ignore)

    let HasErrors =
        Attributes.defineAvaloniaPropertyWithEquality DataValidationErrors.HasErrorsProperty

[<Extension>]
type DataValidationErrorsModifiers =
    [<Extension>]
    static member inline hasErrors(this: WidgetBuilder<'msg, #IFaDataValidationErrors>, value: bool) =
        this.AddScalar(DataValidationErrors.HasErrors.WithValue(value))

    [<Extension>]
    static member inline dataValidationErrors(this: WidgetBuilder<'msg, #IFabControl>, errors: Exception list) =
        this.AddScalar(DataValidationErrors.Errors.WithValue(errors))
