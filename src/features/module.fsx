// https://fsharpforfunandprofit.com/posts/organizing-functions/

//F# module and function inside it is the same as static class and static method in C#
// in F# every function should be inside module (if it is not located inside class)
module A =
    let add x y = x + y
    
module B =
    let addThreeNumbers x y z =
        //reference other module
        (A.add x y) + z
        
module C =
    // reference other module by importing whole module
    open A
    let addThreeNumbers x y z =
        (add x y) + z
        
// ! for each .fs file (not .fsx)
// There should be top level module !
// no need for "=" sign
// the content is not indented
        
// module could contain
module Z =
    //function
    let add x y = x + y
    
    //type definition (interface)
    type ICar =
        abstract member GetColor: string -> string
        
    //class definition
    type Car() =
        interface ICar with
            member this.GetColor (carName:string) =
                sprintf "Green"
                
    //constant
    let PI = 3.14
    
    //mutable
    let mutable color = "red"
    
    //static constructor TODO - what does this mean? 
    do printfn "module initialized"
    
//----

[<RequireQualifiedAccess>]
module X =
    let add x y = x + y
    
module Y =
    // this is allowed
    let sum = X.add 1 2
    
module R =
    //this is not allowed because of RequireQualifiedAccess
    //open X
    ()
    
// ! organize type and functions that operate it. 2 options:
// 1. delcare type separatelly from functions
// 2. declare type and function in the same module

// I prefer second option because it increases maintainability bc F# depends on code order.
// so I could put all types above business logic not to refactor it later 