# REST API для игры в крестики нолики

## Краткое описание:

- Сервис реализован на ASP.NET CORE Web API
- Используется база данных MS SQL Server
- Для работы с данными применяется Entity Framework Core

## Описание методов сервиса:

#### Начало/окончание игры

<details>
 <summary><code>POST</code> <code><b>/GameLogic/CreateNewGame</b></code> <code>(начать и запустить новую игру, в случае если нет начатой игры)</code></summary>

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
> | winnerPlayerName  | string    | Имя победившего в игре игрока (при создании игры - "No one")                            |  
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

<details>
 <summary><code>Delete</code> <code><b>/GameLogic/StopTheGame</b></code> <code>(досрочно закончить игру, в случае если есть начатая игра)</code></summary>

##### Параметры
  
> Нет параметров
  
##### Тело запроса

> Нет параметров

##### Возможные ответы

> | http код      | тип содержимого                   | ответ                                                                     |
> |---------------|-----------------------------------|---------------------------------------------------------------------------|
> | `200`         | `application/json; charset=utf-8` | См. "Образец тела ответа с кодом 200" ниже                                |
> | `404`         | `text/plain;charset=UTF-8`        | `There are no running games`                                              |
> | `500`         | `text/html;charset=utf-8`         | `Internal server error. Something went wrong inside StopGameExplicitly action` |                      

##### Тело ответа с кодом 200
 
> | Имя параметра     | Тип данных| Описание                                                                                |
> |-------------------|-----------|-----------------------------------------------------------------------------------------|
> | gameStatus        | string    | Статус игры (при окончании игры - "Finished")                                           |
> | crossesPlayerName | string    | Имя игрока, играющего крестиками                                                        |
> | noughtPlayerName  | string    | Имя игрока, играющего ноликами                                                          |
> | winnerPlayerName  | string    | Имя победившего в игре игрока (при досрочном окончании игры - "No one")                 |  
> | startTime         | Datetime  | Дата и время начала игры                                                                |
> | endTime           | Datetime  | Дата и время окончания игры                                                             |
  
##### Образец тела ответа с кодом 200
  
> ```javascript
> {
>  "gameStatus": "Finished",
>  "crossesPlayerName": "Player1",
>  "noughtsPlayerName": "Player2",
>  "winnerPlayerName": "No one",
>  "startTime": "2023-03-14T11:10:15.27",
>  "endTime": "2023-03-14T11:10:23.9978058+03:00"
> }
> ```
  
##### Обрезец заголовков ответа с кодом 200
> ```javascript
>   content-length: 197 
>   content-type: application/json; charset=utf-8 
>   date: Tue,14 Mar 2023 08:28:12 GMT 
>   server: Kestrel 
>  ```  

  
##### Образец cURL

> ```javascript
>  curl -X 'DELETE' \
>   'https://localhost:7152/GameLogic/StopTheGame' \
>   -H 'accept: */*'
> ```

</details>

<details>
 <summary><code>Get</code> <code><b>/GameLogic/CheckForGameover</b></code> <code>(сделать проверку, является ли одна одна из сторон победителем. вернуть состояние игры при положительном результате)</code></summary>

##### Примечание

> Подразумевается, что для корректной логики игры клиент будет вызывать данный метод после каждого хода одной из сторон

##### Параметры
  
> Нет параметров
  
##### Тело запроса

> Нет параметров

##### Возможные ответы

> | http код      | тип содержимого                   | ответ                                                                     |
> |---------------|-----------------------------------|---------------------------------------------------------------------------|
> | `200`         | `application/json; charset=utf-8` | См. "Образец тела ответа с кодом 200" ниже                                |
> | `204`         | `-`                               | - (отсутствие результата обозначает, что победителей пока нет)            |
> | `404`         | `text/plain;charset=UTF-8`        | `There are no running games`                                              |
> | `500`         | `text/html;charset=utf-8`         | `Internal server error. Something went wrong inside StopGameExplicitly action` |                      

##### Тело ответа с кодом 200
 
> | Имя параметра     | Тип данных| Описание                                                                                |
> |-------------------|-----------|-----------------------------------------------------------------------------------------|
> | gameStatus        | string    | Статус игры (при окончании игры - "Finished")                                           |
> | crossesPlayerName | string    | Имя игрока, играющего крестиками                                                        |
> | noughtPlayerName  | string    | Имя игрока, играющего ноликами                                                          |
> | winnerPlayerName  | string    | Имя победившего в игре игрока                                                           |  
> | startTime         | Datetime  | Дата и время начала игры                                                                |   
> | endTime           | Datetime  | Дата и время окончания игры                                                             |   
  
  
##### Образец тела ответа с кодом 200 ( в случае победы игрока, играющего крестиками)
  
