//Book "Get Programming with FSharp" (Isaac Abraham) Lesson 9 - tuples

//tuples
let parseName(fullName: string) =
    let parts = fullName.Split( )
    let firstName = parts[0]
    let secondName = parts[1]
    firstName, secondName
    
let nameParts = parseName("Oleh Kikhtov")
let firstName, secondName = nameParts 
printfn "second name = %s" secondName

let _, secondNameOnly = parseName("Oleh Kikhtov")
printfn "second name only: %s" secondNameOnly

let thisIsTubleNotDecimal = 1,2

//exercise
let parse(person: string)=
    let parts = person.Split(" ")
    let playerName = parts[0]
    let game = parts[1]
    let score = System.Convert.ToInt32(parts[2])
    playerName, game, score
    
let playerName, game, score = parse("Mary Asteroids 2500")
printfn "Player: %s, score: %i" playerName score

//nested tuples
let personeDetails = ("Oleg", "Kikthov"), 31
let (fName, sName), age = personeDetails