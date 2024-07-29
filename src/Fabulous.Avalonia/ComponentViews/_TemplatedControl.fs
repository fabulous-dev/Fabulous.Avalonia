namespace Fabulous.Avalonia.Components

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia

type IFabComponentTemplatedControl =
    inherit IFabComponentControl
    inherit IFabTemplatedControl

module ComponentTemplatedControl =
    let TemplateApplied =
        ComponentAttributes.defineEvent "TemplatedControl_TemplateApplied" (fun target -> (target :?> TemplatedControl).TemplateApplied)

type ComponentTemplatedControlModifiers =
    /// <summary>Listens to the TemplateApplied event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the template is applied.</param>
    [<Extension>]
    static member inline onTemplateApplied(this: WidgetBuilder<unit, #IFabComponentTemplatedControl>, fn: TemplateAppliedEventArgs -> unit) =
        this.AddScalar(ComponentTemplatedControl.TemplateApplied.WithValue(fn))
