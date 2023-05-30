//this is how we create hierarchy in OOP
// base Disc class
// child 1 - HardDisk
// child 2 - SolidState
// child 3 - MMC

// This is how to do it in F#
type Disk =
    | HardDisk of RPM:int * Platters:int
    | SolidState
    | MMC of NumberOfPins:int

//create instance 
let someHardDisk = HardDisk(RPM = 250, Platters = 7)
let someHardDiskShort = HardDisk(250, 7)
let someMMC = MMC 5
let someSSD = SolidState

//use the instances created above
let rpm = 
    match someHardDisk with
    | HardDisk(rpm, _) -> Some(rpm)
    | _ -> None