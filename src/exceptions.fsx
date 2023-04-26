open System 

exception NotSupportedAge of string

let checkAge age =
    match age with 
    | var1 when var1 < 0  -> raise (ArgumentException("Wrong age"))
    | var1 when var1 > 18 && var1 < 60 -> sprintf "Just good"
    | var1 when var1 > 60 -> raise (NotSupportedAge("This age is not supported"))
    | 0 -> raise (Exception("Possible invalid input"))
    
let checkAgeResult age=
    try 
        Some(checkAge age)
    with
        | :? ArgumentException as ex -> printfn "ArgumentException occured. Message: %s" ex.Message; None
        | :? NotSupportedAge as ex -> printfn "NotSupportedAge occured. Message: %s" ex.Message; None
        | ex -> printfn "Exception occured. Message %s" ex.Message; None
    
checkAgeResult -1 |> ignore
checkAgeResult 10 |> ignore
checkAgeResult 30 |> ignore
checkAgeResult 0 |> ignore