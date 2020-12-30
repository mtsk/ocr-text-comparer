using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrTextComparer
{
    internal static class TesLanguages
    {
        public class Language
        {
            public string LangCode { get; set; }
            public string LangName { get; set; }
        }

        public static Language[] Languages = new Language[]
        {
            new Language()
            {
                LangCode = "eng",
                LangName = "English"
            },
            //new Language()
            //{
            //    LangCode = "bul",
            //    LangName = "Bulgarian"
            //},
            //new Language()
            //{
            //    LangCode = "ces",
            //    LangName = "Czech"
            //},
            //new Language()
            //{
            //    LangCode = "deu",
            //    LangName = "German"
            //},
            //new Language()
            //{
            //    LangCode = "est",
            //    LangName = "Estonian"
            //},
            //new Language()
            //{
            //    LangCode = "hrv",
            //    LangName = "Croatian"
            //},
            //new Language()
            //{
            //    LangCode = "hun",
            //    LangName = "Hungarian"
            //},
            //new Language()
            //{
            //    LangCode = "lav",
            //    LangName = "Latvian"
            //},
            //new Language()
            //{
            //    LangCode = "lit",
            //    LangName = "Lithuanian"
            //},
            //new Language()
            //{
            //    LangCode = "ron",
            //    LangName = "Romanian"
            //},
            //new Language()
            //{
            //    LangCode = "slk",
            //    LangName = "Slovakian"
            //},
            //new Language()
            //{
            //    LangCode = "srp",
            //    LangName = "Serbian"
            //},
            //new Language()
            //{
            //    LangCode = "hrv",
            //    LangName = "Croatian"
            //},
            //new Language()
            //{
            //    LangCode = "ukr",
            //    LangName = "Ukrainian"
            //},
            //new Language()
            //{
            //    LangCode = "slv",
            //    LangName = "Slovenian"
            //},
            //new Language()
            //{
            //    LangCode = "rus",
            ////    LangName = "Russian"
            //},
            //new Language()
            //{
            //    LangCode = "kat",
            //    LangName = "Georgian"
            //},
            //new Language()
            //{
            //    LangCode = "bos",
            //    LangName = "Bosnian"
            //}
        };
    }
}
