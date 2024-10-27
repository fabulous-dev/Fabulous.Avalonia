namespace Gallery


open Fabulous.Avalonia.Mvu
open type Fabulous.Avalonia.Mvu.View

module TreeViewPage =
    let view () =
        TabControl() {
            TabItem("Simple", SimpleTreeView.view())
            TabItem("With TreeViewItem", SimpleTreeView.treeViewItem())
            TabItem("With node interaction", TreeViewWithNodeInteraction.view())
            TabItem("Editable", EditableTreeView.view())
        }
