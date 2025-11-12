namespace FSharpSlowBuild.Tests.CodeGen

module CSharpHelperTests =

    open System
    open Xunit
    module CSH = FSharpSlowBuild.CodeGen.CSharpHelper


    //
    // objToNullableFloat
    //

    [<Fact>]
    let ``objToNullableFloat null returns null`` () =
        let nullableFloat = Nullable<float>()
        let actual = nullableFloat :> obj |> CSH.objToNullableFloat

        Assert.Equal(nullableFloat, actual)

    [<Theory>]
    [<InlineData(7.0)>]
    [<InlineData(3.14)>]
    [<InlineData(0.12345)>]
    let ``objToNullableFloat non-null returns non-null`` floatValue =
        let expected = Nullable<float>(floatValue)
        let actual = floatValue :> obj |> CSH.objToNullableFloat

        Assert.Equal(expected, actual)

    
    //
    // floatAsDecimalString
    //

    [<Fact>]
    let ``floatAsDecimalString null returns "null"`` () =
        let nullableFloat = Nullable<float>()
        let actual = nullableFloat |> CSH.floatAsDecimalString

        Assert.Equal("null", actual)

    [<Theory>]
    [<InlineData(134.55)>]
    [<InlineData(3.14)>]
    [<InlineData(100.34)>]
    let ``floatAsDecimalString returns float string with two decimals`` number =
        let nullableFloat = Nullable<float>(number)
        let actual = nullableFloat |> CSH.floatAsDecimalString
        let numberAsString = number.ToString("0.00")

        Assert.Equal($"{numberAsString}m", actual)


    //
    // escapeCSharpString
    //

    [<Fact>]
    let ``escapeCSharpString null returns "null"`` () =
        let actual = null |> CSH.escapeCSharpString

        Assert.Equal("null", actual)

    [<Theory>]
    [<InlineData("these are \"air quotes\"")>]
    [<InlineData("\\")>]
    [<InlineData("nothing to escape")>]
    let ``escapeCSharpString escapes backslashes`` (text : string) =
        let expected = text.Replace("\"", "\\\"")
        let actual = text |> CSH.escapeCSharpString

        Assert.Equal(expected, actual)


    //
    // quotedCSharpString
    //

    [<Fact>]
    let ``quotedCSharpString null returns "null"`` () =
        let actual = null |> CSH.escapeCSharpString

        Assert.Equal("null", actual)

    [<Theory>]
    [<InlineData("these are \"air quotes\"")>]
    [<InlineData("\\")>]
    [<InlineData("nothing to escape")>]
    let ``quotedCSharpString escapes backslashes and enquote`` (text : string) =
        let expected = "\"" + text.Replace("\"", "\\\"") + "\""
        let actual = text |> CSH.quotedCSharpString

        Assert.Equal(expected, actual)
