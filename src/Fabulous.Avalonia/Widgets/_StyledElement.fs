namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Fabulous

type IFabStyledElement =
    inherit IFabAnimatable

module StyledElement =

    let Name = Attributes.defineAvaloniaPropertyWithEquality StyledElement.NameProperty

[<Extension>]
type StyledElementModifiers =
    [<Extension>]
    static member inline name(this: WidgetBuilder<'msg, #IFabStyledElement>, name: string) =
        this.AddScalar(StyledElement.Name.WithValue(name))
