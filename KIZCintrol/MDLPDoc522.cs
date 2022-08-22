using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace KIZCintrol
{
    internal class MDLPDoc522
    {
    
        public enum withdrawal_type
        {
            ВыборочнКонтроль =6,
            ФедерНаздор = 8,
            ФармЭкспертиза = 10,
            Недостача = 11,
            ДемонстрОбразцы = 12,
            СптсаниеБезУничт = 13,
            ПроизвБрак = 15,
            СписаниеРазукомпл = 16,
            ОтборДляКонтрКачества = 19,
            Хищение = 21,
            СписаниеСГ = 22,
            СписаниеИнв = 23 // полностью выглядит "Списание по отсутствии информации о приемке. В методичеке пишут что использовать при инвентаризации
        }
        
        private List<string> SGTINs = new List<string>();
        public XmlDocument XmlDoc = new XmlDocument();

        private XmlDocument ToXmlDocument( XDocument xDocument)
        {
            var xmlDocument = new XmlDocument();
            using (var reader = xDocument.CreateReader())
            {
                xmlDocument.Load(reader);
            }

            var xDeclaration = xDocument.Declaration;
            
            if (xDeclaration != null)
            {
                var xmlDeclaration = xmlDocument.CreateXmlDeclaration(
                    xDeclaration.Version,
                    xDeclaration.Encoding,
                    xDeclaration.Standalone
                 
                 );
                
                
                xmlDocument.InsertBefore(xmlDeclaration, xmlDocument.FirstChild);
            }

            

            xmlDocument.InsertBefore(xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", "yes"), xmlDocument.FirstChild);

            return xmlDocument;
        }
        public MDLPDoc522(List<string> sGTINs, withdrawal_type withdrawal_Type, string subject_id)
        {
            SGTINs = sGTINs ?? throw new ArgumentNullException(nameof(sGTINs));
            
            List<XElement> sGTINSXMLList = new List<XElement>();
            foreach (string s in sGTINs)
            {
                sGTINSXMLList.Add(new XElement("sgtin", s));
            }
            
            

            XDocument doc = new XDocument(
                new XElement ("documents",
                    new XAttribute ("version", "1.37"),
                    new XElement ("withdrawal",
                    new XAttribute  ("action_id", "552"),
                    new XElement ("subject_id", subject_id),
                    new XElement ("operation_date", DateTime.Now.ToUniversalTime()),
                    new XElement ("doc_date", DateTime.Now.ToShortDateString()),
                    new XElement("withdrawal_type", "23"),
                    new XElement("order_details",
                        
                        sGTINSXMLList

                        )
                    )
                
                
                )
                );

            XmlDoc = ToXmlDocument(doc);
         
        }

    }
}
#region Пример и результатформирования документа 522
/*
// Документ который формируется на сайте 
<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<documents version="1.37">
  <withdrawal action_id="552">
    <subject_id>00000000173610</subject_id>
    <operation_date>2022-07-27T22:01:27.155Z</operation_date>
    <doc_date>27.07.2022</doc_date>
    <withdrawal_type>23</withdrawal_type>
    <order_details>
      <sgtin>04601498006824JZM3XDJ9LAW0A</sgtin>
      <sgtin>04601498006824PB921XQ8LA30J</sgtin>
    </order_details>
  </withdrawal>
</documents>
 
/// результат работы программы 
<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<documents version="1.37">
  <withdrawal action_id="552">
    <subject_id>0000000</subject_id>
    <operation_date>2022-08-02T20:11:36.115597Z</operation_date>
    <operation_date>02.08.2022</operation_date>
    <withdrawal_type>23</withdrawal_type>
    <order_details>
      <sgtin>sgtin1</sgtin>
      <sgtin>sgtin2</sgtin>
      <sgtin>sgtin3</sgtin>
    </order_details>
  </withdrawal>
</documents>
*/
#endregion