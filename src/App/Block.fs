module Block
  type Position = int * int
  type Block = Position

  type Direction =
    | Up
    | Down
    | Right
    | Left

  let moveBlock direction block =
    match direction with
    | Up -> (fst block, snd block - 1)
    | Down -> (fst block, snd block + 1)
    | Right -> (fst block + 1, snd block)
    | Left -> (fst block - 1, snd block)
