namespace TestableApp


open Xunit

module Tests =
    [<Fact>]
    let ``Should_Type_Text_Into_TextBox`` () =
        Assert.Equal("Full name is Edgar Gonzalez", "Full name is Edgar Gonzalez")
