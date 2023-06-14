module A =
    // !!! F# does not have variables, because the key concept of functional programming is immutability !!!
    // that's why we can create values but not variables. we cannot change them
    let someValue = "123"
    
    //we only can do shadowing (it does not work in .fsx, but it works fine in .fs files)
    //let someValue = "new value"
    
    // and we also could use mutable
    let mutable someMutable = "hello"
    someMutable <- "hello world"
    
    