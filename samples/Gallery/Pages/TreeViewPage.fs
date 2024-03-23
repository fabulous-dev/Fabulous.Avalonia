namespace Gallery

open System.ComponentModel
open System.Diagnostics
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module TreeViewPage =
    type Node(name, children) =
        let mutable _clicked = 0

        // Define event for property changed notification
        let propertyChanged =
            new Event<PropertyChangedEventHandler, PropertyChangedEventArgs>()

        member this.Name = name
        member this.Children = children

        member this.Clicked
            with get () = _clicked
            and set value =
                _clicked <- value
                this.NotifyPropertyChanged(nameof this.Clicked)

        // Implement INotifyPropertyChanged
        interface INotifyPropertyChanged with
            [<CLIEvent>]
            member this.PropertyChanged = propertyChanged.Publish

        // Method to raise the PropertyChanged event
        member private this.NotifyPropertyChanged(propertyName) =
            propertyChanged.Trigger(this, new PropertyChangedEventArgs(propertyName))

    type Model = { Nodes: BindingList<Node> }

    type Msg = SelectionItemChanged of SelectionChangedEventArgs

    let branch name (children: Node list) =
        Node(name, BindingList<Node>(children |> Array.ofList))

    let leaf name = branch name []

    let init () =
        let nodes =
            [ branch
                  "Animals"
                  [ branch "Mammals" [ leaf "Lion"; leaf "Cat"; leaf "Zebra" ]
                    branch
                        "Birds"
                        [ leaf "Eagle"
                          leaf "Sparrow"
                          leaf "Dove"
                          leaf "Owl"
                          leaf "Parrot"
                          leaf "Pigeon" ]
                    leaf "Platypus" ]
              branch
                  "Aliens"
                  [ branch "pyramid-building terrestrial" [ leaf "Camel"; leaf "Lama"; leaf "Alpaca" ]
                    branch "extra-terrestrial" [ leaf "Alf"; leaf "E.T."; leaf "Klaatu" ] ] ]

        let observable = BindingList<Node>(nodes |> Array.ofList)

        let handleListChanged (sender: obj) (args: ListChangedEventArgs) =
            let property = args.PropertyDescriptor
            // gets called alright for the Clicked change. just doesn't propagate?
            //Debugger.Break()
            ()

        observable.ListChanged.AddHandler(ListChangedEventHandler(handleListChanged))

        { Nodes = observable }, []

    let update msg model =
        match msg with
        | SelectionItemChanged args ->
            let node = args.AddedItems[0] :?> Node
            node.Clicked <- node.Clicked + 1
            model, Cmd.none

    let program =
        Program.statefulWithCmd init update
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )

    let view () =
        View.Component(program) {
            let! model = Mvu.State

            VStack() {
                TreeView(
                    model.Nodes,
                    (_.Children),
                    (fun x ->
                        Border(
                            HStack(5) {
                                TextBlock(x.Clicked.ToString())
                                TextBlock(x.Name)
                            }
                        )
                            .background(Brushes.Gray)
                            .horizontalAlignment(HorizontalAlignment.Left)
                            .borderThickness(1.0)
                            .cornerRadius(5.0)
                            .padding(15.0, 3.0))
                )
                    .onSelectionChanged(SelectionItemChanged)
            }
        }
