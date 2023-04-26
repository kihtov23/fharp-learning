type IVehicle = 
    abstract member StartEngine : string -> unit

type Car() =
    interface IVehicle with 
        member this.StartEngine startType = 
            printfn "Car engine was started %s" startType

type Bike() = 
    interface IVehicle with 
        member this.StartEngine startType = 
            printfn "Bike was started %s" startType


let car = Car() :> IVehicle
car.StartEngine("with a key")

let bike = Bike() :> IVehicle
bike.StartEngine("manually")
 
