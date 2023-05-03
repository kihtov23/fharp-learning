open System
open System.Collections.Generic

//https://fsharpforfunandprofit.com/posts/function-signatures/
// F# has 2 types of syntaxes
//1 - normal expressions
//2 - type definitions

//--- a normal expressions
1
[1;2]
Some 1
(1, "a")

//--- a type expression
//int list
//int option 
//int * string

//F# uses type inference - no need to define types explicitly 

// expression syntax        // type syntax
let add1 x = x + 1          // int -> int
let add x y = x + y         // int -> int -> int
let print x = printf "%A" x // 'a -> unit
System.Console.ReadLine     // unit -> string
//List.sum                  // 'T list -> 'T
List.filter                 // ('T -> bool) -> T' list -> 'T list
List.map                    // ('T -> 'U) -> 'T list -> 'U list

// such constructions in type syntax like ('T -> 'U), (unit->string) mean functions
// for example, this type syntax: int -> (unit -> string) could be
let someFunction x = 
    fun () -> sprintf "value: %i" x
someFunction 12
(someFunction 12)()

// define own types for function signatures 
type Converter = float -> int
type TwoConverters = decimal -> Converter

let a:TwoConverters = fun x -> (fun y -> Convert.ToInt32(x)  + Convert.ToInt32(y))
//this will not compile
//let b:TwoConverters = fun x -> (fun y -> x  + y)
// now it compiles
let c                  = fun x -> (fun y -> x  + y)

//--- Exercise: write functions that fit these signatures ( avoid using explicit type annotations!):


//val testA = int -> int
let testA x = x + x

//val testB = int -> int -> int
let testB x y = x + y

//val testC = int -> (int -> int)
//[TODO] not sure how to solve this. why x becomes 'a here?
let testC z = testB 2

//[TODO] - this is in progress
//val testD = (int -> int) -> int
//val testE = int -> int -> int -> int
//val testF = (int -> int) -> (int -> int)
//val testG = int -> (int -> int) -> int
//val testH = (int -> int -> int) -> int