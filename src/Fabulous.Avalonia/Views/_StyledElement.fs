namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Animation
open Avalonia.Collections
open Avalonia.Styling
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabStyledElement =
    inherit IFabAnimatable

module StyledElement =

    let Name = Attributes.defineAvaloniaPropertyWithEquality StyledElement.NameProperty

    let Styles =
        Attributes.defineAvaloniaListWidgetCollection "StyledElement_Styles" (fun target -> (target :?> StyledElement).Styles)

[<Extension>]
type StyledElementModifiers =
    /// <summary>Set the Name property.</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value to set</param>
    [<Extension>]
    static member inline name(this: WidgetBuilder<'msg, #IFabStyledElement>, value: string) =
        this.AddScalar(StyledElement.Name.WithValue(value))

    /// <summary>Set the Styles property.</summary>
    /// <param name="this">Current widget</param>
    /// <example>
    /// <code lang="fsharp">
    /// Label("Hello World!")
    ///     .styles() {
    ///         Animations() {
    ///             ...
    ///         }
    ///     }
    /// </code>
    /// </example>
    [<Extension>]
    static member inline styles(this: WidgetBuilder<'msg, #IFabStyledElement>) =
        AttributeCollectionBuilder<'msg, #IFabStyledElement, IFabStyle>(this, StyledElement.Styles)

    /// <summary>Styles a widget.</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">A function that takes the current widget to and returns a new widget styled</param>
    /// <example>
    /// <code lang="fsharp">
    /// let borderStyle (this: WidgetBuilder&lt;'msg, IFabBorder&gt;) =
    ///     this
    ///         .child(Image(ImageSource.fromString "image,png", Stretch.UniformToFill))
    ///         .size(50.., 50..)
    ///
    /// Border()
    ///     .style(borderStyle)
    /// </code>
    /// </example>
    [<Extension>]
    static member inline style(this: WidgetBuilder<'msg, #IFabElement>, fn: WidgetBuilder<'msg, #IFabElement> -> WidgetBuilder<'msg, #IFabElement>) = fn this

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
