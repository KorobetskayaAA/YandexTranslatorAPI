using System;
using System.Xml.Serialization;

/* Поимер ответа от Яндекса:
 * <?xml version="1.0" encoding="utf-8"?>
 * <Translation code="200" lang="en-ru">
 *   <text>Здравствуй, Мир!</text>
 * </Translation>
 */

namespace TranslatorLibrary
{
    public class Translation
    {
        [XmlAttribute]
        public string code { get; set; }
        [XmlAttribute]
        public string lang { get; set; }
        public string text { get; set; }
    }
}
