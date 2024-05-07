namespace Fabulous.Avalonia

open System
open System.Linq.Expressions
open System.Reflection
open System.Runtime.CompilerServices
open Avalonia.Data
open Avalonia.Data.Converters

type BindingExtensions =

    /// Allows multi-binding a bound property on a control of type T
    /// to the properties identified by the propertyNames in the specified format.
    [<Extension>]
    static member multiBind<'T>(control: obj, boundProperty: Expression<Func<'T, IBinding>>, format: string, [<ParamArray>] propertyNames: string[]) =
        let binding = MultiBinding()
        binding.Converter <- FuncMultiValueConverter<obj, string>(fun parts -> String.Format(format, parts |> Seq.toArray))

        for property in propertyNames do
            binding.Bindings.Add(Binding(property))

        // Get member information from the expression
        let memberExpression = boundProperty.Body :?> MemberExpression
        let propertyInfo = memberExpression.Member :?> PropertyInfo

        // Set property value on control
        propertyInfo.SetValue(control, binding, null)
