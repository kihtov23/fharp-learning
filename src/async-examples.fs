﻿namespace Course

module AsyncExamples = 

    let getRows =
        task {
            let! rows = System.IO.File.ReadAllLinesAsync "./files/test.txt"
            return rows
        }

    let tryThis =
        let x =
            task {
                let! fileRows = getRows 

                fileRows
                    |> Array.iter (fun r -> printfn "%s" r)
            } 

        x.Wait()
        