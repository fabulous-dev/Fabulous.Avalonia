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

    let Invalidated =
        Attributes.defineEventNoArg "ExperimentalAcrylicMaterial_Invalidated" (fun target -> (target :?> ExperimentalAcrylicMaterial).Invalidated)

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

    [<Extension>]
    static member inline onInvalidated(this: WidgetBuilder<'msg, #IFabExperimentalAcrylicMaterial>, onInvalidated: 'msg) =
        this.AddScalar(ExperimentalAcrylicMaterial.Invalidated.WithValue(fun _ -> onInvalidated |> box))

    /// <summary>Link a ViewRef to access the direct ExperimentalAcrylicMaterial control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabExperimentalAcrylicMaterial>, value: ViewRef<ExperimentalAcrylicMaterial>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
