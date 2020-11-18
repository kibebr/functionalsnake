module World
  open Block
  open Snake

  type World = 
    { Snakes: Snake list 
      Size: int
      BorderLevel: int }
  
  let snake = NormalSnake { Tail = [(2, 0); (1, 0); (0, 0)]; Direction = Right; }

  let world = 
    { Snakes = [snake]
      Size = 16
      BorderLevel = 0 }

  let nextWorld world = 
    { 
      world with
      Snakes = List.map nextSnake world.Snakes
    }

  [<EntryPoint>]
  let main argv =
    printfn "%A" <| nextSnake snake
    0
