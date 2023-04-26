//--------------  PURE FUNCTIONS ----------------------

// it could be service, repository, cache. It could IServiceCollection
type UserService() = 
    member this.GetUserName() =
        sprintf "Oleg"

//[TODO] From my point of view this function violates main functional programming principle - pure functions.
//And from my point of view IServiceCollection and dependency injection, in general, violates that principle as well (in functional programming). Is this true? 
let getUserName() =
    let someService = new UserService()
    let name = someService.GetUserName() 
    printfn "Name: %s" name

getUserName()

//[TODO] What does that really mean - pure function in practice? Is that possible to rely only on parameters and don't use any external dependency?
// for example, how to use such things in F#:
// - external api 
// - DB
// - cache
// - current session data, like logged user

