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

