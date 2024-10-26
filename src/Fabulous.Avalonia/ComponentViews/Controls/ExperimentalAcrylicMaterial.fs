namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentExperimentalAcrylicMaterial =
    inherit IFabComponentElement
    inherit IFabExperimentalAcrylicMaterial

module ComponentExperimentalAcrylicMaterial =
    let Invalidated =
        Attributes.defineEventNoArgNoDispatch "ExperimentalAcrylicMaterial_Invalidated" (fun target -> (target :?> ExperimentalAcrylicMaterial).Invalidated)

[<AutoOpen>]
module ComponentExperimentalAcrylicMaterialBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a ExperimentalAcrylicMaterial widget.</summary>
        static member ExperimentalAcrylicMaterial() =
            WidgetBuilder<unit, IFabExperimentalAcrylicMaterial>(
                ExperimentalAcrylicMaterial.WidgetKey,
                AttributesBundle(StackList.empty(), ValueNone, ValueNone)
            )

type ComponentExperimentalAcrylicMaterialModifiers =
    /// <summary>Listens the ExperimentalAcrylicMaterial Invalidated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the ExperimentalAcrylicMaterial is invalidated.</param>
    [<Extension>]
    static member inline onInvalidated(this: WidgetBuilder<unit, #IFabComponentExperimentalAcrylicMaterial>, fn: unit -> unit) =
        this.AddScalar(ComponentExperimentalAcrylicMaterial.Invalidated.WithValue(fn))
