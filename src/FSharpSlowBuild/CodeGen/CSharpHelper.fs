namespace FSharpSlowBuild.CodeGen

module CSharpHelper = 

    open System

    /// Convert an object to a nullable float.
    let objToNullableFloat (value : obj | null) =
        match value with
        | null -> Nullable()
        | _ -> (Nullable (value :?> float))

    /// Convert a nullable float to either the string null or a decimal string with two decimal places 
    /// and an "m" suffix, to be used as a C# decimal literal.
    let floatAsDecimalString (value : Nullable<float>) =
        match value.HasValue with
        | false -> "null"
        | true -> 
            let decimalString = value.Value.ToString("0.00")
            $"%s{decimalString}m"

    /// Escape a C# string.
    let escapeCSharpString (value : string | null) =
        match value with
        | null -> "null"
        | s -> s.Replace("\"", "\\\"")

    /// If s is not null, escape the value and wrap it in quotes. Otherwise, return the string "null".
    let quotedCSharpString (value : string | null) =
        match value with
        | null -> "null"
        | s -> $"\"%s{s |> escapeCSharpString}\""

    /// Convert a nullable decimal to either the string "null" or a decimal string with two decimal
    /// places and an "m" suffix, to be used as a C# decimal literal.
    let nullableDecimalAsCurrencyStringNoSymbol (value : Nullable<decimal>) =
        match value.HasValue with
        | false -> "null"
        | true -> 
            let decimalString = value.Value.ToString("0.00")
            $"%s{decimalString}m"
