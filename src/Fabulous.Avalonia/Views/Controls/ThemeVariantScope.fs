namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Styling
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabThemeVariantScope =
    inherit IFabDecorator

module ThemeVariantScope =
    let WidgetKey = Widgets.register<ThemeVariantScope>()

    let ThemeVariant =
        Attributes.defineAvaloniaPropertyWithEquality ThemeVariantScope.RequestedThemeVariantProperty

    let ThemeVariantChanged =
        Attributes.defineEventNoArg "TopLevel_ThemeVariantChanged" (fun target -> (target :?> ThemeVariantScope).ActualThemeVariantChanged)

[<AutoOpen>]
module ThemeVariantScopeBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>
        /// Gets or sets the UI theme variant that is used by the control (and its child elements) for resource determination.
        /// The UI theme you specify with ThemeVariant can override the app-level ThemeVariant.
        /// <remarks>
        /// Setting ThemeVariant to ThemeVariant.Default will apply parent's actual theme variant on the current scope.
        /// </remarks>
        /// <example>
        /// <code lang="fsharp">
        /// ThemeVariantScope(
        ///     ThemeVariant.Light,
        ///     TextBlock("Hello World")
        /// )
        /// </code>
        /// </example>
        /// </summary>
        static member ThemeVariantScope(themeVariant: ThemeVariant, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabThemeVariantScope>(
                ThemeVariantScope.WidgetKey,
                AttributesBundle(
                    StackList.one(ThemeVariantScope.ThemeVariant.WithValue(themeVariant)),
                    ValueSome [| Decorator.Child.WithValue(content.Compile()) |],
                    ValueNone
                )
            )

[<Extension>]
type ThemeVariantScopeModifiers =

    /// <summary>Listen for the ActualThemeVariantChanged changes</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Message to dispatch</param>
    [<Extension>]
    static member inline onThemeVariantChanged(this: WidgetBuilder<'msg, #IFabThemeVariantScope>, fn: ThemeVariant -> 'msg) =
        this.AddScalar(ThemeVariantScope.ThemeVariantChanged.WithValue(fn Application.Current.ActualThemeVariant))

    /// <summary>Link a ViewRef to access the direct ThemeVariantScope control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabThemeVariantScope>, value: ViewRef<ThemeVariantScope>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
