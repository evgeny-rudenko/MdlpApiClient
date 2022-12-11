using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdlpApiClient.DataContracts
{
    using System.Runtime.Serialization;
    [DataContract]
    public class TaskEntry
    {
        /// <summary>
        /// идентифкатор задачи экспорта
        /// </summary>
        [DataMember(Name = "task_id")]
        public string TaskId { get; set; }

        /// <summary>
        /// Тип задачи экспорта
        /// WRITE_OFF_MEDICATIONS - товары без движения
        /// REMAINING_MEDICINES - остатки товаров
        /// </summary>
        [DataMember(Name = "task_type")]
        public string TaskType { get; set; }

        /// <summary>
        /// Дата создания отчета
        /// </summary>
        [DataMember(Name = "create_date")]
        public string CreateDate { get; set; }

        /// <summary>
        /// Параметры фильтра
        /// </summary>
        [DataMember(Name = "filter_parameters")]
        public string FilterParameters { get; set; }

        
        /// <summary>
        /// выполнение отчета если 0/0 то ошибка или выгрузка не началась
        /// если например 1000/1000, то вероятнее всего можно загрузить результат
        /// </summary>
        [DataMember(Name = "progress")]
        public string Progress { get; set; }

        /// <summary>
        /// Статус выполнения :
        /// FAILED - выполнено с ошибкой
        /// COMPLETED - закончена обработка
        /// </summary>
        [DataMember(Name = "task_status")]
        public string TaskStatus { get; set; }



        #region  примеры JSON выдачи


        /*
         "task_id":"5ea51a4c-9208-418e-8a83-e2035a99894c",
         "task_type":"REMAINING_MEDICINES",
         "create_date":"2022-08-25T19:47:55.588259Z",
         "filter_parameters":"{\"filters\":{\"gtin\":\"15000158071022\",\"utilization_date_start\":\"2022-08-25\",\"utilization_date_end\":\"2022-08-25\"},\"fields\":[\"gtin\",\"batch\",\"exp_date\",\"branch_id\",\"prod_name\",\"federal_subject_name\",\"city\",\"area\",\"inn\",\"owner\",\"packing_inn\",\"emitent\",\"cnt\",\"update_date\"],\"description\":\"[{\\\"title\\\":\\\"GTIN\\\",\\\"value\\\":\\\"15000158071022\\\"},{\\\"title\\\":\\\"Дата нанесения\\\",\\\"value\\\":\\\"25.08.2022\\\"},{\\\"title\\\":\\\"Дата нанесения\\\",\\\"value\\\":\\\"25.08.2022\\\"}]\"}",
         "progress":"0/0",
         "task_status":"FAILED",
         "reason":"По указанным параметрам не найдено данных."


         "task_id":"8dde0f34-29ea-4052-982a-70dc032f9bbc",
         "task_type":"WRITE_OFF_MEDICATIONS",
         "create_date":"2022-07-17T21:01:20.502868Z",
         "filter_parameters":"{\"filters\":{\"sys_id\":\"00000000173610\",\"last_tracing_op_date_to\":\"2022-04-19\"},\"fields\":[\"gtin\",\"batch\",\"sell_name\",\"sgtin\",\"status\",\"pack3_id\",\"sys_id\",\"last_tracing_op_date\"],\"description\":\"[{\\\"title\\\":\\\"Идентификатор МД\\\",\\\"value\\\":\\\"00000000173610 - 684000, Камчатский край, Елизовский район, г. Елизово, ул. Ленина, д. 15, помещение 36\\\"},{\\\"title\\\":\\\"Дата регистрации последней операции\\\",\\\"value\\\":\\\"по 19.04.2022\\\"}]\"}",
         "progress":"2713/2713",
         "task_status":"COMPLETED"
         
         * */
        #endregion

    }
}
