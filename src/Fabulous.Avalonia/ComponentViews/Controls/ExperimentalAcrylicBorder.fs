namespace Fabulous.Avalonia.Components

open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentExperimentalAcrylicBorder =
    inherit IFabComponentDecorator
    inherit IFabExperimentalAcrylicBorder

[<AutoOpen>]
module ComponentExperimentalAcrylicBorderBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a ExperimentalAcrylicBorder widget.</summary>
        /// <param name="content">The content of the ExperimentalAcrylicBorder.</param>
        static member ExperimentalAcrylicBorder(content: WidgetBuilder<unit, #IFabControl>) =
            WidgetBuilder<unit, IFabComponentExperimentalAcrylicBorder>(
                ExperimentalAcrylicBorder.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| Decorator.ChildWidget.WithValue(content.Compile()) |], ValueNone)
            )

        /// <summary>Creates a ExperimentalAcrylicBorder widget.</summary>
        static member ExperimentalAcrylicBorder() =
            WidgetBuilder<unit, IFabComponentExperimentalAcrylicBorder>(
                ExperimentalAcrylicBorder.WidgetKey,
                AttributesBundle(StackList.empty(), ValueNone, ValueNone)
            )
