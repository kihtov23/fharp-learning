// match [something] with
// | lambda 1
// .....
// | lambda n

// The order is important! First which win will be executed

//Formatting
// - match starts on a new ling
// - expression after "->" should be on a new line (if it is not compact)

type Marks =
    | Dog
    | Cat
    | Elephant

let handleNotAllCases marks =
    match marks with
    | Dog -> "Bla bla bla"
    | Cat -> "something other bla"
    // this is bad practice! because if you add some other case to Marks, compiler will not help you
    | _ -> "all other cases"
    
//this is better:
let hanldeAllCases marks =
    match marks with
    | Dog -> "Bla bla bla"
    | Cat -> "something other bla"
    | Elephant -> "all other cases"    
    
//pattern matching types
//---bind to value
let matchTuple (a, b) =
    match (a, b) with
    | (1,b) -> sprintf "b=%A" b
    | (a, b) -> sprintf "a=%A, b=%A" a b

printfn "%s" (matchTuple (1, 3))
printfn "%s" (matchTuple (12, 3))

//---and/or
let matchTupleWithOrAnd (a, b) =
    //this is incomplete pattern matching, thats why see error
    match (a, b) with
    | (2, y) | (3, y) -> "x is 2 or 3"
    | (x, 4) & (4, y) -> "this is weird example but here expected result is (4, 4)"
    
// ! general rule - if we match to some union cases -> avoid wildcard
//if match all cases is not an easy task - use wildcard

//match on list/array
let matchArray a =
    match a with
    | [1; y; z] -> printfn "x = 1"
    | 1::tail -> printfn "tail =%A" tail
    | [] -> printfn "array is empty"
    
matchArray [1;2;3]
matchArray [1;2]
matchArray []

let rec printElementByElement (a:list<int>) =
    match a with
    | [] -> printfn "the end"
    | head::tail ->
        printfn "%A" head 
        printElementByElement tail
    
printElementByElement [1..5]

//match on records
type User = {Name: string; Age: int}
let user = {Name= "test"; Age= 16}
match user with
| {Name="Oleg"} -> printfn "this is a user with name - Oleg"
| {Age=20} -> printfn "user with age 20"
//when - also could be called as "guards" 
| {Age=age} when age < 18 -> printfn "too young"
| _ -> printfn "some other user"

//Type test pattern
type A() = class end
type B() = inherit A()
type C() = inherit A()

let matchDerivedClass (a: A) =
    match a with
    | :? C -> printfn "this is C"
    | :? B -> printfn "this is B"
    | :? A -> printfn "this is A"
    
matchDerivedClass (new A())
matchDerivedClass (new B())
matchDerivedClass (new C())

//identifier pattern
match Some(2) with
| Some x -> printfn "Val=%A" x
| None -> ()

type Area =
    | FirstZone of string
    | SecondZone of string
    | ThirdZone  of string * string

//let zone = FirstZone "Test zone"
let zone = ThirdZone ("zone1", "zone2")
match zone with
| FirstZone(x) -> printfn "FirstZone=%s" x
| ThirdZone(x, y) -> printfn "ThirdZone=%s and %s" x y
| _ -> printfn "not found"
    
//"function" keyword
let doSomething param =
    match param with
    | "one" -> printfn "bla"
    | _ -> printfn "bla bla"
doSomething "one"
    
let doSomethingHere =
    function
    | "one" -> printfn "bla"
    | _ -> printfn "bla bla"
doSomethingHere "one"

    
    


    
