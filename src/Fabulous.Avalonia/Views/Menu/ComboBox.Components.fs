namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module ComponentComboBox =
    let DropDownOpened =
        Attributes.defineAvaloniaPropertyWithChangedEventNoDispatch' "Opened" ComboBox.IsDropDownOpenProperty


[<AutoOpen>]
module ComponentComboBoxBuilders =
    type Fabulous.Avalonia.View with
        /// <summary>Creates a ComboBox widget.</summary>
        static member ComboBox() =
            CollectionBuilder<'msg, IFabComboBox, IFabComboBoxItem>(ComboBox.WidgetKey, ComponentItemsControl.Items)

type ComponentComboBoxModifiers =
    /// <summary>Listens to the ComboBox DropDownOpened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="isOpen">Weather the drop down is open or not.</param>
    /// <param name="fn">Raised when the DropDownOpened event fires.</param>
    [<Extension>]
    static member inline onDropDownOpened(this: WidgetBuilder<'msg, #IFabComboBox>, isOpen: bool, fn: bool -> unit) =
        this.AddScalar(ComponentComboBox.DropDownOpened.WithValue(ComponentValueEventData.create isOpen fn))
