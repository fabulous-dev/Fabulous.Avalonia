namespace Fabulous.Avalonia

open Avalonia
open Avalonia.Styling
open Fabulous
open Fabulous.Avalonia.Mvu

[<AbstractClass; Sealed>]
type ThemeAware =
    static member With(light: 'T, dark: 'T) =
        if Application.Current.ActualThemeVariant = ThemeVariant.Dark then
            dark
        else
            light

module ThemeAwareProgram =
    type Model<'model> = { Theme: ThemeVariant; Model: 'model }

    type Msg<'msg> =
        | ThemeChanged
        | ModelMsg of 'msg

    let init (init: 'arg -> 'model * Cmd<'msg>) (arg: 'arg) =
        let model, cmd = init arg

        { Theme = Application.Current.ActualThemeVariant
          Model = model },
        Cmd.map ModelMsg cmd

    let update (update: 'msg * 'model -> 'model * Cmd<'msg>) (msg: Msg<'msg>, model: Model<'model>) =
        match msg with
        | ThemeChanged ->
            { model with
                Theme = Application.Current.ActualThemeVariant },
            Cmd.none
        | ModelMsg msg ->
            let subModel, cmd = update(msg, model.Model)
            { model with Model = subModel }, Cmd.map ModelMsg cmd

    let view (subView: 'model -> WidgetBuilder<'msg, #IFabMvuApplication>) (model: Model<'model>) =
        (View.map ModelMsg (subView model.Model))
            .onActualThemeVariantChanged(ThemeChanged)