> ```javascript
> {
>   "gameStatus": "Finished",
>   "crossesPlayerName": "Player1",
>   "noughtsPlayerName": "Player2",
>   "winnerPlayerName": "Player1",
>   "startTime": "2023-03-14T11:40:50.2",
>   "endTime": "2023-03-14T11:47:20.1103719+03:00"
> }
> ```
  
##### Обрезец заголовков ответа с кодом 200
> ```javascript
>    content-length: 196 
>    content-type: application/json; charset=utf-8 
>    date: Tue,14 Mar 2023 08:47:19 GMT 
>    server: Kestrel 
>  ```  

  
##### Образец cURL

> ```javascript
>  curl -X 'GET' \
>   'https://localhost:7152/GameLogic/CheckForGameover' \
>   -H 'accept: */*'
> ```

</details>

#### Процесс игры

<details>
 <summary><code>POST</code> <code><b>/GameLogic/MakeAMove</b></code> <code>(Сделать ход за одну из сторон)</code></summary>

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
> | gameSideId        | int       | Идентификатор стороны игры, где 1 - крестики, 2 - нолики                                |
> | x                 | int       | Координата по оси X (от 0 до 2)                                                         |
> | y                 | int       | Координата по оси Y (от 0 до 2)                                                         |

##### Возможные ответы

> | http код      | тип содержимого                   | ответ                                                                         |
> |---------------|-----------------------------------|-------------------------------------------------------------------------------|
> | `201`         | `text/plain;charset=UTF-8`        | См. "Образец тела ответа с кодом 201" ниже                                    |
> | `400`         | `text/plain;charset=UTF-8`        | `Now it's not a turn of noughts (crosses) to make a move`                     |
> | `400`         | `text/plain;charset=UTF-8`        | Ошибка валидации при неверно заданных значениях параметров (см. образец ниже) |                
> | `404`         | `text/plain;charset=UTF-8`        | `There are no running games`                                                  |
> | `500`         | `text/plain;charset=UTF-8`        | `Internal server error. Something went wrong inside MakeAMove action`         |

##### Тело ответа с кодом 201
 
> | Имя параметра     | Тип данных| Описание                                                                                |
> |-------------------|-----------|-----------------------------------------------------------------------------------------|
> | xValue            | string    | Координата по оси X                                                                     |
> | yValue            | string    | Координата по оси Y                                                                     |
> | gameSide          | string    | Наименование команды (Noughts, Crosses)                                                 |
  
##### Образец тела ответа с кодом 201
  
> ```javascript
> {
>   "xValue": 0,
>   "yValue": 1,
>   "gameSide": "Noughts"
> }
> ```
  
##### Обрезец заголовков ответа с кодом 201
> ```javascript
>   content-length: 44 
>   content-type: application/json; charset=utf-8 
>   date: Tue,14 Mar 2023 09:19:12 GMT 
>   location: https://localhost:7152/Point/7 
>   server: Kestrel 
>  ```  

  
##### Образец cURL

> ```javascript
> curl -X 'POST' \
>   'https://localhost:7152/GameLogic/MakeAMove' \
>   -H 'accept: */*' \
>   -H 'Content-Type: application/json-patch+json' \
>   -d '{
>   "gameSideId": 2,
>   "x": 0,
>   "y": 1
> }'
> ```

##### Образец ошибки валидации (ответ с кодом 400)

> ```javascript
> "errors": {
>     "X": [
>       "The field X must be between 0 and 2."
>     ]
>   },
>   "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
>   "title": "One or more validation errors occurred.",
>   "status": 400,
>   "traceId": "00-d3a65851972f12e771cebd15589b420b-a10c15b2a08fd23b-00"
> ```

</details>

#### Получение информации об играх

<details>
 <summary><code>Get</code> <code><b>/Game/gameId</b></code> <code>(получить объект игры )</code></summary>

##### Примечание

> При успешном создании новой игры (`POST` `/GameLogic/CreateNewGame`) в заголовке location ответа со статусом 201 содержится uri для вызова данного метода (например, `location: https://localhost:7152/Game/21`) 

##### Параметры
  
