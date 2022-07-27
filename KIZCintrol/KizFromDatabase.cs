using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace KIZCintrol
{
    internal class KizFromDatabase
    {
    public List<Kiz> kiz = new List<Kiz>();
    public KizFromDatabase(string department)
        {

            var parameters = new { dep = department};
            string sqlKizFromDB = @"select distinct
sell_name =  GOODS.NAME ,
gtin=KIZ.GTIN, 
batch = '',
sgtin = GTIN_SGTIN,
--KIZ_ITEM.ID_LOT_GLOBAL , 
sys_id = CONTRACTOR.KIZ_CODE ,
SKLAD = STORE.NAME ,
APTEKA = CONTRACTOR.NAME,
status = KIZ.STATE 
 from KIZ, KIZ_ITEM, LOT, 
 (
 select ID_KIZ_GLOBAL, MIN( REMAIN) as REMAIN_QTY
 from KIZ_2_DOCUMENT_ITEM
group by ID_KIZ_GLOBAL
 ) REMAINS , CONTRACTOR, STORE, GOODS
where KIZ.ID_KIZ_GLOBAL = KIZ_ITEM.ID_KIZ_GLOBAL
and lot.ID_LOT_GLOBAL = KIZ_ITEM.ID_LOT_GLOBAL
and REMAINS.ID_KIZ_GLOBAL = KIZ.ID_KIZ_GLOBAL
and LOT.ID_STORE = STORE.ID_STORE 
and CONTRACTOR.ID_CONTRACTOR = STORE.ID_CONTRACTOR 
and KIZ.STATE = 'EXIT'
and LOT.ID_GOODS = GOODS.ID_GOODS 
and CONTRACTOR.KIZ_CODE = @dep
";

            kiz = Program.farmaConnection.Query<Kiz>(sqlKizFromDB, parameters).ToList();
        }
        
    
    }
}
