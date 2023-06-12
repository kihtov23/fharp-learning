let getResult (input: string) =
    if input.Length > 0 then
        Some(input)
    else
        None
let result = getResult("test")


