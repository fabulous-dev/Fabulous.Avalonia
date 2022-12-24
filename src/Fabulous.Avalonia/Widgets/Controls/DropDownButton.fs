namespace Fabulous.Avalonia

open Avalonia.Controls
open Avalonia.Data.Converters
open Avalonia.Layout
open Fabulous
open System.Globalization
open System.Runtime.CompilerServices
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabDropDownButton =
    inherit IFabButton

module DropDownButton =
    let WidgetKey = Widgets.register<DropDownButton> ()

[<AutoOpen>]
module DropDownButtonBuilders =
    type Fabulous.Avalonia.View with

        static member inline DropDownButton(text: string, onClicked: 'msg) =
            WidgetBuilder<'msg, IFabDropDownButton>(
                DropDownButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                Button.Clicked.WithValue(fun _ -> box onClicked)
            )

        static member inline DropDownButton(content: WidgetBuilder<'msg, #IFabControl>, onClicked: 'msg) =
            WidgetBuilder<'msg, IFabDropDownButton>(
                DropDownButton.WidgetKey,
                AttributesBundle(
                    StackList.one (Button.Clicked.WithValue(fun _ -> box onClicked)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )
