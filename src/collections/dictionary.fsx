open System.Collections.Generic

let dict = new Dictionary<int, string>()

// dictionary is mutable
dict.Add(5, "test 5")
printfn "Element with key 5: %s" dict[5]


