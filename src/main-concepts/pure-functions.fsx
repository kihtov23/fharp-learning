//--------------  PURE FUNCTIONS ----------------------

// sometimes we violate this rule, because its not possible to follow it in the whole solution
// For example, IServiceCollection could look like anti pattern in functional programming
// But it's difficult to live without IoS container so it's fine to use it. 
// Then the principle of pure functions is not always applied in F#. We accept that fact ;)

// it could be service, repository, cache. It could be IServiceCollection 
type UserService() = 
    member this.GetUserName() =
        sprintf "Oleg"

let getUserName() =
    let someService = new UserService()
    let name = someService.GetUserName() 
    printfn "Name: %s" name

getUserName()

//curried function
let add a b = a + b

//tupled function, requires all arguments 
let multiply (a, b) = a*b

//curried function exercise:
//Isaac book p 129
let writeToFile (date:System.DateTime) fileName text =
    let fileName = sprintf "%s-%s.txt" (date.ToString("yyMMdd")) fileName
    System.IO.File.WriteAllText (fileName, text)
writeToFile System.DateTime.Now "someTitle" "Hello world"

let writeToTodayFile = writeToFile System.DateTime.Now
let writeToTodayFileTestText = writeToTodayFile "test text"