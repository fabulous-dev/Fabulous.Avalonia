namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module MvuComboBox =
    let DropDownOpened =
        Attributes.defineAvaloniaPropertyWithChangedEvent' "Opened" ComboBox.IsDropDownOpenProperty


[<AutoOpen>]
module MvuComboBoxBuilders =
    type Fabulous.Avalonia.View with
        /// <summary>Creates a ComboBox widget.</summary>
        static member ComboBox() =
            CollectionBuilder<'msg, IFabComboBox, IFabComboBoxItem>(ComboBox.WidgetKey, MvuItemsControl.Items)

type MvuComboBoxModifiers =
    /// <summary>Listens to the ComboBox DropDownOpened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="isOpen">Weather the drop down is open or not.</param>
    /// <param name="fn">Raised when the DropDownOpened event fires.</param>
    [<Extension>]
    static member inline onDropDownOpened(this: WidgetBuilder<'msg, #IFabComboBox>, isOpen: bool, fn: bool -> 'msg) =
        this.AddScalar(MvuComboBox.DropDownOpened.WithValue(MvuValueEventData.create isOpen fn))
