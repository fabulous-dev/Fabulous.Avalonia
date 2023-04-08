namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabDropDownButton =
    inherit IFabButton

module DropDownButton =
    let WidgetKey = Widgets.register<DropDownButton>()

[<AutoOpen>]
module DropDownButtonBuilders =
    type Fabulous.Avalonia.View with

        static member inline DropDownButton<'msg>(text: string, onClicked: 'msg) =
            WidgetBuilder<'msg, IFabDropDownButton>(
                DropDownButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                Button.Clicked.WithValue(fun _ -> box onClicked)
            )

        static member inline DropDownButton(onClicked: 'msg, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabDropDownButton>(
                DropDownButton.WidgetKey,
                AttributesBundle(
                    StackList.one(Button.Clicked.WithValue(fun _ -> box onClicked)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

[<Extension>]
type DropDownButtonModifiers =
    /// <summary>Link a ViewRef to access the direct DropDownButton control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabDropDownButton>, value: ViewRef<DropDownButton>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
