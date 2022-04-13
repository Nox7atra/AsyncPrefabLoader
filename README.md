# AsyncPrefabLoader

Демо: https://noxatra.ru/experiments/async_prefab_loader/

Пример асинхронной загрузки кучи мелких префабов. Принцип работы довольно прост. В корутине мы каждый кадр инстаницируем определённое количетсво префабов.
Полезно для инстанцирования кучи одинаковых префабов.

Так как в главном потоке нельзя использовать Unity вызовы, то это именно сделано асинхронно в главном потоке. Команду LoadPrefabCommand можно расширить на нужный дополнительный функционал.

Пример использования: https://github.com/Nox7atra/AsyncPrefabLoader/blob/master/Assets/AsyncPrefabsLoader/Demo/DemoCommandGenerator.cs
