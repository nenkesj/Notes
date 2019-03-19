using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Notes.Tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void AllBlanks_BlankCharactersOnly_True()
        {
            // Arrange
            Text txt = new Text();
            // Act
            bool result = txt.AllBlanks("           ");
            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void AllBlanks_NonBlank_False()
        {
            // Arrange
            Text txt = new Text();
            // Act
            bool result = txt.AllBlanks(" a         ");
            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void AllBlanks_EmptyString_False()
        {
            // Arrange
            Text txt = new Text();
            // Act
            bool result = txt.AllBlanks("");
            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void AllBlanks_SingleNonBlankChar_False()
        {
            // Arrange
            Text txt = new Text();
            // Act
            bool result = txt.AllBlanks("a");
            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void AllBlanks_SingleBlankChar_False()
        {
            // Arrange
            Text txt = new Text();
            // Act
            bool result = txt.AllBlanks(" ");
            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void LastNonBlankChar_SemiColon_True()
        {
            // Arrange
            Text txt = new Text();
            // Act
            char result = txt.lastNonBlankChar("   NewBook.Author = 'John Paul Mueller';\r\n");
            //Assert
            Assert.AreEqual(';', result);
        }

        [TestMethod]
        public void WheresNextEndOfLine_EmptyString_minusone()
        {
            // Arrange
            Text txt = new Text();
            // Act
            int result = txt.WheresNextEndOfLine("");
            //Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void WheresNextEndOfLine_CRLFOnly_one()
        {
            // Arrange
            Text txt = new Text();
            // Act
            int result = txt.WheresNextEndOfLine("\r\n");
            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void WheresNextEndOfLine_LFAt4_four()
        {
            // Arrange
            Text txt = new Text();
            // Act
            int result = txt.WheresNextEndOfLine("012\r\n5678\r\n12345\r\n");
            //Assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void WheresNextEndOfLine_NoLF_four()
        {
            // Arrange
            Text txt = new Text();
            // Act
            int result = txt.WheresNextEndOfLine("01234");
            //Assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void AnalyseWord_WordEndsWithDelimiter_True()
        {
            // Arrange
            bool WordEndsWithDelimiter, WordEndsWithFullStop, WordIsAInteger, WordIsAHexNumber, WordAllCapitals;
            Text txt = new Text();
            // Act
            txt.AnalyseWord("Hello:", out WordEndsWithDelimiter, out WordEndsWithFullStop, out WordIsAInteger, out WordIsAHexNumber, out WordAllCapitals);
            //Assert
            Assert.AreEqual(true, WordEndsWithDelimiter);
        }

        [TestMethod]
        public void AnalyseWord_WordEndsWithFullStop_True()
        {
            // Arrange
            bool WordEndsWithDelimiter, WordEndsWithFullStop, WordIsAInteger, WordIsAHexNumber, WordAllCapitals;
            Text txt = new Text();
            // Act
            txt.AnalyseWord("Hello.", out WordEndsWithDelimiter, out WordEndsWithFullStop, out WordIsAInteger, out WordIsAHexNumber, out WordAllCapitals);
            //Assert
            Assert.AreEqual(true, WordEndsWithFullStop);
        }

        [TestMethod]
        public void AnalyseWord_WordIsAInteger_True()
        {
            // Arrange
            bool WordEndsWithDelimiter, WordEndsWithFullStop, WordIsAInteger, WordIsAHexNumber, WordAllCapitals;
            Text txt = new Text();
            // Act
            txt.AnalyseWord("12345", out WordEndsWithDelimiter, out WordEndsWithFullStop, out WordIsAInteger, out WordIsAHexNumber, out WordAllCapitals);
            //Assert
            Assert.AreEqual(true, WordIsAInteger);
        }

        [TestMethod]
        public void AnalyseWord_WordIsAHexNumber_True()
        {
            // Arrange
            bool WordEndsWithDelimiter, WordEndsWithFullStop, WordIsAInteger, WordIsAHexNumber, WordAllCapitals;
            Text txt = new Text();
            // Act
            txt.AnalyseWord("2E45F", out WordEndsWithDelimiter, out WordEndsWithFullStop, out WordIsAInteger, out WordIsAHexNumber, out WordAllCapitals);
            //Assert
            Assert.AreEqual(true, WordIsAHexNumber);
        }

        [TestMethod]
        public void AnalyseWord_WordAllCapitals_True()
        {
            // Arrange
            bool WordEndsWithDelimiter, WordEndsWithFullStop, WordIsAInteger, WordIsAHexNumber, WordAllCapitals;
            Text txt = new Text();
            // Act
            txt.AnalyseWord("HELLO", out WordEndsWithDelimiter, out WordEndsWithFullStop, out WordIsAInteger, out WordIsAHexNumber, out WordAllCapitals);
            //Assert
            Assert.AreEqual(true, WordAllCapitals);
        }

        [TestMethod]
        public void AnalyseWord_WordEndsWithDelimiter_False()
        {
            // Arrange
            bool WordEndsWithDelimiter, WordEndsWithFullStop, WordIsAInteger, WordIsAHexNumber, WordAllCapitals;
            Text txt = new Text();
            // Act
            txt.AnalyseWord("Hello", out WordEndsWithDelimiter, out WordEndsWithFullStop, out WordIsAInteger, out WordIsAHexNumber, out WordAllCapitals);
            //Assert
            Assert.AreEqual(false, WordEndsWithDelimiter);
        }

        [TestMethod]
        public void AnalyseWord_WordEndsWithFullStop_False()
        {
            // Arrange
            bool WordEndsWithDelimiter, WordEndsWithFullStop, WordIsAInteger, WordIsAHexNumber, WordAllCapitals;
            Text txt = new Text();
            // Act
            txt.AnalyseWord("Hello", out WordEndsWithDelimiter, out WordEndsWithFullStop, out WordIsAInteger, out WordIsAHexNumber, out WordAllCapitals);
            //Assert
            Assert.AreEqual(false, WordEndsWithFullStop);
        }

        [TestMethod]
        public void AnalyseWord_WordIsAInteger_False()
        {
            // Arrange
            bool WordEndsWithDelimiter, WordEndsWithFullStop, WordIsAInteger, WordIsAHexNumber, WordAllCapitals;
            Text txt = new Text();
            // Act
            txt.AnalyseWord("12345F", out WordEndsWithDelimiter, out WordEndsWithFullStop, out WordIsAInteger, out WordIsAHexNumber, out WordAllCapitals);
            //Assert
            Assert.AreEqual(false, WordIsAInteger);
        }

        [TestMethod]
        public void AnalyseWord_WordIsAHexNumber_False()
        {
            // Arrange
            bool WordEndsWithDelimiter, WordEndsWithFullStop, WordIsAInteger, WordIsAHexNumber, WordAllCapitals;
            Text txt = new Text();
            // Act
            txt.AnalyseWord("2E4FG", out WordEndsWithDelimiter, out WordEndsWithFullStop, out WordIsAInteger, out WordIsAHexNumber, out WordAllCapitals);
            //Assert
            Assert.AreEqual(false, WordIsAHexNumber);
        }

        [TestMethod]
        public void AnalyseWord_WordAllCapitals_False()
        {
            // Arrange
            bool WordEndsWithDelimiter, WordEndsWithFullStop, WordIsAInteger, WordIsAHexNumber, WordAllCapitals;
            Text txt = new Text();
            // Act
            txt.AnalyseWord("HELLo", out WordEndsWithDelimiter, out WordEndsWithFullStop, out WordIsAInteger, out WordIsAHexNumber, out WordAllCapitals);
            //Assert
            Assert.AreEqual(false, WordAllCapitals);
        }

        [TestMethod]
        public void AnalyseFirstWord_Everything_True()
        {
            // Arrange
            bool FirstWordAllCapitals, FirstWordHasDelimiter;
            int FirstWordPtr, SecondWordPtr, FirstWordLength, SecondWordLength;
            Text txt = new Text();
            // Act
            txt.AnalyseFirstWord("  HELLO: There", out FirstWordPtr, out SecondWordPtr, out FirstWordLength, out SecondWordLength, out FirstWordAllCapitals, out FirstWordHasDelimiter);
            //Assert
            Assert.AreEqual(true, FirstWordAllCapitals);
            Assert.AreEqual(true, FirstWordHasDelimiter);
            Assert.AreEqual(2, FirstWordPtr);
            Assert.AreEqual(9, SecondWordPtr);
            Assert.AreEqual(5, FirstWordLength);
            Assert.AreEqual(5, SecondWordLength);
        }

        [TestMethod]
        public void AnalyseFirstWord_WithCRLF1_True()
        {
            // Arrange
            bool FirstWordAllCapitals, FirstWordHasDelimiter;
            int FirstWordPtr, SecondWordPtr, FirstWordLength, SecondWordLength;
            Text txt = new Text();
            // Act
            txt.AnalyseFirstWord("  HELLO: There\r\n", out FirstWordPtr, out SecondWordPtr, out FirstWordLength, out SecondWordLength, out FirstWordAllCapitals, out FirstWordHasDelimiter);
            //Assert
            Assert.AreEqual(true, FirstWordAllCapitals);
            Assert.AreEqual(true, FirstWordHasDelimiter);
            Assert.AreEqual(2, FirstWordPtr);
            Assert.AreEqual(9, SecondWordPtr);
            Assert.AreEqual(5, FirstWordLength);
            Assert.AreEqual(5, SecondWordLength);
        }

        [TestMethod]
        public void AnalyseFirstWord_WithCRLF2_True()
        {
            // Arrange
            bool FirstWordAllCapitals, FirstWordHasDelimiter;
            int FirstWordPtr, SecondWordPtr, FirstWordLength, SecondWordLength;
            Text txt = new Text();
            // Act
            txt.AnalyseFirstWord("  HELLO: There \r\n", out FirstWordPtr, out SecondWordPtr, out FirstWordLength, out SecondWordLength, out FirstWordAllCapitals, out FirstWordHasDelimiter);
            //Assert
            Assert.AreEqual(true, FirstWordAllCapitals);
            Assert.AreEqual(true, FirstWordHasDelimiter);
            Assert.AreEqual(2, FirstWordPtr);
            Assert.AreEqual(9, SecondWordPtr);
            Assert.AreEqual(5, FirstWordLength);
            Assert.AreEqual(5, SecondWordLength);
        }


        [TestMethod]
        public void AnalyseFirstWord_AndSecond_True()
        {
            // Arrange
            bool FirstWordAllCapitals, FirstWordHasDelimiter;
            int FirstWordPtr, SecondWordPtr, FirstWordLength, SecondWordLength;
            Text txt = new Text();
            // Act
            txt.AnalyseFirstWord("private void btnAdd_Click(object sender, EventArgs e)", out FirstWordPtr, out SecondWordPtr, out FirstWordLength, out SecondWordLength, out FirstWordAllCapitals, out FirstWordHasDelimiter);
            //Assert
            Assert.AreEqual(0, FirstWordPtr);
            Assert.AreEqual(8, SecondWordPtr);
            Assert.AreEqual(7, FirstWordLength);
            Assert.AreEqual(4, SecondWordLength);
        }

        [TestMethod]
        public void AnalyseFirstWord_NoDelimETC_False()
        {
            // Arrange
            bool FirstWordAllCapitals, FirstWordHasDelimiter;
            int FirstWordPtr, SecondWordPtr, FirstWordLength, SecondWordLength;
            Text txt = new Text();
            // Act
            txt.AnalyseFirstWord("  HELLo There", out FirstWordPtr, out SecondWordPtr, out FirstWordLength, out SecondWordLength, out FirstWordAllCapitals, out FirstWordHasDelimiter);
            //Assert
            Assert.AreEqual(false, FirstWordAllCapitals);
            Assert.AreEqual(false, FirstWordHasDelimiter);
            Assert.AreEqual(2, FirstWordPtr);
            Assert.AreEqual(8, SecondWordPtr);
            Assert.AreEqual(5, FirstWordLength);
            Assert.AreEqual(5, SecondWordLength);
        }

        [TestMethod]
        public void AnalyseLastWord_NoDelimETC_False()
        {
            // Arrange
            bool LastWordHasDelimiter, LastWordIsAInteger, LastWordIsAHexNumber;
            int LastWordPtr, LastWordLength;
            Text txt = new Text();
            // Act
            txt.AnalyseLastWord("  hello 12A45  ", out LastWordPtr, out LastWordLength, out LastWordHasDelimiter, out LastWordIsAInteger, out LastWordIsAHexNumber);
            //Assert
            Assert.AreEqual(false, LastWordHasDelimiter);
            Assert.AreEqual(false, LastWordIsAInteger);
            Assert.AreEqual(true, LastWordIsAHexNumber);
            Assert.AreEqual(8, LastWordPtr);
            Assert.AreEqual(5, LastWordLength);
        }

        [TestMethod]
        public void AnalyseLastWord_Everything_True()
        {
            // Arrange
            bool LastWordHasDelimiter, LastWordIsAInteger, LastWordIsAHexNumber;
            int LastWordPtr, LastWordLength;
            Text txt = new Text();
            // Act
            txt.AnalyseLastWord("  hello 12345:", out LastWordPtr, out LastWordLength, out LastWordHasDelimiter, out LastWordIsAInteger, out LastWordIsAHexNumber);
            //Assert
            Assert.AreEqual(true, LastWordHasDelimiter);
            Assert.AreEqual(true, LastWordIsAInteger);
            Assert.AreEqual(true, LastWordIsAHexNumber);
            Assert.AreEqual(8, LastWordPtr);
            Assert.AreEqual(5, LastWordLength);
        }

        [TestMethod]
        public void DivideAfterChar_Everything_True()
        {
            // Arrange
            int SegmentsNoOf;
            List<String> Segments = new List<string>();
            Text txt = new Text();
            txt.TheText = "The following example does#not compile, because doInitialize does not#assign a value to param: ";
            // Act
            txt.DivideAfterChar('#', out SegmentsNoOf, ref Segments);
            //Assert
            Assert.AreEqual("The following example does#", Segments[0]);
            Assert.AreEqual("not compile, because doInitialize does not#", Segments[1]);
            Assert.AreEqual("assign a value to param: ", Segments[2]);
            Assert.AreEqual(3, SegmentsNoOf);
        }

        [TestMethod]
        public void DivideAfterChar_WithCRLFs_True()
        {
            // Arrange
            int SegmentsNoOf;
            List<String> Segments = new List<string>();
            Text txt = new Text();
            txt.TheText = "The following example does#not compile,\r\n because doInitialize does\r\nnot#assign a value to param: ";
            // Act
            txt.DivideAfterChar('#', out SegmentsNoOf, ref Segments);
            //Assert
            Assert.AreEqual("The following example does#", Segments[0]);
            Assert.AreEqual("not compile,\r\n because doInitialize does\r\nnot#", Segments[1]);
            Assert.AreEqual("assign a value to param: ", Segments[2]);
            Assert.AreEqual(3, SegmentsNoOf);
        }

        [TestMethod]
        public void DivideIntoWord_Everything_True()
        {
            // Arrange
            int WordsNoOf;
            List<String> Words = new List<string>();
            Text txt = new Text();
            txt.TheText = "The following example does not compile, because doInitialize does not assign a value to param: ";
            // Act
            txt.DivideIntoWords(txt.TheText, out WordsNoOf, ref Words);
            //Assert
            Assert.AreEqual("example", Words[2]);
            Assert.AreEqual("compile", Words[5]);
            Assert.AreEqual("param", Words[14]);
            Assert.AreEqual(15, WordsNoOf);
        }

        [TestMethod]
        public void DivideText_Everything_True()
        {
            // Arrange
            int ParagraphsNoOf, SentencesNoOf, LinesNoOf, WordsNoOf, lineWidth;
            bool Debug, eliminateWhiteSpace, splitHeaders, splitOnColon, splitOnLF;
            string DebugText;
            List<string> Paragrphs = new List<string>();
            List<string> Sentences = new List<string>();
            List<int> SentenceInParagraph = new List<int>();
            List<string> Lines = new List<string>();
            Paragraphs Paragraphs = new Paragraphs();
            lineWidth = 0;
            Debug = true;
            eliminateWhiteSpace = true;
            splitHeaders = false;
            splitOnColon = false;
            splitOnLF = false;
            Text txt = new Text();
            txt.TheText = "Paragraph one Sentence one. Paragraph one Sentence two Line one.\r\nParagraph two Sentence three Line two.\r\nParagraph three Sentence four Line three.\r\n";
            // Act
            txt.DivideText(out ParagraphsNoOf, ref Paragrphs, out SentencesNoOf, ref Sentences, ref SentenceInParagraph, out LinesNoOf, ref Lines, out DebugText, lineWidth, Debug, eliminateWhiteSpace, splitHeaders, splitOnColon, splitOnLF);
            //Assert
            Assert.AreEqual("Paragraph one Sentence one. Paragraph one Sentence two Line one.", Paragrphs[0]);
            Assert.AreEqual("Paragraph two Sentence three Line two.", Paragrphs[1]);
            Assert.AreEqual("Paragraph three Sentence four Line three.", Paragrphs[2]);
            Assert.AreEqual("Paragraph one Sentence one. Paragraph one Sentence two Line one.", Lines[0]);
            Assert.AreEqual("Paragraph two Sentence three Line two.", Lines[1]);
            Assert.AreEqual("Paragraph three Sentence four Line three.", Lines[2]);
            Assert.AreEqual("Paragraph one Sentence one.", Sentences[0]);
            Assert.AreEqual("Paragraph one Sentence two Line one.", Sentences[1]);
            Assert.AreEqual("Paragraph two Sentence three Line two.", Sentences[2]);
            Assert.AreEqual("Paragraph three Sentence four Line three.", Sentences[3]);
            Assert.AreEqual(3, ParagraphsNoOf);
            Assert.AreEqual(4, SentencesNoOf);
            Assert.AreEqual(3, LinesNoOf);
        }

        [TestMethod]
        public void StarttFormatting_Everything_True()
        {
            int firstWordPtr, secondWordPtr, firstWordLength, secondWordLength;
            bool firstWordAllCapitals, firstWordHasDelimiter;
            string firstWord;
            char firstWord1stChr, lastCharInLine;
            bool[] results = new bool[5];
            string[] tests = new string[5] {
            "The following example does not compile, because doInitialize does not assign a value to param: \r\n",
            "Mock<IProductRepository> mock = new Mock<IProductRepository>();\r\n",
            "Product[] result = ((ProductsListViewModel)controller.List('Cat2', 1).Model)\r\n",
            "ProductsListViewModel viewModel = new ProductsListViewModel {\r\n",
            " ItemsPerPage = PageSize,\r\n"};
            Text txt = new Text();
            for (int ptr = 0; ptr < 5; ptr++)
            {
                // Arrange
                txt.TheText = tests[ptr];
                txt.AnalyseFirstWord(txt.TheText, out firstWordPtr, out secondWordPtr, out firstWordLength, out secondWordLength, out firstWordAllCapitals, out firstWordHasDelimiter);
                firstWord = "";
                firstWord1stChr = (Char)10;
                if (firstWordLength > 0)
                {
                    firstWord1stChr = txt.TheText.Substring(firstWordPtr, 1).ToCharArray()[0];
                }
                lastCharInLine = (Char)10;
                lastCharInLine = txt.lastNonBlankChar(txt.TheText);
                // Act
                results[ptr] = txt.StartFormatting(firstWord1stChr, lastCharInLine);
            }
            //Assert
            Assert.AreEqual(true, results[0]);
            Assert.AreEqual(false, results[1]);
            Assert.AreEqual(false, results[2]);
            Assert.AreEqual(false, results[3]);
            Assert.AreEqual(false, results[4]);
        }

        [TestMethod]
        public void DontFormat_TwoAtATime_True()
        {
            int firstWordPtr, secondWordPtr, firstWordLength, secondWordLength;
            bool firstWordAllCapitals, firstWordHasDelimiter;
            string firstWord, secondWord;
            bool[] results = new bool[2];
            string[] tests = new string[2] {
            "The following example does not compile, because doInitialize does not assign a value to param: \r\n",
            "//\r\n"};
            Text txt = new Text();
            for (int ptr = 0; ptr < 2; ptr++)
            {
                // Arrange
                txt.TheText = tests[ptr];
                txt.AnalyseFirstWord(txt.TheText, out firstWordPtr, out secondWordPtr, out firstWordLength, out secondWordLength, out firstWordAllCapitals, out firstWordHasDelimiter);
                firstWord = "";
                if (firstWordLength > 0)
                {
                    firstWord = txt.TheText.Substring(firstWordPtr, firstWordLength);
                }
                secondWord = "";
                if (secondWordLength > 0)
                {
                    secondWord = txt.TheText.Substring(secondWordPtr, secondWordLength);
                }
                // Act
                results[ptr] = txt.DontFormat(firstWord, secondWord);
            }
            //Assert
            Assert.AreEqual(false, results[0]);
            Assert.AreEqual(true, results[1]);
        }

        [TestMethod]
        public void DontFormat_Everything_True()
        {
            int firstWordPtr, secondWordPtr, firstWordLength, secondWordLength;
            bool firstWordAllCapitals, firstWordHasDelimiter;
            string firstWord, secondWord;
            bool[] results = new bool[16];
            string[] tests = new string[16] {
            "The following example does not compile, because doInitialize does not assign a value to param: \r\n",
            "namespace SportsStore.WebUI.Models \r\n",
            "using System.Collections.Generic;",
            "    public class ProductController : Controller {\r\n",
            "private void btnAdd_Click(object sender, EventArgs e)\r\n",
            "//\r\n",
            "<!DOCTYPE html>\r\n",
            "@using\r\n",
            "@model SportsStore.WebUI.Models.ProductsListViewModel\r\n",
            "@{\r\n",
            "<configuration>\r\n",
            "...\r\n",
            "> db.users.find({'username' : 'joe'})\r\n",
            "$ mongod\r\n",
            "{\r\n",
            "[\r\n"};
            Text txt = new Text();
            for (int ptr = 0; ptr < 16; ptr++)
            {
                // Arrange
                txt.TheText = tests[ptr];
                txt.AnalyseFirstWord(txt.TheText, out firstWordPtr, out secondWordPtr, out firstWordLength, out secondWordLength, out firstWordAllCapitals, out firstWordHasDelimiter);
                firstWord = "";
                if (firstWordLength > 0)
                {
                    firstWord = txt.TheText.Substring(firstWordPtr, firstWordLength);
                }
                secondWord = "";
                if (secondWordLength > 0)
                {
                    secondWord = txt.TheText.Substring(secondWordPtr, secondWordLength);
                }
                // Act
                results[ptr] = txt.DontFormat(firstWord, secondWord);
            }
            //Assert
            Assert.AreEqual(false, results[0]);
            Assert.AreEqual(true, results[1]);
            Assert.AreEqual(true, results[2]);
            Assert.AreEqual(true, results[3]);
            Assert.AreEqual(true, results[4]);
            Assert.AreEqual(true, results[5]);
            Assert.AreEqual(true, results[6]);
            Assert.AreEqual(true, results[7]);
            Assert.AreEqual(true, results[8]);
            Assert.AreEqual(true, results[9]);
            Assert.AreEqual(true, results[10]);
            Assert.AreEqual(true, results[11]);
            Assert.AreEqual(true, results[12]);
            Assert.AreEqual(true, results[13]);
            Assert.AreEqual(true, results[14]);
            Assert.AreEqual(true, results[15]);
        }
    }
}
