type Person = {
    name: string
    age: int
}
    
printfn "Integer: %i" 123
        
//A - any, but not Array
printfn "Array: %A" ([| 2; 3; 4|])
let person = {name="test name"; age=20}
printfn "Any object: %A" person

printfn "float: %0.1f" 123.456

