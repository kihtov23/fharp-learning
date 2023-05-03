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