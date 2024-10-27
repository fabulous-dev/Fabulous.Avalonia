namespace Fabulous.Avalonia.Mvu

open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuExperimentalAcrylicBorder =
    inherit IFabMvuDecorator
    inherit IFabExperimentalAcrylicBorder

[<AutoOpen>]
module MvuExperimentalAcrylicBorderBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a ExperimentalAcrylicBorder widget.</summary>
        /// <param name="content">The content of the ExperimentalAcrylicBorder.</param>
        static member ExperimentalAcrylicBorder(content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabMvuExperimentalAcrylicBorder>(
                ExperimentalAcrylicBorder.WidgetKey,
                AttributesBundle(StackList.empty(), ValueSome [| Decorator.ChildWidget.WithValue(content.Compile()) |], ValueNone)
            )

        /// <summary>Creates a ExperimentalAcrylicBorder widget.</summary>
        static member ExperimentalAcrylicBorder() =
            WidgetBuilder<'msg, IFabMvuExperimentalAcrylicBorder>(
                ExperimentalAcrylicBorder.WidgetKey,
                AttributesBundle(StackList.empty(), ValueNone, ValueNone)
            )
