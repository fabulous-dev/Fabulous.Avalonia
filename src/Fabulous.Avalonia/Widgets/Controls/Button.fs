namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous

type IFabButton = inherit IFabContentControl

module Button =
    let WidgetKey = Widgets.register<Button>()
    let Clicked = Attributes.defineEvent "Button_Clicked" (fun target -> (target :?> Button).Click)
    
[<AutoOpen>]
module ButtonBuilders =
    type Fabulous.Avalonia.View with
        static member inline Button(text: string, onClicked: 'msg) =
            WidgetBuilder<'msg, IFabButton>(
                Button.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                Button.Clicked.WithValue(fun _ -> box onClicked)
            )