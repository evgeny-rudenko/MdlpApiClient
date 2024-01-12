# Экспорт списка КИЗов , которые прошли по кассе 

Консольное приложение для выгрузки списка КИЗов, которые прошли по кассе и должны быть списаны
Формат выгрузки текстовый 
Код_Подразделения_в_МДЛП;SGTIN;НомерЧека;Дата_Чека
Файл необходимо будет использовать для сравнения со списком  SGTIN, которые числятся в обороте на сайте Честный Знак

Напиши программу на C# консольную программу, которая будет выполнять следующие действия 

1 подключается к БД MS SQL Server
2 выполняет запрос
SELECT
    K.GTIN_SGTIN,
    K.GTIN,
    K.SGTIN,
    DOCUMENT_SUB = COALESCE(
        ADS.MNEMOCODE,
        CH.MNEMOCODE,
        M.MNEMOCODE,
        ADE.MNEMOCODE,
        IO.MNEMOCODE,
        AR2C.MNEMOCODE,
        SVED.DOC_NUM),
    K.ID_KIZ,
    K.ID_KIZ_GLOBAL
FROM KIZ K(NOLOCK)
    INNER JOIN KIZ_2_DOCUMENT_ITEM KDI(NOLOCK) ON KDI.ID_KIZ_GLOBAL = K.ID_KIZ_GLOBAL
    INNER JOIN LOT L(NOLOCK) ON L.ID_DOCUMENT_ITEM_ADD = KDI.ID_DOCUMENT_ITEM_ADD
	INNER JOIN SCALING_RATIO SR(NOLOCK) ON SR.ID_SCALING_RATIO = L.ID_SCALING_RATIO AND SR.NUMERATOR = ISNULL(K.QUANTITY, 1)
    LEFT JOIN ACT_DISASSEMBLING ADS(NOLOCK) ON ADS.ID_ACT_DISASSEMBLING_GLOBAL = K.ID_DOCUMENT_SUB AND K.ID_TABLE_SUB = 6
    LEFT JOIN CHEQUE CH(NOLOCK) ON CH.ID_CHEQUE_GLOBAL = K.ID_DOCUMENT_SUB AND K.ID_TABLE_SUB = 7
    LEFT JOIN MOVEMENT M(NOLOCK) ON M.ID_MOVEMENT_GLOBAL = K.ID_DOCUMENT_SUB AND K.ID_TABLE_SUB = 8
    LEFT JOIN ACT_DEDUCTION ADE(NOLOCK) ON ADE.ID_ACT_DEDUCTION_GLOBAL = K.ID_DOCUMENT_SUB AND K.ID_TABLE_SUB = 20
    LEFT JOIN INVOICE_OUT IO(NOLOCK) ON IO.ID_INVOICE_OUT_GLOBAL = K.ID_DOCUMENT_SUB AND K.ID_TABLE_SUB = 21
    LEFT JOIN INTERFIRM_MOVING IM(NOLOCK) ON IM.ID_INTERFIRM_MOVING_GLOBAL = K.ID_DOCUMENT_SUB AND K.ID_TABLE_SUB = 37
    LEFT JOIN ACT_RETURN_TO_CONTRACTOR AR2C(NOLOCK) ON AR2C.ID_ACT_RETURN_TO_CONTRACTOR_GLOBAL = K.ID_DOCUMENT_SUB AND K.ID_TABLE_SUB = 3
    LEFT JOIN INVENTORY_SVED SVED(NOLOCK) ON SVED.ID_INVENTORY_GLOBAL = K.ID_DOCUMENT_SUB AND K.ID_TABLE_SUB = 24
where CH.MNEMOCODE is not null
and  K.[STATE] = 'EXIT'

3 Полученные данные выгружает в текстовый файл в формате  CSV разделителем ;

Напиши программу на C# консольную программу, которая будет выполнять следующие действия 
1 прочитает  csv файл следующего формата GTIN_SGTIN;GTIN;SGTIN;MDLP_MD;DOCUMENT_SUB;ID_KIZ;ID_KIZ_GLOBAL
2 загрузит содержимое файла в таблицу MS SQL Server