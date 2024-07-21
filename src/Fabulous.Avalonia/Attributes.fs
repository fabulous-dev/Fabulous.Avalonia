namespace Fabulous.Avalonia

open System
open System.IO
open Avalonia
open Avalonia.Controls
open Avalonia.Media.Imaging
open Fabulous

[<RequireQualifiedAccess>]
type ImageSourceValue =
    | Bitmap of source: Bitmap
    | File of source: string
    | Uri of source: Uri
    | Stream of source: Stream

[<RequireQualifiedAccess>]
module ScalarAttributeComparers =
    let inline physicalEqualityCompare a b =
        if LanguagePrimitives.PhysicalEquality a b then
            ScalarAttributeComparison.Identical
        else
            ScalarAttributeComparison.Different

module Attributes =
    /// Define an attribute for an AvaloniaProperty
    let inline defineAvaloniaProperty<'modelType, 'valueType>
        (property: AvaloniaProperty<'valueType>)
        ([<InlineIfLambda>] convertValue: 'modelType -> 'valueType)
        ([<InlineIfLambda>] compare: 'modelType -> 'modelType -> ScalarAttributeComparison)
        =
        Attributes.defineScalar<'modelType, 'valueType> property.Name convertValue compare (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(property)
            | ValueSome v -> target.SetValue(property, v) |> ignore)

    /// Define an attribute for an AvaloniaProperty supporting equality comparison
    let inline defineAvaloniaPropertyWithEquality<'T when 'T: equality> (directProperty: AvaloniaProperty<'T>) =
        Attributes.defineSimpleScalarWithEquality<'T> directProperty.Name (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(directProperty)
            | ValueSome v -> target.SetValue(directProperty, v) |> ignore)

    /// Define an attribute for an AvaloniaProperty supporting equality comparison with a default value and setter
    let inline defineProperty<'T when 'T: equality> name (defaultValue: 'T) (setter: obj -> 'T -> unit) =
        Attributes.defineSimpleScalarWithEquality<'T> name (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> setter target defaultValue
            | ValueSome v -> setter target v)

    /// Define an attribute for an AvaloniaProperty supporting equality comparison with getter and setter
    let inline definePropertyWithGetSet<'T when 'T: equality> name (getter: obj -> 'T) (setter: obj -> 'T -> unit) =
        Attributes.defineSimpleScalarWithEquality<'T> name (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> setter target (getter target)
            | ValueSome v -> setter target v)

    /// Define an attribute for an AvaloniaProperty supporting equality comparison and converter
    let inline defineAvaloniaPropertyWithEqualityConverter<'T, 'modelType, 'valueType when 'T: equality>
        (directProperty: AvaloniaProperty<'T>)
        (convert: 'modelType -> 'valueType)
        =
        Attributes.defineScalar<'modelType, 'valueType> directProperty.Name convert ScalarAttributeComparers.noCompare (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(directProperty)
            | ValueSome v -> target.SetValue(directProperty, v) |> ignore)

    /// Define an attribute storing a Widget for an AvaloniaProperty
    let inline defineAvaloniaPropertyWidget (property: AvaloniaProperty<'T>) =
        Attributes.definePropertyWidget property.Name (fun target -> (target :?> AvaloniaObject).GetValue(property)) (fun target value ->
            let avaloniaObject = target :?> AvaloniaObject

            if value = null then
                avaloniaObject.ClearValue(property)
            else
                avaloniaObject.SetValue(property, value) |> ignore)


    /// Performance optimization: avoid allocating a new ImageSource instance on each update
    /// we store the user value (e.g. Bitmap, string, Uri, Stream) and convert it to an ImageSource only when needed
    let inline defineBindableImageSource (property: AvaloniaProperty) =
        Attributes.defineScalar<ImageSourceValue, ImageSourceValue> property.Name id ScalarAttributeComparers.equalityCompare (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(property)
            | ValueSome v ->
                let value =
                    match v with
                    | ImageSourceValue.Bitmap source -> source
                    | ImageSourceValue.File file -> ImageSource.fromString file
                    | ImageSourceValue.Uri uri -> ImageSource.fromUri uri
                    | ImageSourceValue.Stream stream -> ImageSource.fromStream(stream)

                target.SetValue(property, value) |> ignore)

    /// Performance optimization: avoid allocating a new WindowIcon instance on each update
    /// we store the user value (e.g. Bitmap, string, Uri, Stream) and convert it to an ImageSource only when needed
    let inline defineBindableWindowIconSource (property: AvaloniaProperty) =
        Attributes.defineScalar<ImageSourceValue, ImageSourceValue> property.Name id ScalarAttributeComparers.equalityCompare (fun _ newValueOpt node ->
            let target = node.Target :?> AvaloniaObject

            match newValueOpt with
            | ValueNone -> target.ClearValue(property)
            | ValueSome v ->
                let value =
                    match v with
                    | ImageSourceValue.Bitmap source -> WindowIcon(source)
                    | ImageSourceValue.File file -> WindowIcon(ImageSource.fromString file)
                    | ImageSourceValue.Uri uri -> WindowIcon(ImageSource.fromUri uri)
                    | ImageSourceValue.Stream stream -> WindowIcon(ImageSource.fromStream(stream))

                target.SetValue(property, value) |> ignore)
