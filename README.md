# MDLPClient
Форк репозитория https://github.com/yallie/MdlpClient
Несколько небольших изменений для того чтобы все работало. Измеился API URL итд
Используется в основном для обеспечения дополнительного функционала F3Tail
На основе библиотеки - несколько клиентов

* Загрузка содержимого короба по SSCC в случае если поставщик отправил разукомплетованный, но целый короб
* Проверка несписанных КИЗ в базе F3Tail/Ефарма в честном знаке
Используется для выравнивания остатков в Честном знаке и учетной системе. Так как честный знак может терять данные опродажах, которые ему выгружает оператор ОФД. Можно выявить по отсутствию документов о продажах за несколько дней 
* Контроль исходящих документов о приемки товара
Если протух ключ шифрования или сбой отправки в ЧЗ. Программа проверяет есть ли исходящие документы за неделю. Если нет - выведет сообщение. После этого нужно будет связаться с техническим специалистом для выяснения причины.
