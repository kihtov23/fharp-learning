// Main idea - F# is about expressions not statements 
// there are about 50 expressions in F#

//these are all expressions
"a"
23
1+3
"hello world".Length
sprintf "hello world"

// lambda expression 
fun () -> "hello world"
//match expression
match 1 with 
    | 1 -> "one"
    | _ -> "not one"
//if-then-else
if true then "good" else "bad"
//for loop
for i in [1..10] 
    do printfn "num: %i" i
//exception handling 
try 
    let result = 1 / 0
    printfn "result = %i" result
with 
    | e-> 
        printfn "exception: %s" e.Message
//[TODO] let expression. What is that?)
let n=1 in n+2


//--- tips for using expressions 
let someFunction x = 
    printfn "x=%i" x
    x + 1
someFunction 5

// if we want to put several expressions on one line - use semicolon,
// but usually we place one expression per line
let someFunction1 x = printfn "x=%i" x; x+1
someFunction1 6

//this will have warning, 1 is implicitly ignored
let x = 1;2
x

let y = 3 |> ignore; 4
y

// Expression evaluation order.
// expressions are evaluated immediately in F#

let test value ifTrue ifFalse = if value then ifTrue else ifFalse
// "true" is printed and then "false" is printed. 
test false (printfn "true") (printfn "false")

//use Lazy<> wrapper
let f = test false (lazy (printfn "true")) (lazy (printfn "false"))
f.Force()
