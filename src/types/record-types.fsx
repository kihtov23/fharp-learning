type Person = {
    Name: string
    Age: int
}

//provide explicit type by prefixing 
let person = {Person.Name = "Test name"; Age = 20}
printfn "Person record: %A" person

//explicitly declare type 
let otherPerson : Person = {Name = "Test name"; Age = 20}
// full structural equality 
let areSame = person = otherPerson

let updatedPerson = { person with Age = 30 }

// click ctrl + period to "before Age" and click generate missing fields
let auotgeneratedPerson = { Person.Name = "test"
                            Age = failwith "todo"}


//shadowing
let somePerson = { Person.Name = "Oleg"
                   Age = 20 }

//shadowing does not work in .fsx scripts but it works fine in .fs files
//let somePerson = {somePerson with Age = 32 }