> | Имя параметра     | Тип данных| Описание                                                                                |
> |-------------------|-----------|-----------------------------------------------------------------------------------------|
> | gameId            | int       | Идентификатор объекта игры                                                              |
  
##### Тело запроса

> Нет параметров

##### Возможные ответы

> | http код      | тип содержимого                   | ответ                                                                   |
> |---------------|-----------------------------------|-------------------------------------------------------------------------|
> | `200`         | `application/json; charset=utf-8` | См. "Образец тела ответа с кодом 200" ниже                              |
> | `404`         | `text/plain;charset=UTF-8`        | `Game with this id doesn't exist`                                       |
> | `500`         | `text/html;charset=utf-8`         | `Internal server error. Something went wrong inside GetGameById action` |                      

##### Тело ответа с кодом 200
 
> | Имя параметра     | Тип данных| Описание                                                                                |
> |-------------------|-----------|-----------------------------------------------------------------------------------------|
> | gameStatus        | string    | Статус игры                                                                             |   
> | crossesPlayerName | string    | Имя игрока, играющего крестиками                                                        |
> | noughtPlayerName  | string    | Имя игрока, играющего ноликами                                                          |
> | winnerPlayerName  | string    | Имя победившего в игре игрока                                                           |  
> | startTime         | Datetime  | Дата и время начала игры                                                                |   
> | endTime           | Datetime  | Дата и время окончания игры                                                             |   
  
  
##### Образец тела ответа с кодом 200
  
> ```javascript
> {
>   "gameStatus": "Finished",
>   "crossesPlayerName": "Player1",
>   "noughtsPlayerName": "Player2",
>   "winnerPlayerName": "Player1",
>   "startTime": "2023-03-14T11:37:09.877",
>   "endTime": "2023-03-14T11:38:23.893"
> }
> ```
  
##### Обрезец заголовков ответа с кодом 200
> ```javascript
>    content-length: 185 
>    content-type: application/json; charset=utf-8 
>    date: Tue,14 Mar 2023 10:18:30 GMT
>    server: Kestrel 
>  ```  

  
##### Образец cURL

> ```javascript
> curl -X 'GET' \
>   'https://localhost:7152/Game/4' \
>   -H 'accept: */*'
> ```

</details>

<details>
 <summary><code>Get</code> <code><b>/Point/pointId</b></code> <code>(получить объект точки - с крестиком либо ноликом)</code></summary>

##### Примечание

> - При успешном создании новой точки (ходе одной из сторон игры) (`POST` `/GameLogic/MakeAMove`) в заголовке location ответа со статусом 201 содержится uri для вызова данного метода (например, `location: https://localhost:7152/Point/8`) 
> - Можно получить объект лишь для точки, задействованной в текущей активной игре

##### Параметры
  
> | Имя параметра     | Тип данных| Описание                                                                                |
> |-------------------|-----------|-----------------------------------------------------------------------------------------|
> | pointId            | int       | Идентификатор объекта точки                                                            |
  
##### Тело запроса

> Нет параметров

##### Возможные ответы

> | http код      | тип содержимого                   | ответ                                                                    |
> |---------------|-----------------------------------|--------------------------------------------------------------------------|
> | `200`         | `application/json; charset=utf-8` | См. "Образец тела ответа с кодом 200" ниже                               |
> | `404`         | `text/plain;charset=UTF-8`        | `Point with this id doesn't exist`                                       |
> | `500`         | `text/html;charset=utf-8`         | `Internal server error. Something went wrong inside GetPointById action` |                      

##### Тело ответа с кодом 200
 
> | Имя параметра     | Тип данных| Описание                                                                                |
> |-------------------|-----------|-----------------------------------------------------------------------------------------|
> | xValue            | string    | Координата по оси X                                                                     |
> | yValue            | string    | Координата по оси Y                                                                     |
> | gameSide          | string    | Наименование команды (Noughts, Crosses)                                                 |
  
##### Образец тела ответа с кодом 200
  
> ```javascript
> {
>   "xValue": 1,
>   "yValue": 2,
>   "gameSide": "Crosses"
> }
> ```
  
##### Обрезец заголовков ответа с кодом 200
> ```javascript
>  content-length: 44 
>  content-type: application/json; charset=utf-8 
>  date: Tue,14 Mar 2023 11:27:25 GMT 
>  server: Kestrel 
>  ```  

  
##### Образец cURL

> ```javascript
> curl -X 'GET' \
>   'https://localhost:7152/Point/8' \
>   -H 'accept: */*'
> ```

</details>