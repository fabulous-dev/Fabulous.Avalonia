namespace Fabulous.Avalonia

open Avalonia.Controls
open Avalonia.Styling
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabThemeVariantScope =
    inherit IFabDecorator

module ThemeVariantScope =
    let WidgetKey = Widgets.register<ThemeVariantScope>()

    let ThemeVariant =
        Attributes.definePropertyWithGetSet
            "ThemeVariantScope_ThemeVariant"
            (fun target -> (target :?> ThemeVariantScope).RequestedThemeVariant)
            (fun target value -> (target :?> ThemeVariantScope).RequestedThemeVariant <- value)

[<AutoOpen>]
module ThemeVariantScopeBuilders =
    type Fabulous.Avalonia.View with

        static member ThemeVariantScope(themeVariant: ThemeVariant, content: WidgetBuilder<'msg, #IFabControl>) =
            WidgetBuilder<'msg, IFabThemeVariantScope>(
                ThemeVariantScope.WidgetKey,
                AttributesBundle(
                    StackList.one(ThemeVariantScope.ThemeVariant.WithValue(themeVariant)),
                    ValueSome [| Decorator.Child.WithValue(content.Compile()) |],
                    ValueNone
                )
            )
