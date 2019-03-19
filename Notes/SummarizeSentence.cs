using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notes
{
    public class SummarizeSentence
    {

        public SummarizeSentence()
        {

        }

        public bool Include { get; set; }
        public int Paragraph { get; set; }
        public int SentenceNo { get; set; }
        public string Sentence { get; set; }
    }
}