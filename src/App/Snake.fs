module Snake
  open Block

  type Tail = Block list
  type SnakeData = { Tail: Tail; Direction: Direction; }
  type Snake = 
    | NormalSnake of SnakeData 
    | CollidedSnake of SnakeData * Block

  let getSnakeHead snake = List.head snake.Tail

  let attachNewHeadToTail head tail = head :: List.tail tail

  let moveSnake (NormalSnake snake) = 
    snake
    |> getSnakeHead
    |> moveBlock snake.Direction
    |> attachNewHeadToTail <| snake.Tail
    |> (fun newTail -> NormalSnake { snake with Tail = newTail })
  
  let changeDirection direction snake = 
    match snake with
    | NormalSnake data -> NormalSnake { data with Direction = direction }

  let isSnakeCollided (snake: Snake) =
    match snake with
    | NormalSnake data     ->
      data.Tail
      |> List.skip 1
      |> List.tryFind (fun b -> List.head data.Tail = b)
      |> function
         | Some block -> CollidedSnake (data, block)
         | None       -> snake
    | CollidedSnake (_, _) -> snake

  let ifNotCollided f snake =
    match snake with
    | NormalSnake _ -> f snake
    | CollidedSnake (_, _) -> snake

  let nextSnake snake =
    match snake with
    | NormalSnake _ ->
      snake
      |> isSnakeCollided
      |> ifNotCollided (moveSnake)
