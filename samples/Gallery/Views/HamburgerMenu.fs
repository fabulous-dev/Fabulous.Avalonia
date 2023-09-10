namespace Gallery.Pages

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Markup.Xaml
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections

type HamburgerMenu() as self =
    inherit UserControl()
                
    do self.InitializeComponent()

    member private this.InitializeComponent() =
        AvaloniaXamlLoader.Load(this)
    
    static member PaneBackgroundProperty =
        SplitView.PaneBackgroundProperty.AddOwner<HamburgerMenu>()
        
    member this.PaneBackground
        with get () = this.GetValue(HamburgerMenu.PaneBackgroundProperty)
        and set value = this.SetValue(HamburgerMenu.PaneBackgroundProperty, value) |> ignore
        
    static member ContentBackgroundProperty =
        AvaloniaProperty.Register<HamburgerMenu, IBrush>("ContentBackground")
        
    member this.ContentBackground
        with get () = this.GetValue(HamburgerMenu.ContentBackgroundProperty)
        and set value = this.SetValue(HamburgerMenu.ContentBackgroundProperty, value) |> ignore
        
    static member ExpandedModeThresholdWidthProperty =
        AvaloniaProperty.Register<HamburgerMenu, int>("ExpandedModeThresholdWidth", 1008)
        
    member this.ExpandedModeThresholdWidth
        with get () = this.GetValue(HamburgerMenu.ExpandedModeThresholdWidthProperty)
        and set value = this.SetValue(HamburgerMenu.ExpandedModeThresholdWidthProperty, value) |> ignore
        
    member this.TabControl with get () = this.FindControl<TabControl>("PART_TabControl")
    
                
type IFabHamburgerMenu =
    inherit IFabUserControl
    
module HamburgerMenu =
    let WidgetKey = Widgets.register<HamburgerMenu>()
    
    let PaneBackground =
        Attributes.defineAvaloniaPropertyWithEquality HamburgerMenu.PaneBackgroundProperty
    
    let ContentBackground =
        Attributes.defineAvaloniaPropertyWithEquality HamburgerMenu.ContentBackgroundProperty    
    
    let ExpandedModeThresholdWidth =
        Attributes.defineAvaloniaPropertyWithEquality HamburgerMenu.ExpandedModeThresholdWidthProperty
        
    let Items =
        Attributes.defineAvaloniaNonGenericListWidgetCollection "HamburgerMenu_Items" (fun target ->
            let target = target :?> HamburgerMenu

            if target.TabControl.Items = null then
                let newColl = ItemCollection.Empty
                target.TabControl.Items.Add newColl |> ignore
                newColl
            else
                target.TabControl.Items)
        
    let SelectionChanged =
        Attributes.defineEvent<SelectionChangedEventArgs> "HamburgerMenu_SelectionChanged" (fun target ->
            (target :?> HamburgerMenu).TabControl.SelectionChanged)
        
[<AutoOpen>]
module HamburgerMenuBuilders =
    
    type Fabulous.Avalonia.View with
        static member inline HamburgerMenu() =
            CollectionBuilder<'msg, IFabHamburgerMenu, IFabTabItem>(
                HamburgerMenu.WidgetKey,
                HamburgerMenu.Items)
            
[<Extension>]
type HamburgerMenuModifiers =
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabHamburgerMenu>, value: ViewRef<HamburgerMenu>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
        
    [<Extension>]
    static member inline onSelectionChanged(this: WidgetBuilder<'msg, IFabHamburgerMenu>, fn: SelectionChangedEventArgs -> 'msg) =
        this.AddScalar(HamburgerMenu.SelectionChanged.WithValue(fn))