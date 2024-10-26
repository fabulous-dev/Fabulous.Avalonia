namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Styling
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabComponentThemeVariantScope =
    inherit IFabComponentDecorator
    inherit IFabThemeVariantScope

module ComponentThemeVariantScope =
    let ActualThemeVariantChanged =
        Attributes.defineEventNoArgNoDispatch "TopLevel_ThemeVariantChanged" (fun target -> (target :?> ThemeVariantScope).ActualThemeVariantChanged)

[<AutoOpen>]
module ComponentThemeVariantScopeBuilders =
    type Fabulous.Avalonia.Components.View with

        /// <summary>Creates a ThemeVariantScope widget.</summary>
        /// <param name="theme">The theme variant to use.</param>
        /// <param name="content">The content of the ThemeVariantScope.</param>
        static member ThemeVariantScope(theme: ThemeVariant, content: WidgetBuilder<unit, #IFabControl>) =
            WidgetBuilder<unit, IFabComponentThemeVariantScope>(
                ThemeVariantScope.WidgetKey,
                AttributesBundle(
                    StackList.one(ThemeVariantScope.RequestedThemeVariant.WithValue(theme)),
                    ValueSome [| Decorator.ChildWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

type ComponentThemeVariantScopeModifiers =

    /// <summary>Listens the ThemeVariantScope ThemeVariantChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the ThemeVariantChanged event is raised.</param>
    [<Extension>]
    static member inline onActualThemeVariantChanged(this: WidgetBuilder<unit, #IFabComponentThemeVariantScope>, fn: unit -> unit) =
        this.AddScalar(ComponentThemeVariantScope.ActualThemeVariantChanged.WithValue(fn))
