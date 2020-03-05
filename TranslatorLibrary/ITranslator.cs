using System;
using System.Collections.Generic;
using System.Text;

namespace TranslatorLibrary
{
    public interface ITranslator
    {
        string Translate(string text, string tolanguage, string fromlanguage = "");
    }
}
