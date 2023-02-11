namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabExperimentalAcrylicBorder =
    inherit IFabDecorator

module ExperimentalAcrylicBorder =
    let WidgetKey = Widgets.register<ExperimentalAcrylicBorder>()

    let CornerRadius =
        Attributes.defineAvaloniaPropertyWithEquality ExperimentalAcrylicBorder.CornerRadiusProperty

    let Material =
        Attributes.defineAvaloniaPropertyWidget ExperimentalAcrylicBorder.MaterialProperty


[<AutoOpen>]
module ExperimentalAcrylicBorderBuilders =
    type Fabulous.Avalonia.View with

        static member ExperimentalAcrylicBorder(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabExperimentalAcrylicBorder>(
                ExperimentalAcrylicBorder.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| Decorator.Child.WithValue(content.Compile()) |], ValueNone)
            )

[<Extension>]
type ExperimentalAcrylicBorderModifiers =
    [<Extension>]
    static member inline cornerRadius(this: WidgetBuilder<'msg, #IFabExperimentalAcrylicBorder>, value: CornerRadius) =
        this.AddScalar(ExperimentalAcrylicBorder.CornerRadius.WithValue(value))

    [<Extension>]
    static member inline material(this: WidgetBuilder<'msg, #IFabExperimentalAcrylicBorder>, content: WidgetBuilder<'msg, IFabExperimentalAcrylicMaterial>) =
        this.AddWidget(ExperimentalAcrylicBorder.Material.WithValue(content.Compile()))
