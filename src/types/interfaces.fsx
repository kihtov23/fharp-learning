type IUserService = 
    abstract member GetUser: string -> string

type UserService() =
    interface IUserService with
        member this.GetUser name =
            sprintf "This is user: %s" name

let userService = new UserService()
let userGetter = userService :> IUserService
userGetter.GetUser "Oleg"