﻿namespace MdlpApiClient
{
    using DataContracts;
    using RestSharp;

    /// <remarks>
    /// Strongly typed REST API methods. Chapter 6: user accounts.
    /// </remarks>
    partial class MdlpClient
    {
        /// <summary>
        /// 6.1.1. Метод для регистрации учетной системы
        /// </summary>
        /// <param name="sysId">Идентификатор субъекта обращения в «ИС "Маркировка". МДЛП»</param>
        /// <param name="name">Название учетной системы</param>
        /// <returns>Идентификатор учетной системы</returns>
        public AccountSystem RegisterAccountSystem(string sysId, string name)
        {
            RequestRate(0.5); // 14

            var accSystem = Post<AccountSystem>("registration/accounting_system", new
            {
                sys_id = sysId,
                name = name,
            });

            // при регистрации поле Name не возвращается
            accSystem.Name = name;
            return accSystem;
        }

        /// <summary>
        /// 6.1.2. Метод для регистрации пользователей (для резидентов страны)
        /// </summary>
        /// <param name="sysId">Идентификатор субъекта обращения в «ИС "Маркировка". МДЛП»</param>
        /// <param name="user">Свойства пользователя-резидента</param>
        /// <returns>Идентификатор пользователя</returns>
        public string RegisterUser(string sysId, ResidentUser user)
        {
            RequestRate(0.5); // 15

            var response = Post<RegisterUserResponse>("registration/user_resident", new
            {
                sys_id = sysId,
                first_name = user.FirstName,
                last_name = user.LastName,
                middle_name = user.MiddleName,
                public_cert = user.PublicCertificate,
                email = user.Email,
                phone = user.Phone,
                position = user.Position,
            });

            return response.UserID;
        }

        /// <summary>
        /// 6.1.3. Метод для регистрации пользователей (для нерезидентов страны)
        /// </summary>
        /// <param name="sysId">Идентификатор субъекта обращения в «ИС "Маркировка". МДЛП»</param>
        /// <param name="user">Свойства пользователя-нерезидента</param>
        /// <returns>Идентификатор пользователя</returns>
        public string RegisterUser(string sysId, NonResidentUser user)
        {
            RequestRate(0.5); // 16

            var response = Post<RegisterUserResponse>("registration/user_nonresident", new
            {
                sys_id = sysId,
                first_name = user.FirstName,
                last_name = user.LastName,
                middle_name = user.MiddleName,
                password = user.Password,
                email = user.Email,
                phone = user.Phone,
                position = user.Position,
            });

            return response.UserID;
        }

        /// <summary>
        /// 6.1.4. Метод для получения информации о пользователе
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns>Свойства пользователя</returns>
        public GroupedUser GetUserInfo(string userId)
        {
            RequestRate(0.5); // 17

            return Get<GetUserResponse>("users/{user_id}", new[]
            {
                new Parameter("user_id", userId, ParameterType.UrlSegment),
            })
            .User;
        }

        /// <summary>
        /// 6.1.5. Метод для получения информации о языке текущего пользователя
        /// </summary>
        /// <returns>Свойства пользователя</returns>
        public string GetCurrentLanguage()
        {
            return Get<UserPreferences>("users/current/preferences").Language;
        }

        /// <summary>
        /// 6.1.6. Метод для изменения данных профиля пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="user">Свойства профиля пользователя</param>
        public void UpdateUserProfile(string userId, UserEditProfileEntry user)
        {
            RequestRate(0.5); // 18

            Put("users/{user_id}", new
            {
                user_id = userId,
                user = user,
            },
            new[]
            {
                new Parameter("user_id", userId, ParameterType.UrlSegment),
            });
        }

        /// <summary>
        /// 6.1.7. Метод для получения информации о текущем пользователе
        /// </summary>
        /// <returns>Свойства пользователя</returns>
        public GroupedUser GetCurrentUserInfo()
        {
            RequestRate(0.5); // 19

            return Get<GetUserResponse>("users/current").User;
        }

        /// <summary>
        /// 6.1.8. Метод для изменения языка в профиле текущего пользователя
        /// </summary>
        /// <param name="language">Язык интерфейса пользователя (ru/en)</param>
        public void SetCurrentLanguage(string language)
        {
            Put("users/current/preferences", new
            {
                language = language,
            });
        }

        /// <summary>
        /// 6.1.9. Метод для получения информации о зарегистрированных сертификатах текущего пользователя
        /// </summary>
        /// <param name="startFrom">Индекс первой записи в списке возвращаемых сертификатов</param>
        /// <param name="count">Количество записей в списке возвращаемых сертификатов</param>
        /// <returns>Список сертификатов</returns>
        public CertificatesResponse<UserCertificate> GetCurrentCertificates(int startFrom, int count)
        {
            RequestRate(0.5); // 20

            return Post<CertificatesResponse<UserCertificate>>("users/current/keys", new
            {
                start_from = startFrom,
                count = count,
            });
        }

        /// <summary>
        /// 6.1.10. Метод для получения информации о зарегистрированных сертификатах пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="startFrom">Индекс первой записи в списке возвращаемых сертификатов</param>
        /// <param name="count">Количество записей в списке возвращаемых сертификатов</param>
        /// <returns>Список сертификатов</returns>
        public CertificatesResponse<UserCertificate> GetUserCertificates(string userId, int startFrom, int count)
        {
            RequestRate(0.5); // 21

            return Post<CertificatesResponse<UserCertificate>>("users/{user_id}/keys", new
            {
                start_from = startFrom,
                count = count,
            },
            new[]
            {
                new Parameter("user_id", userId, ParameterType.UrlSegment),
            });
        }

        /// <summary>
        /// 6.1.11. Метод для получения информации об УС
        /// </summary>
        /// <param name="accountSystemId">Уникальный идентификатор УС</param>
        /// <returns>Свойства УС</returns>
        public AccountSystem GetAccountSystem(string accountSystemId)
        {
            RequestRate(0.5); // 22

            return Get<GetAccountSystemResponse>("account_systems/{account_system_id}", new[]
            {
                new Parameter("account_system_id", accountSystemId, ParameterType.UrlSegment),
            })
            .AccountSystem;
        }

        /// <summary>
        /// 6.2.1. Метод для получения кода аутентификации
        /// </summary>
        /// <remarks>
        /// Это внутренний метод, он не является частью публичного API.
        /// Он используется классами-наследниками <see cref="CredentialsBase"/>.
        /// </remarks>
        /// <param name="clientId">Идентификатор клиента</param>
        /// <param name="clientSecret">Секретный ключ клиента</param>
        /// <param name="userId">Уникальный идентификатор пользователя</param>
        /// <param name="authType">Тип аутентификации, см. <see cref="AuthTypeEnum"/>.</param>
        /// <returns>Код аутентификации для получения ключа сессии</returns>
        internal string Authenticate(string clientId, string clientSecret, string userId, string authType)
        {
            RequestRate(1); // 23

            var auth = Post<AuthResponse>("auth", new
            {
                client_id = clientId,
                client_secret = clientSecret,
                user_id = userId,
                auth_type = authType,
            });

            return auth.Code;
        }

        /// <summary>
        /// 6.2.2. Метод для получения ключа сессии
        /// </summary>
        /// <remarks>
        /// Это внутренний метод, он не является частью публичного API.
        /// Он используется классами-наследниками <see cref="CredentialsBase"/>.
        /// </remarks>
        /// <param name="authCode">Код аутентификации для получения ключа сессии</param>
        /// <param name="signature">Открепленная подпись кода для аутентификации типа SIGNED_CODE</param>
        /// <param name="password">Пароль пользователя для аутентификации типа PASSWORD</param>
        /// <returns>Ключ сессии <see cref="AuthToken"/>.</returns>
        internal AuthToken GetToken(string authCode, string signature = null, string password = null)
        {
            RequestRate(1); // 24

            var result = Post<AuthToken>("token", new
            {
                code = authCode,
                signature = signature,
                password = password,
            });

            // if Post didn't throw, then we're authenticated
            IsAuthenticated = true;
            return result;
        }

        /// <summary>
        /// 6.2.3. Метод для выхода из системы
        /// </summary>
        internal void Logout()
        {
            RequestRate(1); // 25

            Get("auth/logout");
            IsAuthenticated = false;
        }

        /// <summary>
        /// 6.3.1. Метод для удаления пользователей учетной системы
        /// </summary>
        /// <param name="userId">Уникальный идентификатор пользователя учетной системы</param>
        public void DeleteUser(string userId)
        {
            RequestRate(0.5); // 26

            Delete("users/{user_id}", null, new[]
            {
                new Parameter("user_id", userId, ParameterType.UrlSegment),
            });
        }

        /// <summary>
        /// 6.3.2. Метод для удаления учетной системы
        /// </summary>
        /// <param name="accountSystemId">Уникальный идентификатор учетной системы</param>
        public void DeleteAccountSystem(string accountSystemId)
        {
            RequestRate(0.5); // 27

            Delete("account_systems/{account_system_id}", null, new[]
            {
                new Parameter("account_system_id", accountSystemId, ParameterType.UrlSegment),
            });
        }

        /// <summary>
        /// 6.4.1. Метод для добавления ЭП пользователя (для резидентов)
        /// </summary>
        /// <remarks>
        /// Необходимо использовать публичный сертификат, а не публичный ключ.
        /// </remarks>
        /// <param name="userId">Уникальный идентификатор пользователя</param>
        /// <param name="certificate">Публичный сертификат пользователя</param>
        public void AddUserCertificate(string userId, string certificate)
        {
            RequestRate(0.5); // 28

            Post("users/{user_id}/add_key", new
            {
                public_cert = certificate
            },
            new[]
            {
                new Parameter("user_id", userId, ParameterType.UrlSegment),
            });
        }

        /// <summary>
        /// 6.4.2. Метод для удаления ЭП пользователя (для резидентов)
        /// </summary>
        /// <remarks>
        /// Необходимо использовать публичный сертификат, а не публичный ключ.
        /// Допускается также использование серийного номера сертификата
        /// в десятичной форме или отпечатка сертификата.
        /// </remarks>
        /// <param name="userId">Уникальный идентификатор пользователя</param>
        /// <param name="certificate">Публичный сертификат пользователя</param>
        public void DeleteUserCertificate(string userId, string certificate)
        {
            RequestRate(0.5); // 29

            Delete("users/{user_id}/delete_key", new
            {
                public_cert = certificate
            },
            new[]
            {
                new Parameter("user_id", userId, ParameterType.UrlSegment),
            });
        }

        /// <summary>
        /// 6.5.1. Метод для изменения пароля пользователя (для нерезидентов)
        /// </summary>
        /// <param name="userId">Уникальный идентификатор пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        public void ChangeUserPassword(string userId, string password)
        {
            RequestRate(0.5); // 30

            Post("users/{user_id}/change_password", new
            {
                password = password
            },
            new[]
            {
                new Parameter("user_id", userId, ParameterType.UrlSegment),
            });
        }

        /// <summary>
        /// 6.6.1. Метод для получения информации о существующих правах
        /// </summary>
        public RightsInfo[] GetRights()
        {
            RequestRate(0.5); // 31

            return Get<GetRightsResponse<RightsInfo>>("rights/about").Rights;
        }

        /// <summary>
        /// 6.6.2. Метод для получения информации о правах текущего пользователя
        /// </summary>
        public string[] GetCurrentRights()
        {
            RequestRate(0.5); // 32

            return Get<GetRightsResponse<string>>("rights/current").Rights;
        }

        /// <summary>
        /// 6.6.3. Метод для создания группы прав пользователей
        /// </summary>
        /// <param name="groupName">Имя группы</param>
        /// <param name="rights">Права пользователей, принадлежащих этой группе (см. <see cref="RightsEnum"/>)</param>
        /// <returns>Уникальный идентификатор группы</returns>
        public string CreateRightsGroup(string groupName, string[] rights)
        {
            RequestRate(0.5); // 33

            return Post<CreateRightsGroupResponse>("rights/create_group", new
            {
                group_name = groupName,
                rights = rights
            })
            .GroupID;
        }

        /// <summary>
        /// 6.6.4. Метод для получения информации о группе прав пользователей
        /// </summary>
        /// <param name="groupId">Уникальный идентификатор группы</param>
        /// <returns><see cref="Group"/></returns>
        public Group GetRightsGroup(string groupId)
        {
            RequestRate(0.5); // 35

            return Get<GetGroupResponse>("rights/{group_id}", new[]
            {
                new Parameter("group_id", groupId, ParameterType.UrlSegment),
            })
            .Group;
        }

        /// <summary>
        /// 6.6.5. Метод для получения информации о пользователях группы
        /// </summary>
        /// <param name="groupId">Уникальный идентификатор группы</param>
        /// <returns>Список объектов <see cref="User"/></returns>
        public User[] GetGroupUsers(string groupId)
        {
            RequestRate(0.5); // 34

            return Get<GetGroupUsersResponse>("rights/{group_id}/users", new[]
            {
                new Parameter("group_id", groupId, ParameterType.UrlSegment),
            })
            .Users;
        }

        /// <summary>
        /// 6.6.6. Метод для изменения группы прав пользователей
        /// </summary>
        /// <param name="groupId">Уникальный идентификатор группы прав пользователей</param>
        /// <param name="groupChange">Объект <see cref="Group"/></param>
        public void UpdateRightsGroup(string groupId, Group groupChange)
        {
            RequestRate(0.5); // 36

            Put("rights/{group_id}", new
            {
                group_change = groupChange
            },
            new[]
            {
                new Parameter("group_id", groupId, ParameterType.UrlSegment),
            });
        }

        /// <summary>
        /// 6.6.7. Метод для удаления группы прав пользователей
        /// </summary>
        /// <param name="groupId">Уникальный идентификатор группы прав пользователей</param>
        public void DeleteRightsGroup(string groupId)
        {
            RequestRate(0.5); // 37

            Delete("rights/{group_id}", null, new[]
            {
                new Parameter("group_id", groupId, ParameterType.UrlSegment),
            });
        }

        /// <summary>
        /// 6.6.8. Метод для добавления пользователя в группу прав пользователей
        /// </summary>
        /// <param name="userId">Уникальный идентификатор пользователя</param>
        /// <param name="groupId">Уникальный идентификатор группы прав пользователей</param>
        /// <returns>Уникальный идентификатор группы</returns>
        public void AddUserToRightsGroup(string userId, string groupId)
        {
            RequestRate(0.5); // 38

            Post("rights/{group_id}/user_add", new
            {
                user_id = userId
            },
            new[]
            {
                new Parameter("group_id", groupId, ParameterType.UrlSegment),
            });
        }

        /// <summary>
        /// 6.6.9. Метод для удаления пользователя из группы прав пользователей
        /// </summary>
        /// <param name="userId">Уникальный идентификатор пользователя</param>
        /// <param name="groupId">Уникальный идентификатор группы прав пользователей</param>
        public void DeleteUserFromRightsGroup(string userId, string groupId)
        {
            RequestRate(0.5); // 39

            Delete("rights/{group_id}/{user_id}", null, new[]
            {
                new Parameter("user_id", userId, ParameterType.UrlSegment),
                new Parameter("group_id", groupId, ParameterType.UrlSegment),
            });
        }

        /// <summary>
        /// 6.6.11. Метод для поиска списка групп прав пользователей по фильтру
        /// </summary>
        /// <param name="filter">Фильтр для поиска списка групп прав пользователей</param>
        /// <param name="startFrom">Индекс первой записи в списке групп прав пользователей </param>
        /// <param name="count">Количество записей в списке групп прав пользователей </param>
        /// <returns>Список групп прав пользователей </returns>
        public GroupsResponse<Group> GetRightsGroups(GroupFilter filter, int startFrom, int count)
        {
            RequestRate(0.5); // 41

            return Post<GroupsResponse<Group>>("rights/filter", new
            {
                filter = filter ?? new GroupFilter(),
                start_from = startFrom,
                count = count,
            });
        }

        /// <summary>
        /// 6.7.2. Метод для поиска зарегистрированных пользователей по фильтру
        /// </summary>
        /// <param name="filter">Фильтр для поиска списка зарегистрированных пользователей</param>
        /// <param name="startFrom">Индекс первой записи в списке зарегистрированных пользователей</param>
        /// <param name="count">Количество записей в списке зарегистрированных пользователей</param>
        /// <returns>Список зарегистрированных пользователей</returns>
        public UsersResponse<GroupedUser> GetUsers(UserFilter filter, int startFrom, int count)
        {
            RequestRate(0.5); // 43

            return Post<UsersResponse<GroupedUser>>("users/filter", new
            {
                filter = filter ?? new UserFilter(),
                start_from = startFrom,
                count = count,
            });
        }

        /// <summary>
        /// 6.8.2. Метод для поиска учетных систем по фильтру
        /// </summary>
        /// <param name="name">Имя для поиска учетных систем</param>
        /// <param name="startFrom">Индекс первой записи в списке учетных систем</param>
        /// <param name="count">Количество записей в списке учетных систем</param>
        /// <returns>Список учетных систем</returns>
        public AccountSystemsResponse<AccountSystem> GetAccountSystems(string name, int startFrom, int count)
        {
            RequestRate(0.5); // 45

            return Post<AccountSystemsResponse<AccountSystem>>("account_systems/filter", new
            {
                filter = new
                {
                    name = name
                },
                start_from = startFrom,
                count = count,
            });
        }
    }
}
