printfn "to: "
for i=1 to 3 do
    printfn "i = %i" i 

printfn "downto: "
for i=3 downto 1 do
    printfn "i = %i" i
        
let names = ["Oleg"; "Vika"; "David"]
for name in names do
    printfn "name: %s" name
        
//Create new collection 
let newNames = [for name in names do name.ToUpper()]
newNames |> List.iter (fun (n)-> printfn "newName: %s" n)

