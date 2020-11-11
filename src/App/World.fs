module World
  open Block
  open Snake

  type World = { Snakes: Snake list }
  
  let snake = NormalSnake { Tail = [(0, 0)]; Direction = Right; }
  let world = { Snakes = [snake] }

  [<EntryPoint>]
  let main argv =
    printfn "Hello world"
    0
