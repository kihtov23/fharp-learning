type Singletone() = 
    static let appName = "Test app" 
    static member AppName = appName 

printfn "Test prop: %s" Singletone.AppName
