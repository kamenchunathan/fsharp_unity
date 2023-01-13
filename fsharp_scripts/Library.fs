namespace fsharp_scripts

open UnityEngine


type Card = { flipped: bool; value: int }


type CardManager() =
    inherit MonoBehaviour()

    let mutable cardOjbects: GameObject[] = [||]

    let mutable cards: Card[] =
        [ for i in 1..4 ->
              { flipped = (if i % 2 = 0 then true else false)
                value = i } ]
        |> Array.ofList

    [<field: SerializeField>]
    member val public CardPrefab: GameObject = null with get, set

    member this.Cards = cards
    member val CardObjects = cardOjbects with get, set


    member this.Start() =
        this.CardObjects <-
            Array.mapi
                (fun i _ ->
                    GameObject.Instantiate(
                        this.CardPrefab,
                        Vector3(float32 i, float32 0.0, float32 0.0),
                        Quaternion.identity
                    )
                    :?> GameObject)
                cards

    member this.Update() = ()
