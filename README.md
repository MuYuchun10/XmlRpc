# Лабораторная работа: XML-RPC клиент/сервер на Horizon.XmlRpc 2.5.2

Проект полностью пересобран под пакет **Horizon.XmlRpc 2.5.2**:
- `Horizon.XmlRpc.Server` для сервера;
- `Horizon.XmlRpc.Client` для клиента.

## Проекты
- `XmlRpcMatrixServer` — XML-RPC сервер с методом `processMatrix`.
- `XmlRpcMatrixClient` — XML-RPC клиент, который запрашивает матрицу у пользователя и вызывает сервер.

## Как работает задача
Сервер принимает квадратную матрицу `n x n` и:
1. Ищет минимум на главной и побочной диагоналях.
2. Выбирает диагональ с меньшим минимумом (при равенстве — `Main`).
3. Обнуляет выбранную диагональ.
4. Возводит в квадрат элементы ниже выбранной диагонали.

Сервер возвращает:
- исходную матрицу;
- результирующую матрицу;
- минимум выбранной диагонали;
- имя выбранной диагонали (`Main`/`Secondary`).

## Запуск
```bash
dotnet restore
dotnet run --project XmlRpcMatrixServer
# в другом терминале
dotnet run --project XmlRpcMatrixClient
```

## Примечание по Horizon.XmlRpc
В этой версии используются пространства имён:
- `Horizon.XmlRpc.Core` (`XmlRpcMethod`, `XmlRpcFaultException`, `IXmlRpcProxy`);
- `Horizon.XmlRpc.Server` (`XmlRpcListenerService`);
- `Horizon.XmlRpc.Client` (`XmlRpcProxyGen`).
