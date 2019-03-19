using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notes
{
    public class PlainText : Text
    {

        public PlainText()
            : base()
        {

        }

        public string TheAlteredText { get; set; }

        public void QuickClean()
        {
            char Tab;

            // First up ")." is the preferred end of a sentence not ".)" etc

            this.TheAlteredText = this.TheText;
            this.TheAlteredText.Replace(".)", ").");
            this.TheAlteredText.Replace("?)", ")?");
            this.TheAlteredText.Replace("!)", ")!");
            this.TheAlteredText.Replace(".}", "}.");
            this.TheAlteredText.Replace("?}", "}?");
            this.TheAlteredText.Replace("!}", "}!");
            this.TheAlteredText.Replace(".]", "].");
            this.TheAlteredText.Replace("?]", "]?");
            this.TheAlteredText.Replace("!]", "]!");

            // Replace Tabs with spaces

            Tab = (Char)9;
            this.TheAlteredText.Replace(Tab.ToString(), " ");
        }
    }
}