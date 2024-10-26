namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuExperimentalAcrylicMaterial =
    inherit IFabMvuElement
    inherit IFabExperimentalAcrylicMaterial

module MvuExperimentalAcrylicMaterial =
    let Invalidated =
        Attributes.defineEventNoArg "ExperimentalAcrylicMaterial_Invalidated" (fun target -> (target :?> ExperimentalAcrylicMaterial).Invalidated)

[<AutoOpen>]
module MvuExperimentalAcrylicMaterialBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a ExperimentalAcrylicMaterial widget.</summary>
        static member ExperimentalAcrylicMaterial() =
            WidgetBuilder<unit, IFabExperimentalAcrylicMaterial>(
                ExperimentalAcrylicMaterial.WidgetKey,
                AttributesBundle(StackList.empty(), ValueNone, ValueNone)
            )

type MvuExperimentalAcrylicMaterialModifiers =
    /// <summary>Listens the ExperimentalAcrylicMaterial Invalidated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the ExperimentalAcrylicMaterial is invalidated.</param>
    [<Extension>]
    static member inline onInvalidated(this: WidgetBuilder<unit, #IFabMvuExperimentalAcrylicMaterial>, fn: 'msg) =
        this.AddScalar(MvuExperimentalAcrylicMaterial.Invalidated.WithValue(MsgValue fn))
