type UsedId = UserId of string 

let caseUnionUserId = "123qwe" |> UserId
let stringId = "123qwe"

let (UserId userId') = caseUnionUserId

if (userId' = stringId) then
printfn "Values are equal"
else 
printfn "Values are different"
