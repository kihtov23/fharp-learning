//F# is about immutability
//https://fsharpforfunandprofit.com/posts/correctness-immutability/

let name = "Oleg"
//this is not possible
//name <- "Max" 

let mutable age = 20
// this is possible because we defined variable as mutable, which is not something we would like to do in functional programming
age <- 30 

//we can change record type like this
type Person = {Name: string; Age: int}
let somePerson = {Name= "Oleg"; Age= 77}
let updatedPerson = {somePerson with Age = 55}

let list1 = [1;2;3;4]
// "0::" adds 0 to the beginning of new list
let list2 = 0::list1

//[TODO] why tail is [1;2;3;4] but not just 4 ???
let list3 = list2.Tail

System.Object.ReferenceEquals(list1, list3)


//------------------------------------  TASKS -------------------------------------------------------

//add up ten numbers ( 1 .. 10 ) without using Linq.SumBy / Seq.sumBy / mutable keyword

//this approach solves the task but it does not related to "immutability" ;)
//so it would be good to find other solution as well 
let rec getSum (initSum:int) (countFrom:int) (countTo:int) = 
    if countFrom = countTo 
        then
            initSum + countFrom
        else
            getSum (initSum+countFrom) (countFrom+1) countTo 

printfn "Sum: %i" (getSum 0 1 10)

