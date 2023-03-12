# REST API для игры в крестики нолики

## Краткое описание:

- Сервис реализован на ASP.NET CORE Web API
- Используется база данных MS SQL Server
- Для работы с данными применяется Entity Framework Core

## Описание методов сервиса:

#### Начало/окончание игры

<details>
 <summary><code>POST</code> <code><b>/GameLogic/CreateNewGame</b></code> <code>(начать и запустить новую игру, в случае если нет уже начатой игры)</code></summary>

##### Параметры
  
> Нет параметров

##### Поддерживаемые типы содержимого запросов:
- `application/json-patch+json`
- `application/json`
- `text/json`
- `application/*+json`
  
##### Тело запроса

> | Имя параметра     | Тип данных| Описание                                                                                |
> |-------------------|-----------|-----------------------------------------------------------------------------------------|
> | crossesPlayerName | string    | Имя игрока, играющего крестиками                                                        |
> | noughtPlayerName  | string    | Имя игрока, играющего ноликами                                                          |

##### Возможные ответы

> | http код      | тип содержимого                   | ответ                                                                     |
> |---------------|-----------------------------------|---------------------------------------------------------------------------|
> | `201`         | `text/plain;charset=UTF-8`        | См. "Образец тела ответа с кодом 201" ниже                                |
> | `400`         | `text/plain;charset=UTF-8`        | `There is already one running game. It's impossible to add a second one`  |
> | `500`         | `text/html;charset=utf-8`         | `Internal server error. Something went wrong inside CreateNewGame action` |                                                                     
##### Тело ответа с кодом 201
 
> | Имя параметра     | Тип данных| Описание                                                                                |
> |-------------------|-----------|-----------------------------------------------------------------------------------------|
> | gameStatus        | string    | Статус игры (при создании игры - "Running")                                             |
> | crossesPlayerName | string    | Имя игрока, играющего крестиками                                                        |
> | noughtPlayerName  | string    | Имя игрока, играющего ноликами                                                          |
> | noughtWinnerName  | string    | Имя победившего в игре игрока (при создании игры - "No one")                            |  
> | startTime         | Datetime  | Дата и время начала игры                                                                |   
> | endTime           | Datetime  | Дата и время окончания игры (при создании игры - нет значения)                          |   
  
  
##### Образец тела ответа с кодом 201
  
> ```javascript
> {
>  "gameStatus": "Running",
>  "crossesPlayerName": "string",
>  "noughtsPlayerName": "string",
>  "winnerPlayerName": "No one",
>  "startTime": "2023-03-10T22:03:45.643",
>  "endTime": null
> }
> ```
  
##### Обрезец заголовков ответа с кодом 201
> ```javascript
>  content-length: 163 
>  content-type: application/json; charset=utf-8 
>  date: Fri,10 Mar 2023 19:43:33 GMT 
>  location: https://localhost:7152/Game/21 
>  server: Kestrel 
>  ```  

  
##### Образец cURL

> ```javascript
>  curl -X 'POST' \
>  'https://localhost:7152/GameLogic/CreateNewGame' \
>  -H 'accept: */*' \
>  -H 'Content-Type: text/json' \
>  -d '{
>  "crossesPlayerName": "string",
>  "noughtPlayerName": "string"
>  }'
> ```

</details>
