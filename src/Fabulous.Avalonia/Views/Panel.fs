namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabPanel = inherit IFabControl

module Panel =
    let Background = Attributes.defineStyledWidget Panel.BackgroundProperty
    let Children = Attributes.defineAvaloniaListWidgetCollection "Children" (fun x -> (x :?> Panel).Children)
    
[<Extension>]
type PanelModifiers =
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabPanel>, brush: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(Panel.Background.WithValue(brush.Compile()))
    
[<Extension>]
type PanelCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'marker :> IFabPanel and 'itemType :> IFabControl>
        (
            _: CollectionBuilder<'msg, 'marker, IFabControl>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
        
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'marker :> IFabPanel and 'itemType :> IFabControl>
        (
            _: CollectionBuilder<'msg, 'marker, IFabControl>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }