namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.Markup.Xaml.Styling
open Avalonia.Styling
open Avalonia.Themes.Fluent
open Fabulous
open Fabulous.Avalonia
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
        | :? IClassicDesktopStyleApplicationLifetime as desktopLifetime -> desktopLifetime.MainWindow <- _mainWindow
        | :? ISingleViewApplicationLifetime as singleViewLifetime -> singleViewLifetime.MainView <- _mainView
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

    override this.OnFrameworkInitializationCompleted() =
        this.UpdateLifetime()
        base.OnFrameworkInitializationCompleted()

type FabApplication<'arg, 'model, 'msg, 'marker when 'marker :> IFabApplication>(program: Program<'arg, 'model, 'msg, 'marker>, arg: 'arg) =
    inherit FabApplication()

    override this.Initialize() =
        this.Styles.Add(FluentTheme())
        base.Initialize()

    override this.OnFrameworkInitializationCompleted() =
        let runner = Runners.create program
        runner.Start(arg)

        let adapter = ViewAdapters.create ViewNode.get runner
        adapter.Attach(this)

        base.OnFrameworkInitializationCompleted()

module ApplicationUpdaters =
    let mainWindowApplyDiff (diff: WidgetDiff) (node: IViewNode) =
        let target = node.Target :?> FabApplication
        let childViewNode = node.TreeContext.GetViewNode(target.MainWindow)
        childViewNode.ApplyDiff(&diff)

    let mainWindowUpdateNode (_: Widget voption) (currOpt: Widget voption) (node: IViewNode) =
        let target = node.Target :?> FabApplication

        match currOpt with
        | ValueNone -> target.MainWindow <- Unchecked.defaultof<_>
        | ValueSome widget ->
            let struct (_, view) = Helpers.createViewForWidget node widget
            target.MainWindow <- view :?> Window

    let mainViewApplyDiff (diff: WidgetDiff) (node: IViewNode) =
        let target = node.Target :?> FabApplication
        let childViewNode = node.TreeContext.GetViewNode(target.MainView)
        childViewNode.ApplyDiff(&diff)

    let mainViewUpdateNode (_: Widget voption) (currOpt: Widget voption) (node: IViewNode) =
        let target = node.Target :?> FabApplication

        match currOpt with
        | ValueNone -> target.MainView <- Unchecked.defaultof<_>
        | ValueSome widget ->
            let struct (_, view) = Helpers.createViewForWidget node widget
            target.MainView <- view :?> Control

module Application =
    let WidgetKey = Widgets.register<FabApplication>()

    let MainWindow =
        Attributes.defineWidget "MainWindow" ApplicationUpdaters.mainWindowApplyDiff ApplicationUpdaters.mainWindowUpdateNode

    let MainView =
        Attributes.defineWidget "MainView" ApplicationUpdaters.mainViewApplyDiff ApplicationUpdaters.mainViewUpdateNode

    let Styles =
        Attributes.defineProperty "Styles" Unchecked.defaultof<string> (fun target value ->
            let styles = (target :?> FabApplication).Styles
            let style = StyleInclude(baseUri = null)
            style.Source <- Uri(value)
            styles.Add(style))

    let Name = Attributes.defineAvaloniaPropertyWithEquality Application.NameProperty

    let ActualThemeVariant =
        Attributes.defineAvaloniaPropertyWithEquality Application.ActualThemeVariantProperty

    let RequestedThemeVariant =
        Attributes.defineAvaloniaPropertyWithEquality Application.RequestedThemeVariantProperty

    let ResourcesChanged =
        Attributes.defineEvent "Application_ResourcesChangedEvent" (fun target -> (target :?> Application).ResourcesChanged)

    let UrlsOpened =
        Attributes.defineEvent "Application_UrlsOpenedEvent" (fun target -> (target :?> Application).UrlsOpened)

    let ActualThemeVariantChanged =
        Attributes.defineAvaloniaPropertyWithChangedEvent' "Application_ActualThemeVariantChangedEvent" Application.ActualThemeVariantProperty

    let RequestedThemeVariantChanged =
        Attributes.defineAvaloniaPropertyWithChangedEvent' "Application_RequestedThemeVariantChangedEvent" Application.RequestedThemeVariantProperty

[<AutoOpen>]
module ApplicationBuilders =
    type Fabulous.Avalonia.View with

        static member DesktopApplication(mainWindow: WidgetBuilder<'msg, #IFabWindow>) =
            WidgetBuilder<'msg, IFabApplication>(
                Application.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| Application.MainWindow.WithValue(mainWindow.Compile()) |], ValueNone)
            )

        static member SingleViewApplication(mainView: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabApplication>(
                Application.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| Application.MainView.WithValue(mainView.Compile()) |], ValueNone)
            )

[<Extension>]
type ApplicationModifiers =
    [<Extension>]
    static member inline styles(this: WidgetBuilder<'msg, #IFabApplication>, url: string) =
        this.AddScalar(Application.Styles.WithValue(url))

    [<Extension>]
    static member inline name(this: WidgetBuilder<'msg, #IFabApplication>, value: string) =
        this.AddScalar(Application.Name.WithValue(value))

    [<Extension>]
    static member inline actualThemeVariant(this: WidgetBuilder<'msg, #IFabApplication>, value: ThemeVariant) =
        this.AddScalar(Application.ActualThemeVariant.WithValue(value))

    [<Extension>]
    static member inline requestedThemeVariant(this: WidgetBuilder<'msg, #IFabApplication>, value: ThemeVariant) =
        this.AddScalar(Application.RequestedThemeVariant.WithValue(value))

    [<Extension>]
    static member inline onResourcesChanged(this: WidgetBuilder<'msg, #IFabApplication>, onResourcesChanged: ResourcesChangedEventArgs -> 'msg) =
        this.AddScalar(Application.ResourcesChanged.WithValue(fun target -> onResourcesChanged target |> box))

    [<Extension>]
    static member inline onUrlsOpened(this: WidgetBuilder<'msg, #IFabApplication>, onUrlsOpened: UrlOpenedEventArgs -> 'msg) =
        this.AddScalar(Application.UrlsOpened.WithValue(fun target -> onUrlsOpened target |> box))

    [<Extension>]
    static member inline onActualThemeVariantChanged(this: WidgetBuilder<'msg, #IFabApplication>, theme: ThemeVariant, onThemeChanged: ThemeVariant -> 'msg) =
        this.AddScalar(Application.ActualThemeVariantChanged.WithValue(ValueEventData.create theme (fun args -> onThemeChanged args |> box)))

    [<Extension>]
    static member inline onRequestedThemeVariantChanged
        (
            this: WidgetBuilder<'msg, #IFabApplication>,
            theme: ThemeVariant,
            onThemeChanged: ThemeVariant -> 'msg
        ) =
        this.AddScalar(Application.RequestedThemeVariantChanged.WithValue(ValueEventData.create theme (fun args -> onThemeChanged args |> box)))

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
