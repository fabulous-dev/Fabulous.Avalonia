namespace Fabulous.Avalonia.Mvu

open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Avalonia
open Avalonia.Collections
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous
open Fabulous.Avalonia

type IFabMvuShape =
    inherit IFabMvuControl
    inherit IFabShape
