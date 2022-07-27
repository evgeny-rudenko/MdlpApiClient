using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace KIZCintrol
{
    
    /// <summary>
    /// Список отделов 
    /// </summary>
    class Store
    {
        public int idStore;
        public string nameStore;
        public string mdlpCode;
        public string departmentCode;
    }

    /// <summary>
    /// список подразделений/аптек
    /// </summary>
    class Department
    {
        public int idDepartment;
        public string nameDepartment;
        public string mdlpCode;
    }

/// <summary>
/// автоматическое заполнение по данным из ефарма списка аптек и складов
/// </summary>
    internal class StoreEfarma
    {
        
        public List<Store> Stores = new List<Store>();                  // склады
        public List<Department> Departments = new List<Department>();   // аптеки 
        public StoreEfarma()
        {
            string sqlStores = @"select 
idStore = ID_STORE ,
nameStore = store.NAME ,
mdlpCode = c.KIZ_CODE ,
departmentCode  = c.ID_CONTRACTOR 
from store , CONTRACTOR c 
where store.ID_CONTRACTOR = c.ID_CONTRACTOR 
";
            Stores = Program.farmaConnection.Query<Store>(sqlStores).ToList();

            string sqlDepartment = @"select 
idDepartment = c.ID_CONTRACTOR,
nameDepartment = c.NAME,
mdlpCode = c.KIZ_CODE 
from CONTRACTOR c 
where c.KIZ_CODE is not NULL 
and c.KIZ_CODE !=''
and name like 'ООО%здоровье%'";
            
            Departments = Program.farmaConnection.Query<Department>(sqlDepartment).ToList();
        }

    }
    
}
