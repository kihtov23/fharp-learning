//Isaac Abraham book, lesson 36: Asynchronous workflows p.425

// makes sense to use only for I/O-bound workflows (web api, DB etc)
// because they don't need Thread as they are executed on external resource and wait for callback

//-------- "My name is Simon." is printed immediately 
async {
    printfn "loading data!"
    System.Threading.Thread.Sleep(5000)
    printfn "Loaded data!"
}
|> Async.Start
printfn "My name is Simon."

// ----------------------------------------------------------------
// use return in async computation expression
// async blocks are executed when we explicitly call Async.RunSynchronously or Async.Start
let asyncHello : Async<string> = async { return "Hello" }
let text = asyncHello |> Async.RunSynchronously 
printfn $"{text}"

// ----------------------------------------------------------------
// Async.Start can start only void functions
// let! could be used only inside computation expressions. let! is like await in C#
let asyncString =
    async {
        return "Hello world"
    } 
let getValueFromAsyncString =
    async {
        let! text = asyncHello
        printfn $"{text}"
        return ()
    }
getValueFromAsyncString |> Async.Start

// ----------------------------------------------------------------
//fork/join
//workflows type =              Async<int> list,
//but Async.Parallel returns =  Async<int array>
let random = System.Random()
let printNumbersAsync =
    let workflows = [for i in 1 .. 50 -> async { return random.Next(10) } ]
    async {
        let! numbers = workflows |> Async.Parallel
        printfn "%A" numbers
    }
    
//[TODO] what can happen if main thread returns execution before background workflow finishes ?
printNumbersAsync |> Async.Start

// ----------------------------------------------------------------
// async http requests
let downloadData url =
    async {
        let client = new System.Net.Http.HttpClient()
        let uri = new System.Uri(url)
        let! response = client.GetAsync(uri) |> Async.AwaitTask
        return response.Content.ToString().Length
    }
    
let urls = [|"http://www.fsharp.org"; "http://microsoft.com"; "http://fsharpforfunandprofit.com"|]
let sizes =
    urls
    |> Array.map downloadData
    |> Async.Parallel
    |> Async.StartAsTask
    
printfn "Total size = %i" (sizes.Result |> Array.sum)

// ----------------------------------------------------------------
let getSomeDataAsync =
   async {
       return "Hello world"
   }

//[TODO] to get data asynchronously without computation expression and get result
//we need to convert async to task first and then use Result
//but is .Result async or it blocks thread? 
let resultTask = getSomeDataAsync |> Async.StartAsTask
let result = resultTask.Result
printfn $"{result}"

  

