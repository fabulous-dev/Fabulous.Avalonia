namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia

type IFabMvuTemplatedControl =
    inherit IFabMvuControl
    inherit IFabTemplatedControl

module MvuTemplatedControl =
    let TemplateApplied =
        MvuAttributes.defineEvent "TemplatedControl_TemplateApplied" (fun target -> (target :?> TemplatedControl).TemplateApplied)

type MvuTemplatedControlModifiers =
    /// <summary>Listens to the TemplateApplied event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the template is applied.</param>
    [<Extension>]
    static member inline onTemplateApplied(this: WidgetBuilder<unit, #IFabMvuTemplatedControl>, fn: TemplateAppliedEventArgs -> unit) =
        this.AddScalar(MvuTemplatedControl.TemplateApplied.WithValue(fn))
