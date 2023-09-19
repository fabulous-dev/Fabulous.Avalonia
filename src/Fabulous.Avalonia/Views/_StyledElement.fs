namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Collections
open Avalonia.Input.TextInput
open Avalonia.LogicalTree
open Avalonia.Styling
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabStyledElement =
    inherit IFabAnimatable

module StyledElement =

    let Name = Attributes.defineAvaloniaPropertyWithEquality StyledElement.NameProperty

    let Styles =
        Attributes.defineAvaloniaListWidgetCollection "StyledElement_Styles" (fun target -> (target :?> StyledElement).Styles)

    let Classes =
        Attributes.defineSimpleScalarWithEquality<string list> "StyledElement_Classes" (fun _ newValueOpt node ->
            let target = node.Target :?> StyledElement

            match newValueOpt with
            | ValueNone -> target.Classes.Clear()
            | ValueSome classes ->
                let coll = AvaloniaList<string>()
                classes |> List.iter coll.Add
                target.Classes.AddRange coll)

    let ContentType =
        Attributes.defineAvaloniaPropertyWithEquality<TextInputContentType> TextInputOptions.ContentTypeProperty

    let ReturnKeyType =
        Attributes.defineAvaloniaPropertyWithEquality<TextInputReturnKeyType> TextInputOptions.ReturnKeyTypeProperty

    let Multiline =
        Attributes.defineAvaloniaPropertyWithEquality TextInputOptions.MultilineProperty

    let Lowercase =
        Attributes.defineAvaloniaPropertyWithEquality TextInputOptions.LowercaseProperty

    let Uppercase =
        Attributes.defineAvaloniaPropertyWithEquality TextInputOptions.UppercaseProperty

    let AutoCapitalization =
        Attributes.defineAvaloniaPropertyWithEquality TextInputOptions.AutoCapitalizationProperty

    let IsSensitive =
        Attributes.defineAvaloniaPropertyWithEquality TextInputOptions.IsSensitiveProperty

    let AttachedToLogicalTree =
        Attributes.defineEvent<LogicalTreeAttachmentEventArgs> "StyledElement_AttachedToLogicalTree" (fun target ->
            (target :?> StyledElement).AttachedToLogicalTree)

    let DetachedFromLogicalTree =
        Attributes.defineEvent<LogicalTreeAttachmentEventArgs> "StyledElement_DetachedFromLogicalTree" (fun target ->
            (target :?> StyledElement).DetachedFromLogicalTree)

    let ActualThemeVariantChanged =
        Attributes.defineEventNoArg "StyledElement_ActualThemeVariantChanged" (fun target -> (target :?> StyledElement).ActualThemeVariantChanged)

    let ThemeKey =
        Attributes.defineSimpleScalarWithEquality<string> "StyledElement_ThemeKey" (fun _ newValueOpt node ->
            let target = node.Target :?> StyledElement

            match newValueOpt with
            | ValueNone -> target.Theme <- null
            | ValueSome themeKey ->
                match Application.Current.Styles.TryGetResource(themeKey, null) with
                | true, value ->
                    match value with
                    | :? ControlTheme as controlTheme -> target.Theme <- controlTheme
                    | _ ->
                        node.TreeContext.Logger.Warn("The resource '{0}' is not a ControlTheme. The theme has been unset.", themeKey)
                        target.Theme <- null
                | _ ->
                    node.TreeContext.Logger.Warn("The resource '{0}' was not found. The theme has been unset", themeKey)
                    target.Theme <- null)

