namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabExperimentalAcrylicMaterial =
    inherit IFabElement

module ExperimentalAcrylicMaterial =
    let WidgetKey = Widgets.register<ExperimentalAcrylicMaterial>()

    let TintColor =
        Attributes.defineAvaloniaPropertyWithEquality ExperimentalAcrylicMaterial.TintColorProperty

    let BackgroundSource =
        Attributes.defineAvaloniaPropertyWithEquality ExperimentalAcrylicMaterial.BackgroundSourceProperty

    let TintOpacity =
        Attributes.defineAvaloniaPropertyWithEquality ExperimentalAcrylicMaterial.TintOpacityProperty

    let MaterialOpacity =
        Attributes.defineAvaloniaPropertyWithEquality ExperimentalAcrylicMaterial.MaterialOpacityProperty


    let PlatformTransparencyCompensationLevel =
        Attributes.defineAvaloniaPropertyWithEquality ExperimentalAcrylicMaterial.PlatformTransparencyCompensationLevelProperty

    let FallbackColor =
        Attributes.defineAvaloniaPropertyWithEquality ExperimentalAcrylicMaterial.FallbackColorProperty


[<AutoOpen>]
module ExperimentalAcrylicMaterialBuilders =
    type Fabulous.Avalonia.View with

        static member ExperimentalAcrylicMaterial() =
            WidgetBuilder<'msg, IFabExperimentalAcrylicMaterial>(
                ExperimentalAcrylicMaterial.WidgetKey,
                AttributesBundle(StackList.empty(), ValueNone, ValueNone)
            )

[<Extension>]
type ExperimentalAcrylicMaterialModifiers =
    [<Extension>]
    static member inline tintColor(this: WidgetBuilder<'msg, #IFabExperimentalAcrylicMaterial>, value: Color) =
        this.AddScalar(ExperimentalAcrylicMaterial.TintColor.WithValue(value))

    [<Extension>]
    static member inline backgroundSource(this: WidgetBuilder<'msg, #IFabExperimentalAcrylicMaterial>, value: AcrylicBackgroundSource) =
        this.AddScalar(ExperimentalAcrylicMaterial.BackgroundSource.WithValue(value))

    [<Extension>]
    static member inline tintOpacity(this: WidgetBuilder<'msg, #IFabExperimentalAcrylicMaterial>, value: float) =
        this.AddScalar(ExperimentalAcrylicMaterial.TintOpacity.WithValue(value))

    [<Extension>]
    static member inline materialOpacity(this: WidgetBuilder<'msg, #IFabExperimentalAcrylicMaterial>, value: float) =
        this.AddScalar(ExperimentalAcrylicMaterial.MaterialOpacity.WithValue(value))

    [<Extension>]
    static member inline platformTransparencyCompensationLevel(this: WidgetBuilder<'msg, #IFabExperimentalAcrylicMaterial>, value: float) =
        this.AddScalar(ExperimentalAcrylicMaterial.PlatformTransparencyCompensationLevel.WithValue(value))

    [<Extension>]
    static member inline fallbackColor(this: WidgetBuilder<'msg, #IFabExperimentalAcrylicMaterial>, value: Color) =
        this.AddScalar(ExperimentalAcrylicMaterial.FallbackColor.WithValue(value))
