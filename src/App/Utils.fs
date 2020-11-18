module Utils
  let removeLastElement list =
    let rec loop list acc =
      match list with
      | [] -> acc
      | head :: tail ->
        match tail with
        | h :: t -> loop tail (head :: acc)
        | _ -> acc
    loop list []
    |> List.rev

