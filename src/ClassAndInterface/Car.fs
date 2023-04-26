namespace Course

type Car(Name: string) = 
    interface IVehicle with 
        member this.RunEngine runName =
            printfn "Car engine was started with prop: %s" runName