namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabGrid =
    inherit IFabPanel

type Dimension =
    /// Use a size that fits the children of the row or column.
    | Auto
    /// Use a proportional size of 1
    | Star
    /// Use a proportional size defined by the associated value
    | Stars of float
    /// Use the associated value as the number of device-specific units.
    | Pixel of float

module GridUpdaters =
    let updateGridColumnDefinitions _ (newValueOpt: Dimension[] voption) (node: IViewNode) =
        let grid = node.Target :?> Grid

        match newValueOpt with
        | ValueNone -> grid.ColumnDefinitions.Clear()
        | ValueSome coll ->
            grid.ColumnDefinitions.Clear()

            for c in coll do
                let gridLength =
                    match c with
                    | Auto -> GridLength.Auto
                    | Star -> GridLength.Star
                    | Stars x -> GridLength(x, GridUnitType.Star)
                    | Pixel x -> GridLength(x, GridUnitType.Pixel)

                grid.ColumnDefinitions.Add(ColumnDefinition(Width = gridLength))

    let updateGridRowDefinitions _ (newValueOpt: Dimension[] voption) (node: IViewNode) =
        let grid = node.Target :?> Grid

        match newValueOpt with
        | ValueNone -> grid.RowDefinitions.Clear()
        | ValueSome coll ->
            grid.RowDefinitions.Clear()

            for c in coll do
                let gridLength =
                    match c with
                    | Auto -> GridLength.Auto
                    | Star -> GridLength.Star
                    | Stars x -> GridLength(x, GridUnitType.Star)
                    | Pixel x -> GridLength(x, GridUnitType.Pixel)

                grid.RowDefinitions.Add(RowDefinition(Height = gridLength))

module Grid =
    let WidgetKey = Widgets.register<Grid>()

    let ColumnDefinitions =
        Attributes.defineSimpleScalarWithEquality<Dimension array> "Grid_ColumnDefinitions" GridUpdaters.updateGridColumnDefinitions

    let RowDefinitions =
        Attributes.defineSimpleScalarWithEquality<Dimension array> "Grid_RowDefinitions" GridUpdaters.updateGridRowDefinitions

    let ShowGridLines =
        Attributes.defineAvaloniaPropertyWithEquality Grid.ShowGridLinesProperty

    let Column = Attributes.defineAvaloniaPropertyWithEquality Grid.ColumnProperty

    let Row = Attributes.defineAvaloniaPropertyWithEquality Grid.RowProperty

    let ColumnSpan =
        Attributes.defineAvaloniaPropertyWithEquality Grid.ColumnSpanProperty

    let RowSpan = Attributes.defineAvaloniaPropertyWithEquality Grid.RowSpanProperty

    let IsSharedSizeScope =
        Attributes.defineAvaloniaPropertyWithEquality Grid.IsSharedSizeScopeProperty

[<AutoOpen>]
module GridBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Grid widget.</summary>
        /// <param name="coldefs">Column definitions.</param>
        /// <param name="rowdefs">Row definitions.</param>
        static member inline Grid<'msg>(coldefs: seq<Dimension>, rowdefs: seq<Dimension>) =
            CollectionBuilder<'msg, IFabGrid, IFabControl>(
                Grid.WidgetKey,
                Panel.Children,
                Grid.ColumnDefinitions.WithValue(Array.ofSeq coldefs),
                Grid.RowDefinitions.WithValue(Array.ofSeq rowdefs)
            )

        /// <summary>Creates a Grid widget with a single column and row.</summary>
        static member inline Grid<'msg>() = View.Grid<'msg>([ Star ], [ Star ])

[<Extension>]
type GridModifiers =
    /// <summary>Sets the ShowGridLines property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ShowGridLines value.</param>
    [<Extension>]
    static member inline showGridLines(this: WidgetBuilder<'msg, IFabGrid>, value: bool) =
        this.AddScalar(Grid.ShowGridLines.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Grid control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabGrid>, value: ViewRef<Grid>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type GridAttachedModifiers =
    /// <summary>Sets the Column property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Column value.</param>
    [<Extension>]
    static member inline gridColumn(this: WidgetBuilder<'msg, #IFabControl>, value: int) =
        this.AddScalar(Grid.Column.WithValue(value))

    /// <summary>Sets the Row property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Row value.</param>
    [<Extension>]
    static member inline gridRow(this: WidgetBuilder<'msg, #IFabControl>, value: int) =
        this.AddScalar(Grid.Row.WithValue(value))

    /// <summary>Sets the ColumnSpan property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ColumnSpan value.</param>
    [<Extension>]
    static member inline gridColumnSpan(this: WidgetBuilder<'msg, #IFabControl>, value: int) =
        this.AddScalar(Grid.ColumnSpan.WithValue(value))

    /// <summary>Sets the RowSpan property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The RowSpan value.</param>
    [<Extension>]
    static member inline gridRowSpan(this: WidgetBuilder<'msg, #IFabControl>, value: int) =
        this.AddScalar(Grid.RowSpan.WithValue(value))

    /// <summary>Sets the IsSharedSizeScope property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsSharedSizeScope value.</param>
    [<Extension>]
    static member inline isSharedSizeScope(this: WidgetBuilder<'msg, #IFabControl>, value: bool) =
        this.AddScalar(Grid.IsSharedSizeScope.WithValue(value))
