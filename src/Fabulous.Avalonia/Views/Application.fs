namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.Themes.Fluent
open Fabulous
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList

type IFabApplication =
    inherit IFabElement
    
type FabApplication() =
    inherit Application()
    
    let mutable _mainWindow: Window = null
    let mutable _mainView: Control = null
    
    member private this.UpdateLifetime() =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime as desktopLifetime ->
            desktopLifetime.MainWindow <- _mainWindow
        | :? ISingleViewApplicationLifetime as singleViewLifetime ->
            singleViewLifetime.MainView <- _mainView
        | _ -> ()
    
    member this.MainWindow
        with get () = _mainWindow
        and set value =
            _mainWindow <- value
            this.UpdateLifetime()
            
    member this.MainView
        with get () = _mainView
        and set value =
            _mainView <- value
            this.UpdateLifetime()
            
    // TODO Set the App to Light theme for now. So we can test more controls
    override this.Initialize() =
        this.Styles.Add (FluentTheme(baseUri = null, Mode = FluentThemeMode.Light))
        
    override this.OnFrameworkInitializationCompleted() =
        this.UpdateLifetime()
        base.OnFrameworkInitializationCompleted()
    
module ApplicationUpdaters =
    let mainWindowApplyDiff (diff: WidgetDiff) (node: IViewNode) =
        let target = node.Target :?> FabApplication
        let childViewNode = node.TreeContext.GetViewNode(target.MainWindow)
        childViewNode.ApplyDiff(&diff)
    
    let mainWindowUpdateNode (prevOpt: Widget voption) (currOpt: Widget voption) (node: IViewNode) =
        let target = node.Target :?> FabApplication
        match currOpt with
        | ValueNone ->
            target.MainWindow <- Unchecked.defaultof<_>
        | ValueSome widget ->
            let struct (_, view) = Helpers.createViewForWidget node widget
            target.MainWindow <- view :?> Window
            
    let mainViewApplyDiff (diff: WidgetDiff) (node: IViewNode) =
        let target = node.Target :?> FabApplication
        let childViewNode = node.TreeContext.GetViewNode(target.MainView)
        childViewNode.ApplyDiff(&diff)
            
    let mainViewUpdateNode (prevOpt: Widget voption) (currOpt: Widget voption) (node: IViewNode) =
        let target = node.Target :?> FabApplication
        match currOpt with
        | ValueNone ->
            target.MainView <- Unchecked.defaultof<_>
        | ValueSome widget ->
            let struct (_, view) = Helpers.createViewForWidget node widget
            target.MainView <- view :?> Control

module Application =
    let WidgetKey = Widgets.register<FabApplication>()
    
    let MainWindow = Attributes.defineWidget "MainWindow" ApplicationUpdaters.mainWindowApplyDiff ApplicationUpdaters.mainWindowUpdateNode
    let MainView = Attributes.defineWidget "MainView" ApplicationUpdaters.mainViewApplyDiff ApplicationUpdaters.mainViewUpdateNode
    let Styles = Attributes.defineAvaloniaListWidgetCollection "Styles" (fun target -> (target :?> Application).Styles)
    
[<AutoOpen>]
module ApplicationBuilders =
    type Fabulous.Avalonia.View with
        static member DesktopApplication(mainWindow: WidgetBuilder<'msg, #IFabWindow>) =
            WidgetBuilder<'msg, IFabApplication>(
                Application.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome [|
                        Application.MainWindow.WithValue(mainWindow.Compile())
                    |],
                    ValueNone
                )
            )
            
        static member SingleViewApplication(mainView: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabApplication>(
                Application.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome [|
                        Application.MainView.WithValue(mainView.Compile())
                    |],
                    ValueNone
                )
            )
            
[<Extension>]
type ApplicationModifiers =
    [<Extension>]
    static member inline styles(this: WidgetBuilder<'msg, #IFabApplication>) =
        AttributeCollectionBuilder<'msg, #IFabApplication, IFabStyle>(this, Application.Styles)
        
[<Extension>]
type ApplicationCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'marker :> IFabApplication and 'itemType :> IFabStyle>
        (
            _: AttributeCollectionBuilder<'msg, 'marker, IFabStyle>,
            x: WidgetBuilder<'msg, 'itemType>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
        
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'marker :> IFabApplication and 'itemType :> IFabStyle>
        (
            _: AttributeCollectionBuilder<'msg, 'marker, IFabStyle>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
