//F# principle ------------ declarative over imperative --------------------
//

//imperative: define what we need to do step by step
//this is not a desired way to program in F#, it is just an illustration of imperative approach 
let numbers = [1..10]
let mutable result : int array = [||]

for n in numbers
    do 
        if ((n % 2) <> 0) then 
            result <- [| yield! result; n |]

printfn "imperative result: %A" result


//declarative: describe what you want 
let newResult = [1..10] |> Seq.where (fun num -> (num%2) <> 0)
printfn "declarative result: %A" newResult