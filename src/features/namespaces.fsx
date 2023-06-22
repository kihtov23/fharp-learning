//https://fsharpforfunandprofit.com/posts/organizing-functions/

namespace namespaceA
    module A =
        let add x y = x + y
    
//F# files could have multiple namespaces, no nesting
namespace namespaceB
    module B =
        // mention namespace here
        let result = namespaceA.A.add 1 2 
        let add x y = x + y
        
// f# does not have global namespace - you should add namespace manually
// namespace can directly contain type declaration, but not function delcaration
// all function and value declaration should be in module

// ! namespaces don't work well in .fsx scripts
        
        