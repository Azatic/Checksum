# Using_Finite_field
## Контрольная сумма
### Пример использования
Сперва нужно задать многочлен над полем F_256:
```c#
var C_S = new Controlsum(new byte[] { 1, 1, 1, 1 });
```
Далее, для получения контрольной суммы многочлен Pt делится на заранее известный.

Вычисление контрольной суммы сообщения:
```c#
var message = "123456789"u8.ToArray();
var checkSum = C_S.GetSumm(message);
```
# Checksum
