#r "nuget:Validus"
#r "nuget:FsToolkit.ErrorHandling"

open Validus
open System
open FsToolkit.ErrorHandling

module CoreTypes =
    type NonEmptyList<'T when 'T : equality> =
        private | NonEmptyList of 'T list
        static member TryCreate field (xs : 'T list) =
            Check.List.notEmpty field xs
            |> Result.map NonEmptyList
    type GroupId =
        private | GroupId of Guid
        static member TryCreate value =
            value
            |> Check.Guid.notEmpty "Group Id"
            |> Result.map GroupId

open CoreTypes
type Context = { GoalMandatory : bool }

type RawCreateOrUpdateRegistration =
    {
        BusinessUnits : string list
        Goal : string
        GroupId : Guid Nullable
        Decision : string
    }

type CreateOrUpdateRegistration =
    {
        BusinessUnits : string NonEmptyList
        Goal : string option // optional "based on config"...
        GroupId : GroupId option
        Decision : string // mandatory although theoretically *could be null*...
    }
    static member OfRaw (context:Context) (raw : RawCreateOrUpdateRegistration) = validate {
        let! businessUnits = raw.BusinessUnits |> NonEmptyList.TryCreate "Business Units"
        and! decision = raw.Decision |> Check.String.notEmpty "Decision"
        and! goal =
            if context.GoalMandatory then
                raw.Goal |> Check.String.notEmpty "Goal" |> Result.map Some
            else
                raw.Goal |> Option.ofObj |> Ok
        and! groupId =
            match raw.GroupId |> Option.ofNullable with
            | Some groupId -> GroupId.TryCreate groupId |> Result.map Some
            | None -> Ok None

        return {
            BusinessUnits = businessUnits
            Goal = goal
            GroupId = groupId
            Decision = decision
        }
    }


let raw : RawCreateOrUpdateRegistration = {
    BusinessUnits = [ "a"; "b" ]
    Goal = ""
    GroupId = Nullable()
    Decision = ""
}

let context = { GoalMandatory = true }

let result =
    raw
    |> CreateOrUpdateRegistration.OfRaw context


Check.String.greaterThanLen 10 "Name" "Isaac"