﻿using System;
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
    public KizFromDatabase(string department, string goods_filter = "%")
        {

            // на всякий случай в запросе фильтр по чекам 
            // по хорошему нужно сделать проверку по всем базам
            var parameters = new { dep = department , gf = goods_filter};
            string sqlKizFromDB = @"select distinct
sell_name =  GOODS.NAME ,
gtin=KIZ.GTIN, 
batch = '',
sgtin = GTIN_SGTIN,
--KIZ_ITEM.ID_LOT_GLOBAL , 
sys_id = CONTRACTOR.KIZ_CODE ,
SKLAD = STORE.NAME ,
APTEKA = CONTRACTOR.NAME,
CHEQUE = (select  mnemocode from cheque where id_cheque_global = KIZ.ID_DOCUMENT_SUB),
internal_barcode = lot.internal_barcode,
status = KIZ.STATE 
 from KIZ, KIZ_ITEM, LOT, 
 (
 select ID_KIZ_GLOBAL, MIN( REMAIN) as REMAIN_QTY
 from KIZ_2_DOCUMENT_ITEM
group by ID_KIZ_GLOBAL
 ) REMAINS , CONTRACTOR, STORE, GOODS
where KIZ.ID_KIZ_GLOBAL = KIZ_ITEM.ID_KIZ_GLOBAL
and LOT.ID_STORE in (SELECT ID_STORE FROM STORE WHERE ID_CONTRACTOR = DBO.FN_CONST_CONTRACTOR_SELF())
and lot.ID_LOT_GLOBAL = KIZ_ITEM.ID_LOT_GLOBAL
and REMAINS.ID_KIZ_GLOBAL = KIZ.ID_KIZ_GLOBAL
and LOT.ID_STORE = STORE.ID_STORE 
and CONTRACTOR.ID_CONTRACTOR = STORE.ID_CONTRACTOR 
and KIZ.STATE = 'EXIT'
and KIZ.ID_TABLE_SUB=7 -- выбытие по чекам 
and LOT.ID_GOODS = GOODS.ID_GOODS 
and CONTRACTOR.KIZ_CODE = @dep
and GOODS.NAME like @gf
";

            kiz = Program.farmaConnection.Query<Kiz>(sqlKizFromDB, parameters).ToList();
        }
        
    
    }
}
