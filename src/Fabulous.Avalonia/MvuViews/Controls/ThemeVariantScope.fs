namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Styling
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuThemeVariantScope =
    inherit IFabMvuDecorator
    inherit IFabThemeVariantScope

module MvuThemeVariantScope =
    let ActualThemeVariantChanged =
        Attributes.defineEventNoArg "TopLevel_ThemeVariantChanged" (fun target -> (target :?> ThemeVariantScope).ActualThemeVariantChanged)

[<AutoOpen>]
module MvuThemeVariantScopeBuilders =
    type Fabulous.Avalonia.Mvu.View with

        /// <summary>Creates a ThemeVariantScope widget.</summary>
        /// <param name="theme">The theme variant to use.</param>
        /// <param name="content">The content of the ThemeVariantScope.</param>
        static member ThemeVariantScope(theme: ThemeVariant, content: WidgetBuilder<unit, #IFabControl>) =
            WidgetBuilder<unit, IFabMvuThemeVariantScope>(
                ThemeVariantScope.WidgetKey,
                AttributesBundle(
                    StackList.one(ThemeVariantScope.RequestedThemeVariant.WithValue(theme)),
                    ValueSome [| Decorator.ChildWidget.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

type MvuThemeVariantScopeModifiers =

    /// <summary>Listens the ThemeVariantScope ThemeVariantChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the ThemeVariantChanged event is raised.</param>
    [<Extension>]
    static member inline onActualThemeVariantChanged(this: WidgetBuilder<unit, #IFabMvuThemeVariantScope>, fn: 'msg) =
        this.AddScalar(MvuThemeVariantScope.ActualThemeVariantChanged.WithValue(MsgValue fn))
