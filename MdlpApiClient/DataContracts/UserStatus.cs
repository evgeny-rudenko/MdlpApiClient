﻿namespace MdlpApiClient.DataContracts
{
    /// <summary>
    /// 4.15. Список статусов пользователя (UserStatus)
    /// </summary>
    public class UserStatus
    {
        /// <summary>
        /// Активен.
        /// </summary>
        public const string ACTIVE = "ACTIVE";

        /// <summary>
        /// Заблокирован.
        /// </summary>
        public const string BLOCKED = "BLOCKED";

        /// <summary>
        /// Удален.
        /// </summary>
        public const string DELETED = "DELETED";
    }
}