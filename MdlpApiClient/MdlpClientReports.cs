 namespace MdlpApiClient
{
    using System.Linq;
    using System.Net;
    using DataContracts;
    using MdlpApiClient.Toolbox;
    using RestSharp;

    //


    /// <remarks>
    /// Отчеты МДЛП
    /// </remarks>
    partial class MdlpClient
    {

        // https://mdlp.crpt.ru/#/app/profile/export/tasks/
        /*        
        
        Формируется только 10 задач от пользователя, потовыдает ошибку
        те старые задачи нужно удалять
        https://mdlp.crpt.ru/#/app/profile/export/tasks/
        Payload 
        {start_from: 0, count: 20, filter: {}}
        

        Response
        {
   "items":[
      {
         "task_id":"5ea51a4c-9208-418e-8a83-e2035a99894c",
         "task_type":"REMAINING_MEDICINES",
         "create_date":"2022-08-25T19:47:55.588259Z",
         "filter_parameters":"{\"filters\":{\"gtin\":\"15000158071022\",\"utilization_date_start\":\"2022-08-25\",\"utilization_date_end\":\"2022-08-25\"},\"fields\":[\"gtin\",\"batch\",\"exp_date\",\"branch_id\",\"prod_name\",\"federal_subject_name\",\"city\",\"area\",\"inn\",\"owner\",\"packing_inn\",\"emitent\",\"cnt\",\"update_date\"],\"description\":\"[{\\\"title\\\":\\\"GTIN\\\",\\\"value\\\":\\\"15000158071022\\\"},{\\\"title\\\":\\\"Дата нанесения\\\",\\\"value\\\":\\\"25.08.2022\\\"},{\\\"title\\\":\\\"Дата нанесения\\\",\\\"value\\\":\\\"25.08.2022\\\"}]\"}",
         "progress":"0/0",
         "task_status":"FAILED",
         "reason":"По указанным параметрам не найдено данных."
      },
      {
         "task_id":"6f708970-3209-4da6-adc6-ea39934554e0",
         "task_type":"REMAINING_MEDICINES",
         "create_date":"2022-08-25T19:35:58.777482Z",
         "filter_parameters":"{\"filters\":{\"gtin\":\"05000158068025\",\"utilization_date_start\":\"2022-08-25\",\"utilization_date_end\":\"2022-08-25\"},\"fields\":[\"gtin\",\"batch\",\"exp_date\",\"branch_id\",\"prod_name\",\"federal_subject_name\",\"city\",\"area\",\"inn\",\"owner\",\"packing_inn\",\"emitent\",\"cnt\",\"update_date\"],\"description\":\"[{\\\"title\\\":\\\"GTIN\\\",\\\"value\\\":\\\"05000158068025\\\"},{\\\"title\\\":\\\"Дата нанесения\\\",\\\"value\\\":\\\"25.08.2022\\\"},{\\\"title\\\":\\\"Дата нанесения\\\",\\\"value\\\":\\\"25.08.2022\\\"}]\"}",
         "progress":"0/0",
         "task_status":"FAILED",
         "reason":"По указанным параметрам не найдено данных."
      },
      {
         "task_id":"604d7426-d5f6-45f1-92d9-554de9b7d5df",
         "task_type":"REMAINING_MEDICINES",
         "create_date":"2022-08-12T02:19:52.565164Z",
         "filter_parameters":"{\"filters\":{\"gtin\":\"18901148006024\",\"batches\":[\"B2K91565QYFAS\"]},\"fields\":[\"gtin\",\"batch\",\"exp_date\",\"branch_id\",\"prod_name\",\"federal_subject_name\",\"city\",\"area\",\"inn\",\"owner\",\"packing_inn\",\"emitent\",\"cnt\",\"update_date\"],\"description\":\"[{\\\"title\\\":\\\"GTIN\\\",\\\"value\\\":\\\"18901148006024\\\"},{\\\"title\\\":\\\"Серия\\\",\\\"value\\\":\\\"B2K91565QYFAS\\\"}]\"}",
         "progress":"0/0",
         "task_status":"FAILED",
         "reason":"По указанным параметрам не найдено данных."
      },
      {
         "task_id":"c1e2652f-4c3d-4e29-9184-818fbc517415",
         "task_type":"WRITE_OFF_MEDICATIONS",
         "create_date":"2022-07-17T21:01:50.666497Z",
         "filter_parameters":"{\"filters\":{\"sys_id\":\"00000000173611\",\"last_tracing_op_date_to\":\"2022-04-19\"},\"fields\":[\"gtin\",\"batch\",\"sell_name\",\"sgtin\",\"status\",\"pack3_id\",\"sys_id\",\"last_tracing_op_date\"],\"description\":\"[{\\\"title\\\":\\\"Идентификатор МД\\\",\\\"value\\\":\\\"00000000173611 - 683006, Камчатский край, г. Петропавловск-Камчатский, проспект Победы, д 21\\\"},{\\\"title\\\":\\\"Дата регистрации последней операции\\\",\\\"value\\\":\\\"по 19.04.2022\\\"}]\"}",
         "progress":"4376/4376",
         "task_status":"COMPLETED"
      },
      {
         "task_id":"8dde0f34-29ea-4052-982a-70dc032f9bbc",
         "task_type":"WRITE_OFF_MEDICATIONS",
         "create_date":"2022-07-17T21:01:20.502868Z",
         "filter_parameters":"{\"filters\":{\"sys_id\":\"00000000173610\",\"last_tracing_op_date_to\":\"2022-04-19\"},\"fields\":[\"gtin\",\"batch\",\"sell_name\",\"sgtin\",\"status\",\"pack3_id\",\"sys_id\",\"last_tracing_op_date\"],\"description\":\"[{\\\"title\\\":\\\"Идентификатор МД\\\",\\\"value\\\":\\\"00000000173610 - 684000, Камчатский край, Елизовский район, г. Елизово, ул. Ленина, д. 15, помещение 36\\\"},{\\\"title\\\":\\\"Дата регистрации последней операции\\\",\\\"value\\\":\\\"по 19.04.2022\\\"}]\"}",
         "progress":"2713/2713",
         "task_status":"COMPLETED"
      }
   ],
   "total":5
}

        */



        /// <summary>
        /// 8.2.2. Метод для поиска информации о местах ответственного хранения по фильтру
        /// </summary>
        /// <param name="filter">Фильтр для поиска мест осуществления деятельности</param>
        /// <param name="startFrom">Индекс первой записи в списке возвращаемых мест</param>
        /// <param name="count">Количество записей в списке возвращаемых мест</param>
        /// <returns>Список мест ответственного хранения</returns>
        /*
         public EntriesResponse<WarehouseEntry> GetWarehouses(WarehouseFilter filter, int startFrom, int count)
        {
            RequestRate(0.5); // 61

            return Post<EntriesResponse<WarehouseEntry>>("reestr/warehouses/filter", new
            {
                filter = filter ?? new WarehouseFilter(),
                start_from = startFrom,
                count = count,
            });
        }
        */
        /// <summary>
        /// 8.2.3. Получение информации о конкретном месте ответственного хранения
        /// </summary>
        /*
        public GetWarehouseResponse GetWarehouse(string warehouseId)
        {
            RequestRate(0.5); // 62

            return Get<GetWarehouseResponse>("reestr/warehouses/{warehouse_id}", new[]
            {
                new Parameter("warehouse_id", warehouseId, ParameterType.UrlSegment)
            });
        }
        */

    }
}