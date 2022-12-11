using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace Doc552ByGTIN
{
    internal class MDLPDoc552
    {
        /// <summary>
        /// Тип списания
        /// </summary>
        public enum withdrawal_type
        {
            ВыборочнКонтроль = 6,
            ФедерНаздор = 8,
            ФармЭкспертиза = 10,
            Недостача = 11,
            ДемонстрОбразцы = 12,
            СписаниеБезУничт = 13, // Использовать если срок годности уже истек 
            ПроизвБрак = 15,
            СписаниеРазукомпл = 16,
            ОтборДляКонтрКачества = 19,
            Хищение = 21,
            СписаниеСГ = 22,
            СписаниеИнв = 23 // полностью выглядит "Списание по отсутствии информации о приемке. В методичеке пишут что использовать при инвентаризации
                // не подходит для списания сроковых препаратов
        }

        private List<string> SGTINs = new List<string>();
        public XmlDocument XmlDoc = new XmlDocument();

        private XmlDocument ToXmlDocument(XDocument xDocument)
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
        public MDLPDoc552(List<string> sGTINs, withdrawal_type withdrawal_Type, string subject_id)
        {
            SGTINs = sGTINs ?? throw new ArgumentNullException(nameof(sGTINs));

            List<XElement> sGTINSXMLList = new List<XElement>();
            foreach (string s in sGTINs)
            {
                sGTINSXMLList.Add(new XElement("sgtin", s));
            }



            XDocument doc = new XDocument(
                new XElement("documents",
                    new XAttribute("version", "1.37"),
                    new XElement("withdrawal",
                    new XAttribute("action_id", "552"),
                    new XElement("subject_id", subject_id),
                    new XElement("operation_date", DateTime.Now.ToUniversalTime()),
                    new XElement("doc_num", DateTime.Now.Ticks.ToString()),
                    new XElement("doc_date", DateTime.Now.ToShortDateString()),
                    new XElement("withdrawal_type", ((int) withdrawal_Type).ToString()),
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
