namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuDropDownButton =
    inherit IFabMvuButton
    inherit IFabDropDownButton

[<AutoOpen>]
module MvuDropDownButtonBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a DropDownButton widget.</summary>
        /// <param name="text">The text to display.</param>
        /// <param name="msg">Raised when the DropDownButton is clicked.</param>
        static member DropDownButton(text: string, msg: RoutedEventArgs -> unit) =
            WidgetBuilder<unit, IFabMvuDropDownButton>(
                DropDownButton.WidgetKey,
                ContentControl.ContentString.WithValue(text),
                MvuButton.Clicked.WithValue(msg)
            )

        /// <summary>Creates a DropDownButton widget.</summary>
        /// <param name="msg">Raised when the DropDownButton is clicked.</param>
        /// <param name="content">The content of the DropDownButton.</param>
        static member DropDownButton(msg: RoutedEventArgs -> unit, content: WidgetBuilder<unit, #IFabMvuControl>) =
            WidgetBuilder<unit, IFabMvuDropDownButton>(
                DropDownButton.WidgetKey,
                AttributesBundle(
                    StackList.one(MvuButton.Clicked.WithValue(msg)),
                    ValueSome [| ContentControl.ContentWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

type MvuDropDownButtonModifiers =
    /// <summary>Link a ViewRef to access the direct DropDownButton control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<unit, IFabMvuDropDownButton>, value: ViewRef<DropDownButton>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
