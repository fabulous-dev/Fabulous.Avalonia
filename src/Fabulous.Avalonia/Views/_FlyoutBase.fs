namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous

type IFabFlyoutBase =
    inherit IFabElement

module FlyoutBase =
    let AttachedFlyout =
        Attributes.defineAvaloniaPropertyWidget FlyoutBase.AttachedFlyoutProperty
