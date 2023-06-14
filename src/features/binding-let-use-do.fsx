//resource: https://fsharpforfunandprofit.com/posts/let-use-do/

//----------------- let binding ------------------
// there are 2 scopes for let bindings. First one is top let binding:
module X =
    let f() =
        2 + 2
        
X.f()

//and second use case is to use let in nested scope
let parentScope =
    let childScope1 = 1 // if we complete out code here, we will get an error
    //that parentScope let binding is missing expression
    //think about "in" which we put after "let childScope1 = 1 in"
    //so that let binding should be used somewhere
    childScope1
    
parentScope

//----------- use binding ----------------------
// cannot apply for top level
module A =
    use f () = //warning - use binding becomes let binding on module level
        let x = 1
        x+1
        
// proper use binding
let createSomeResource name =
    { new System.IDisposable
      with member this.Dispose() = printfn "%s disposed" name }
    
let tryUseBinding =
    use myResource = createSomeResource "DB"
    printfn "done"
    //when this method is executed, "done" is printed first and then "DB disposed"
    
tryUseBinding

let tryLetBinding =
    let myResource = createSomeResource "DB"
    printfn "done"
    //here "done" is printed but disposed in never called and "DB disposed" is not printed at all
    
tryLetBinding


//-- best practice is not to return disposable but pass lambdas to disposable "creator"
let createResource name =
    { new System.IDisposable
      with member this.Dispose() = printfn "%s disposed" name }
let doSomethingWithDisposable lambda =
    use myResource = createResource "ResourceName"
    lambda myResource
    printfn "operation completed"
    
doSomethingWithDisposable (fun (resource)-> printfn "work with resource %A" resource)
//f# has special "using" to create Disposable and pass it to lambda:
using (createResource "SomeResource") (fun (resource)-> printfn "work with resource %A" resource)

//------------------- do -------------------------------
// use it to tell that you don't need the result but only the side effect
let someFunction() x y =
    printfn "do something"
    x + y
    
// we have side effect ("do something" is printed) but we don't need the result
do someFunction() 1 2 |> ignore
