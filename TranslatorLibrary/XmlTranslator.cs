using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Net;
using System.IO;

namespace TranslatorLibrary
{
    public class XmlTranslator : ITranslator
    {
        const string KeyFileName = "APIKey.txt";

        string GetAPIKey()
        {
            return File.ReadAllText(KeyFileName);
        }

        //https://translate.yandex.net/api/v1.5/tr/translate
        //         ? [key=<API-ключ>]
        //         & [text=<переводимый текст>]
        //         & [lang=<направление перевода>]
        //         & [format=<формат текста>]
        //         & [options=<опции перевода>]
        string GetTranslateRequest(string text, string toLanguage, string fromLanguage = "")
        {
            return string.Format("https://translate.yandex.net/api/v1.5/tr/translate?key={0}&text={1}&lang={2}",
                GetAPIKey(),
                text,
                string.IsNullOrWhiteSpace(fromLanguage) ? toLanguage : fromLanguage + "-" + toLanguage);
        }

        public string Translate(string text, string toLanguage, string fromLanguage = "")
        {
            WebRequest request = WebRequest.Create(GetTranslateRequest(text, toLanguage, fromLanguage));
            WebResponse response = request.GetResponse();
            using (Stream fs = response.GetResponseStream())
            {
                 XmlSerializer serializer = new XmlSerializer(typeof(Translation));
                 Translation translation = serializer.Deserialize(fs) as Translation;
                 return translation.Text;
           }

        }
    }
}
