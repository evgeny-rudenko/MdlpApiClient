using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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

        public MDLPDoc522(List<string> sGTINs, withdrawal_type withdrawal_Type, string subject_id)
        {
            SGTINs = sGTINs ?? throw new ArgumentNullException(nameof(sGTINs));
            XmlDeclaration xmlDeclaration = XmlDoc.CreateXmlDeclaration("1.0", "UTF-8", "yes" );
            XmlElement root = XmlDoc.DocumentElement;
            XmlDoc.InsertBefore(xmlDeclaration, root);
            XmlElement document_version = XmlDoc.CreateElement("1.37", "documents version");
            root.AppendChild ()

            /*
            //xml Decalration:
XmlDocument xmlDoc = new XmlDocument();
XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
XmlElement root = xmlDoc.DocumentElement;
xmlDoc.InsertBefore(xmlDeclaration, root);
// add body
XmlElement body = xmlDoc.CreateElement(string.Empty, "body", string.Empty);
xmlDoc.AppendChild(body);
XmlElement body = xmlDoc.CreateElement(string.Empty, "body", string.Empty);
xmlDoc.DocumentElement.AppendChild(body); //without DocumentElement ->ERR
                
            XmlNode keyNode = xmlDoc.CreateElement(entry.Key); //open TAB
                keyNode.InnerText = entry.Value;
                body.AppendChild(keyNode); //close TAB

                
                //(2) string.Empty makes cleaner code
        XmlElement element1 = doc.CreateElement( string.Empty, "body", string.Empty );
        doc.AppendChild( element1 );

        XmlElement element2 = doc.CreateElement( string.Empty, "level1", string.Empty );
        element1.AppendChild( element2 );

        XmlElement element3 = doc.CreateElement( string.Empty, "level2", string.Empty );
        XmlText text1 = doc.CreateTextNode( "text" );
        element3.AppendChild( text1 );
        element2.AppendChild( element3 );

        XmlElement element4 = doc.CreateElement( string.Empty, "level2", string.Empty );
        XmlText text2 = doc.CreateTextNode( "other text" );
        element4.AppendChild( text2 );
        element2.AppendChild( element4 );

        doc.Save( "D:\\document.xml" );
             */
        }

    }
}

/*
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
 */