[<Extension>]
type StyledElementModifiers =
    /// <summary>Sets the Name property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Name value.</param>
    [<Extension>]
    static member inline name(this: WidgetBuilder<'msg, #IFabStyledElement>, value: string) =
        this.AddScalar(StyledElement.Name.WithValue(value))

    /// <summary>Sets the Classes property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Classes value.</param>
    [<Extension>]
    static member inline classes(this: WidgetBuilder<'msg, #IFabStyledElement>, value: string list) =
        this.AddScalar(StyledElement.Classes.WithValue(value))

    /// <summary>Sets the Classes property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Classes value.</param>
    [<Extension>]
    static member inline classes(this: WidgetBuilder<'msg, #IFabStyledElement>, value: string) =
        this.AddScalar(StyledElement.Classes.WithValue([ value ]))

    /// <summary>Sets the Style property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">The Style value.</param>
    [<Extension>]
    static member inline style(this: WidgetBuilder<'msg, #IFabElement>, fn: WidgetBuilder<'msg, #IFabElement> -> WidgetBuilder<'msg, #IFabElement>) = fn this

    /// <summary>Sets the ContentType property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ContentType value.</param>
    [<Extension>]
    static member inline contentType(this: WidgetBuilder<'msg, #IFabStyledElement>, value: TextInputContentType) =
        this.AddScalar(StyledElement.ContentType.WithValue(value))


    /// <summary>Sets the ReturnKeyType property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ReturnKeyType value.</param>
    [<Extension>]
    static member inline returnKeyType(this: WidgetBuilder<'msg, #IFabStyledElement>, value: TextInputReturnKeyType) =
        this.AddScalar(StyledElement.ReturnKeyType.WithValue(value))

    /// <summary>Sets the Multiline property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Multiline value.</param>
    [<Extension>]
    static member inline multiline(this: WidgetBuilder<'msg, #IFabStyledElement>, value: bool) =
        this.AddScalar(StyledElement.Multiline.WithValue(value))

    /// <summary>Sets the Lowercase property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Lowercase value.</param>
    [<Extension>]
    static member inline lowercase(this: WidgetBuilder<'msg, #IFabStyledElement>, value: bool) =
        this.AddScalar(StyledElement.Lowercase.WithValue(value))

    /// <summary>Sets the Uppercase property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Uppercase value.</param>
    [<Extension>]
    static member inline uppercase(this: WidgetBuilder<'msg, #IFabStyledElement>, value: bool) =
        this.AddScalar(StyledElement.Uppercase.WithValue(value))

    /// <summary>Sets the AutoCapitalization property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AutoCapitalization value.</param>
    [<Extension>]
    static member inline autoCapitalization(this: WidgetBuilder<'msg, #IFabStyledElement>, value: bool) =
        this.AddScalar(StyledElement.AutoCapitalization.WithValue(value))

    /// <summary>Sets the IsSensitive property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsSensitive value.</param>
    [<Extension>]
    static member inline isSensitive(this: WidgetBuilder<'msg, #IFabStyledElement>, value: bool) =
        this.AddScalar(StyledElement.IsSensitive.WithValue(value))

    /// <summary>Listens to the StyledElement AttachedToLogicalTree event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the styled element is attached to a rooted logical tree.</param>
    [<Extension>]
    static member inline onAttachedToLogicalTree(this: WidgetBuilder<'msg, #IFabStyledElement>, fn: LogicalTreeAttachmentEventArgs -> 'msg) =
        this.AddScalar(StyledElement.AttachedToLogicalTree.WithValue(fn))

    /// <summary>Listens to the StyledElement DetachedFromLogicalTree event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the styled element is detached from a rooted logical tree.</param>
    [<Extension>]
    static member inline onDetachedFromLogicalTree(this: WidgetBuilder<'msg, #IFabStyledElement>, fn: LogicalTreeAttachmentEventArgs -> 'msg) =
        this.AddScalar(StyledElement.DetachedFromLogicalTree.WithValue(fn))

    /// <summary>Listens to the StyledElement ActualThemeVariantChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the actual theme variant changes.</param>
    [<Extension>]
    static member inline onActualThemeVariantChanged(this: WidgetBuilder<'msg, #IFabStyledElement>, msg: 'msg) =
        this.AddScalar(StyledElement.ActualThemeVariantChanged.WithValue(MsgValue msg))

    /// <summary>Sets the ThemeKey property. The ThemeKey is used to lookup the ControlTheme from the
    /// application styles that is applied to the control.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ThemeKey value.</param>
    [<Extension>]
    static member inline themeKey(this: WidgetBuilder<'msg, #IFabStyledElement>, value: string) =
        this.AddScalar(StyledElement.ThemeKey.WithValue(value))

[<Extension>]
type StyledElementCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield(_: AttributeCollectionBuilder<'msg, #IFabStyledElement, IFabStyle>, x: WidgetBuilder<'msg, #IFabStyle>) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield
        (
            _: AttributeCollectionBuilder<'msg, #IFabStyledElement, IFabStyle>,
            x: WidgetBuilder<'msg, Memo.Memoized<#IFabStyle>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
