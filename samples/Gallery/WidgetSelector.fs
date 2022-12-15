namespace Gallery

open System
open Avalonia.Media
open Fabulous.Avalonia
open Avalonia

open type Fabulous.Avalonia.View

type WidgetType =
    | Run
    | Code

type WidgetView = { Value: WidgetType; Text: string }

module WidgetSelector =
    let radioButton (path: string) (isSelected: bool) (onSelected: 'msg) =
        let foreground =
            Path(path)
                .fill(SolidColorBrush(Colors.Black))
                .stroke (
                    if isSelected then
                        SolidColorBrush(Colors.White)
                    else
                        SolidColorBrush(Colors.LightGray)
                )

        Border(
            Button(foreground, onSelected)
                //.isEnabled(isSelected)
                .centerHorizontal()
                .centerVertical()
                .foreground (
                    if isSelected then
                        SolidColorBrush(Colors.White)
                    else
                        SolidColorBrush(Colors.LightGray)
                )
        )
            .borderBrush(
                if isSelected then
                    SolidColorBrush(Color.Parse("#1a76d2"))
                else
                    SolidColorBrush(Colors.LightGray)
            )
            .borderThickness(0.5)
            .background(
                if isSelected then
                    SolidColorBrush(Color.Parse("#2196f3"))
                else
                    SolidColorBrush(Colors.LightGray)
            )
            .padding (0.)

[<AutoOpen>]
module WidgetSelectorBuilders =
    open WidgetSelector

    type Fabulous.Avalonia.View with

        static member inline WidgetSelector
            (
                items: WidgetView list,
                selectedItem: WidgetType,
                onSelectionChanged: WidgetType -> 'msg
            ) =
            HStack(8.0) {
                for item in items do
                    radioButton item.Text (selectedItem = item.Value) (onSelectionChanged item.Value)
            }
