namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

module MvuTemplatedControl =
    let TemplateApplied =
        Attributes.defineEvent "TemplatedControl_TemplateApplied" (fun target -> (target :?> TemplatedControl).TemplateApplied)

type MvuTemplatedControlModifiers =
    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: Color) =
        TemplatedControlModifiers.background(this, View.SolidColorBrush(value))

    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: string) =
        TemplatedControlModifiers.background(this, View.SolidColorBrush(value))

    /// <summary>Sets the BorderBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BorderBrush value.</param>
    [<Extension>]
    static member inline borderBrush(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: Color) =
        TemplatedControlModifiers.borderBrush(this, View.SolidColorBrush(value))

    /// <summary>Sets the BorderBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BorderBrush value.</param>
    [<Extension>]
    static member inline borderBrush(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: string) =
        TemplatedControlModifiers.borderBrush(this, View.SolidColorBrush(value))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: Color) =
        TemplatedControlModifiers.foreground(this, View.SolidColorBrush(value))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: string) =
        TemplatedControlModifiers.foreground(this, View.SolidColorBrush(value))

    /// <summary>Listens to the TemplateApplied event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the template is applied.</param>
    [<Extension>]
    static member inline onTemplateApplied(this: WidgetBuilder<'msg, #IFabTemplatedControl>, fn: TemplateAppliedEventArgs -> 'msg) =
        this.AddScalar(MvuTemplatedControl.TemplateApplied.WithValue(fn))
