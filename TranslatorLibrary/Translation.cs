using System;

/* Поимер ответа от Яндекса:
 * <?xml version="1.0" encoding="utf-8"?>
 * <Translation code="200" lang="en-ru">
 *   <text>Здравствуй, Мир!</text>
 * </Translation>
 */

namespace TranslatorLibrary
{
    class Translation
    {
        public int code { get; set; }
        public string lang { get; set; }
        public string Text { get; set; }
    }
}
