using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notes
{
    public class Text
    {

        int txtNoOfChars, txtAlteredNoOfChars;
        string txtLetter, txtTheText, txtAlteredText, txtSearchText;
        bool textHasPicture;

        public Text()
        {
            txtNoOfChars = 0;
            txtAlteredNoOfChars = 0;
        }

        public string TheText { get; set; }
        public string SearchText { get; set; }
        public int NoOfChars { get; set; }

        public bool AnySpaces(string txt)
        {
            // Any Spaces in the sting true || false?
            bool Any;
            int txtPtr;
            Any = false;
            txtPtr = 0;
            do
            {
                if (txt.Substring(txtPtr, 1) == " ")
                {
                    Any = true;
                }
                txtPtr += 1;
            }
            while (txtPtr <= txt.Length - 1 || Any != true);
            return Any;
        }

        public bool AllBlanks(string txt)
        {
            // Is the string all blank true || false?
            bool AllBlank;
            int txtPtr;
            char currChar;
            AllBlank = true;
            txtPtr = 0;
            if (txt.Length > 0)
            {
                do
                {
                    currChar = txt.Substring(txtPtr, 1).ToCharArray()[0];
                    if ((int)(currChar) > 32)
                    {
                        AllBlank = false;
                    }
                    txtPtr += 1;
                }
                while (txtPtr <= txt.Length - 1 && AllBlank == true);
            }
            return AllBlank;
        }

        public char lastNonBlankChar(string txt)
        {
            char lastNonBlankChar;
            int txtPtr;
            char currChar;
            lastNonBlankChar = (Char)10;
            txtPtr = 0;
            if (txt.Length > 0)
                txtPtr = txt.Length - 1;
            {
                do
                {
                    currChar = txt.Substring(txtPtr, 1).ToCharArray()[0];
                    if ((int)(currChar) > 32)
                    {
                        lastNonBlankChar = currChar;
                    }
                    txtPtr -= 1;
                }
                while (txtPtr >= 0 && lastNonBlankChar == (Char)10);
            }
            return lastNonBlankChar;
        }

        public int WheresNextEndOfLine(string txt)
        {
            // Note: CHAR(10) is the character represented by ASCII code 10, which is a Line Feed (\n) so its a new line. 
            // (Although its not the windows standard new line which is Carriage Return + Line Feed CHAR(13)+CHAR(10) )
            // So this returns an integer pointer to the Line Feed Character or -1 if it doesnt exist
            int ptrChr10, txtPtr;
            char currChar;
            ptrChr10 = -1;
            txtPtr = 0;
            if (txt.Length > 0)
            {
                do
                {
                    currChar = txt.Substring(txtPtr, 1).ToCharArray()[0];
                    if (currChar == (Char)10)
                    {
                        ptrChr10 = txtPtr;
                    }
                    txtPtr += 1;
                }
                while (txtPtr <= txt.Length - 1 && ptrChr10 == -1);
                if (txtPtr >= txt.Length)
                {
                    ptrChr10 = txt.Length - 1;
                }
            }
            return ptrChr10;
        }

        public void AnalyseWord(string txt, out bool WordEndsWithDelimiter, out bool WordEndsWithFullStop, out bool WordIsAInteger, out bool WordIsAHexNumber, out bool WordAllCapitals)
        {
            // 'Determines if (the string has the above qualities i.e. ends in delimiter or full stop etc.
            int charPtr, charsToCheck, wordLength;
            string lastChar;
            char ptrChar;
            WordEndsWithDelimiter = false;
            WordEndsWithFullStop = false;
            WordIsAInteger = false;
            WordIsAHexNumber = false;
            WordAllCapitals = false;
            wordLength = txt.Length;
            if (wordLength > 1)
            {
                lastChar = txt.Substring(wordLength - 1, 1);
                if ((lastChar == ".") || (lastChar == ":") || (lastChar == ";") || (lastChar == "-"))
                {
                    WordEndsWithDelimiter = true;
                    if (lastChar == ".")
                    {
                        WordEndsWithFullStop = true;
                    }
                }
            }
            if (wordLength > 0)
            {
                if (WordEndsWithDelimiter)
                {
                    charsToCheck = wordLength - 1;
                }
                else
                {
                    charsToCheck = wordLength;
                }
                WordIsAInteger = true;
                WordIsAHexNumber = true;
                WordAllCapitals = true;
                charPtr = 0;
                do
                {
                    ptrChar = txt.Substring(charPtr, 1).ToCharArray()[0];
                    if (!((int)ptrChar >= (int)'0' && (int)ptrChar <= (int)'9'))
                    {
                        WordIsAInteger = false;
                    }
                    if (!((int)ptrChar >= (int)'0' && (int)ptrChar <= (int)'9') &&
                        !((int)ptrChar >= (int)'A' && (int)ptrChar <= (int)'F'))
                    {
                        WordIsAHexNumber = false;
                    }
                    if (((int)ptrChar < (int)'A') || ((int)ptrChar > (int)'Z'))
                    {
                        WordAllCapitals = false;
                    }
                    charPtr += 1;
                }
                while (charPtr <= charsToCheck - 1);
            }
        }

        public void AnalyseFirstWord(string txt, out int FirstWordPtr, out int SecondWordPtr, out int FirstWordLength, out int SecondWordLength, out bool FirstWordAllCapitals, out bool FirstWordHasDelimiter)
        {
            int charPtr;
            char ptrChar;
            bool atFirstWord, pastFirstWord, atSecondWord, pastSecondWord, nothingYet;
            FirstWordLength = 0;
            FirstWordPtr = 0;
            SecondWordLength = 0;
            SecondWordPtr = 0;
            charPtr = 0;
            FirstWordHasDelimiter = false;
            FirstWordAllCapitals = true;
            if (txt.Length > 0)
            {
                ptrChar = txt.Substring(charPtr, 1).ToCharArray()[0];
                nothingYet = true;
                atFirstWord = false;
                pastFirstWord = false;
                atSecondWord = false;
                pastSecondWord = false;
                do
                {
                    // GT Chr(32) is all the printable characters weve arrived at the first word
                    if (nothingYet && (int)ptrChar > 32)
                    {
                        nothingYet = false;
                        atFirstWord = true;
                        FirstWordPtr = charPtr;
                        FirstWordAllCapitals = true;
                    }
                    if (atFirstWord)
                    {
                        if (ptrChar == ':')
                        {
                            FirstWordHasDelimiter = true;
                            atFirstWord = false;
                            pastFirstWord = true;
                        }
                        else if (ptrChar == '-')
                        {
                            // if this isnt the last character in the string and the next character is a space 
                            // treat it as a delimiter
                            if (charPtr < txt.Length - 2 && txt.Substring(charPtr + 1, 1) == " ")
                            {
                                FirstWordHasDelimiter = true;
                                atFirstWord = false;
                                pastFirstWord = true;
                            }
                        }
                        // Everything less than Chr(32) i.e. a space is a non printable character e.g. null or esc
                        // that is we've reached the end of the 1st word
                        // if atFirstWord is false these characters are before the 1st word so skip them
                        else if ((int)ptrChar <= 32)
                        {
                            atFirstWord = false;
                            pastFirstWord = true;
                        }
                        else
                        {
                            if (FirstWordAllCapitals && ((int)txt.Substring(charPtr, 1).ToCharArray()[0] < (int)'A' || (int)txt.Substring(charPtr, 1).ToCharArray()[0] > (int)'Z'))
                            {
                                FirstWordAllCapitals = false;
                            }
                            FirstWordLength += 1;
                        }
                    }
                    if (pastFirstWord && !atSecondWord && txt.Substring(charPtr, 1).ToCharArray()[0] > 32 && txt.Substring(charPtr, 1) != ":" && txt.Substring(charPtr, 1) != "-")
                    {
                        atSecondWord = true;
                        SecondWordPtr = charPtr;
                    }
                    if (atSecondWord)
                    {
                        if ((int)ptrChar <= 32)
                        {
                            pastSecondWord = true;
                            atSecondWord = false;
                        }
                        else
                        {
                            SecondWordLength += 1;
                        }
                    }
                    charPtr += 1;
                    if (charPtr < txt.Length - 1)
                    {
                        ptrChar = txt.Substring(charPtr, 1).ToCharArray()[0];
                    }
                }
                while (!pastSecondWord && charPtr <= txt.Length - 1);
            }
        }

        public void AnalyseLastWord(string txt, out int LastWordPtr, out int LastWordLength, out bool LastWordHasDelimiter, out bool LastWordIsAInteger, out bool LastWordIsAHexNumber)
        {
            int charPtr;
            char ptrChar;
            bool atLastWord, beforeLastWord, nothingYet;
            LastWordLength = 0;
            LastWordPtr = 0;
            LastWordHasDelimiter = false;
            LastWordIsAInteger = false;
            LastWordIsAHexNumber = false;
            charPtr = txt.Length - 1;
            if (txt.Length > 0)
            {
                ptrChar = txt.Substring(charPtr, 1).ToCharArray()[0];
                atLastWord = false;
                beforeLastWord = false;
                nothingYet = true;
                LastWordHasDelimiter = false;
                do
                {
                    if ((int)ptrChar <= 32)
                    {
                        if (atLastWord)
                        {
                            atLastWord = false;
                            beforeLastWord = true;
                            LastWordPtr = charPtr + 1;
                        }
                    }
                    else
                    {
                        if (nothingYet)
                        {
                            if (ptrChar == ':' || ptrChar == '-')
                            {
                                LastWordHasDelimiter = true;
                            }
                            else
                            {
                                LastWordIsAInteger = true;
                                LastWordIsAHexNumber = true;
                                atLastWord = true;
                                nothingYet = false;
                            }
                        }
                        if (atLastWord)
                        {
                            LastWordLength += 1;
                            if (!((int)ptrChar >= (int)'0' && (int)ptrChar <= (int)'9'))
                            {
                                LastWordIsAInteger = false;
                            }
                            if (!((int)ptrChar >= (int)'0' && (int)ptrChar <= (int)'9') && !((int)ptrChar >= (int)'A' && (int)ptrChar <= (int)'F'))
                            {
                                LastWordIsAHexNumber = false;
                            }
                        }
                    }
                    if (!beforeLastWord)
                    {
                        charPtr -= 1;
                        if (charPtr >= 0)
                        {
                            ptrChar = txt.Substring(charPtr, 1).ToCharArray()[0];
                        }
                    }
                }
                while (!beforeLastWord && charPtr >= 0);
            }
        }

        public void IncludeSegments(int SegmentsNoOf, int SegmentsAlteredNoOf, string MatchText, ref List<string> Segments, string AlteredText)
        {
            string seg;
            AlteredText = "";
            SegmentsAlteredNoOf = 0;
            for (int segPtr = 0; segPtr <= SegmentsNoOf - 1; segPtr++)
            {
                seg = Segments[segPtr];
                if (seg.Length >= MatchText.Length)
                {
                    if (seg.IndexOf(MatchText) >= 0)
                    {
                        AlteredText += seg;
                        SegmentsAlteredNoOf += 1;
                    }
                }
            }
        }

        public void ExcludeSegments(int SegmentsNoOf, int SegmentsAlteredNoOf, string MatchText, ref List<string> Segments, string AlteredText)
        {
            string seg;
            AlteredText = "";
            SegmentsAlteredNoOf = 0;
            for (int segPtr = 0; segPtr <= SegmentsNoOf - 1; segPtr++)
            {
                seg = Segments[segPtr];
                if (seg.Length >= MatchText.Length)
                {
                    if (seg.IndexOf(MatchText) < 0)
                    {
                        AlteredText += seg;
                        SegmentsAlteredNoOf += 1;
                    }
                }
            }
        }

        public void DivideAfterChar(char Divider, out int SegmentsNoOf, ref List<string> Segments)
        {
            // This divides the text into Segments at he defined by a single character divider
            // Segments appear to include the divider at the end of the segment
            int noOfChars, segStart, segLength;
            string theText;
            char txtLetter;
            theText = this.TheText;
            noOfChars = this.TheText.Length;
            segStart = 0;
            SegmentsNoOf = 0;
            for (int txtPtr = 0; txtPtr <= noOfChars - 1; txtPtr++)
            {
                txtLetter = theText.Substring(txtPtr, 1).ToCharArray()[0];
                if (txtLetter == Divider || txtPtr == noOfChars - 1)
                {
                    SegmentsNoOf += 1;
                    segLength = txtPtr - segStart + 1;
                    Segments.Add(theText.Substring(segStart, segLength));
                    segStart = txtPtr + 1;
                }
            }
        }

        public void DivideByFieldWithNoSpaces(int DividerStart, int DividerLength, int LinesNoOf, int SegmentsNoOf, ref List<string> Segments)
        {
            // Seems to create segments where segments are continuously concatenated lines until a line has no spaces in the
            // divider area in which case a new segment is started!! What is this used for??
            int linePtr, noOfChars;
            string theText, fldTime;
            List<string> Lines;
            Lines = new List<string>();
            noOfChars = this.NoOfChars;
            theText = this.TheText;
            //// First up divide text into lines
            LinesNoOf = 0;
            // (Char)10 is the line feed character which is the last character on every line
            DivideAfterChar((Char)10, out LinesNoOf, ref Lines);
            SegmentsNoOf = 0;
            foreach (string line in Lines)
            {
                if (line.Length >= DividerLength)
                {
                    fldTime = line.Substring(DividerStart, DividerLength);
                    if (AnySpaces(fldTime))
                    {
                        Segments[SegmentsNoOf] += line;
                    }
                    else
                    {
                        SegmentsNoOf += 1;
                        Segments[SegmentsNoOf] = line;
                    }
                }
            }
        }

        public void DivideIntoWords(string txtText, out int WordsNoOf, ref List<string> Words)
        {
            int noOfChars, wordStart, wordLength;
            char currChar, lastChar;
            noOfChars = txtText.Length;
            wordStart = 0;
            wordLength = 0;
            WordsNoOf = 0;
            lastChar = ' ';
            for (int txtPtr = 0; txtPtr <= noOfChars - 1; txtPtr++)
            {
                currChar = txtText.Substring(txtPtr, 1).ToCharArray()[0];
                // if the current char isnt alphabetic || numeric but the last char is weve reached
                // the end of the word
                if (!(((int)currChar >= (int)'a' && (int)currChar <= (int)'z') ||
                        ((int)currChar >= (int)'A' && (int)currChar <= (int)'Z') ||
                        ((int)currChar >= (int)'0' && (int)currChar <= (int)'9') ||
                        currChar == '\\' ||
                        currChar == '-' ||
                        currChar == '/' ||
                        currChar == '’') &&
                       (((int)lastChar >= (int)'a' && (int)lastChar <= (int)'z') ||
                        ((int)lastChar >= (int)'A' && (int)lastChar <= (int)'Z') ||
                        ((int)lastChar >= (int)'0' && (int)lastChar <= (int)'9')) ||
                        txtPtr == noOfChars - 1)
                {
                    if (wordStart != -1)
                    {
                        WordsNoOf += 1;
                        wordLength = txtPtr - wordStart;
                        Words.Add(txtText.Substring(wordStart, wordLength).ToLower());
                        wordStart = -1;
                    }
                }
                if ((((int)currChar >= (int)'a' && (int)currChar <= (int)'z') ||
                        ((int)currChar >= (int)'A' && (int)currChar <= (int)'Z') ||
                        ((int)currChar >= (int)'0' && (int)currChar <= (int)'9')) &&
                    (!(((int)lastChar >= (int)'a' && (int)lastChar <= (int)'z') ||
                        ((int)lastChar >= (int)'A' && (int)lastChar <= (int)'Z') ||
                        ((int)lastChar >= (int)'0' && (int)lastChar <= (int)'9') ||
                        (lastChar == '\\' ||
                        lastChar == '-' ||
                        lastChar == '/' ||
                        lastChar == '’'))))
                {
                    wordStart = txtPtr;
                }
                lastChar = currChar;
            }
        }

        public void StartNewParagraph(ref int ParagraphsNoOf, ref List<string> Paragraphs, string sentence, ref string paragraph, char currChar, ref int ParagraphLength, bool Debug, string DebugText, bool Format)
        {
            if (Debug)
            {
                DebugText += (Char)13 + (Char)10 + (Char)13 + (Char)10 + " - Its a new paragraph - Old Paragraph Length = " + ParagraphLength.ToString() + (Char)13 + (Char)10 + (Char)13 + (Char)10;
                DebugText += currChar;
            }
            Paragraphs.Add(paragraph);
            ParagraphsNoOf += 1;
            paragraph = currChar.ToString();
            ParagraphLength = 1;
        }

        public void StartNewSentence(int ParagraphsNoOf, ref int SentencesNoOf, ref List<string> Sentences, ref List<int> SentenceInParagraph, ref string sentence, ref int SentenceLength, char currChar, bool Debug, string DebugText, bool Format)
        {
            if (Debug)
            {
                DebugText += " - Its a new sentence - Old Sentence Length = " + SentenceLength.ToString() + " ";
            }
            SentencesNoOf += 1;
            Sentences.Add(sentence);
            SentenceInParagraph.Add(ParagraphsNoOf);
            sentence = currChar.ToString();
            SentenceLength = 1;
        }


        public void StartNewLine(ref int LinesNoOf, ref List<string> Lines, ref string line, char currChar, ref int LineLength, bool Debug, string DebugText)
        {
            if (Debug)
            {
                DebugText += " - Its a new line - Old Line Length = " + LineLength.ToString() + " ";
            }
            LinesNoOf += 1;
            Lines.Add(line);
            line = currChar.ToString();
            LineLength = 1;
        }

        public bool StartFormatting(char firstWordChar, char lastCharInLine)
        {
            bool formatAgain;
            formatAgain = false;
            if ((int)firstWordChar >= (int)'A' && (int)firstWordChar <= (int)'Z')
            {
                if (lastCharInLine != ';' && lastCharInLine != '{' && lastCharInLine != ',' && lastCharInLine != ')')
                {
                    formatAgain = true;
                }
            }
            return formatAgain;
        }

        public bool DontFormat(string firstWord, string secondWord)
        {
            bool dontformat;
            dontformat = false;
            if (firstWord == ">" || firstWord == "{" || firstWord == "$" || firstWord == "[" || firstWord == "..." || firstWord == "//" || firstWord == "namespace" || firstWord == "@using" || firstWord == "@model" || firstWord == "@{" || firstWord == "<configuration>" || firstWord == "<!DOCTYPE")
            {
                dontformat = true;
            }
            if (firstWord == "using" && secondWord.Substring(0, 6) == "System")
            {
                dontformat = true;
            }
            if (firstWord == "public" || firstWord == "private" || firstWord == "protected")
            {
                if (secondWord == "class" || secondWord == "void" || secondWord == "int" || secondWord == "bool" || secondWord == "string")
                {
                    dontformat = true;
                }
            }
            return dontformat;
        }

        public void DivideText(out int ParagraphsNoOf, ref List<string> Paragraphs, out int SentencesNoOf, ref List<string> Sentences, ref List<int> SentenceInParagraph, out int LinesNoOf, ref List<string> Lines, out string DebugText, int LineWidth, bool Debug, bool EliminateWhiteSpace, bool SplitHeaders, bool SplitOnColon, bool SplitOnLF)
        {
            int txtPtr, noOfChars, oldLineLength, LineLength, SentenceLength, ParagraphLength, firstWordPtr, secondWordPtr, firstWordLength, secondWordLength, lineEnd;
            char currChar, lastChar, nextChar, firstWord1stChr, lastCharInLine;
            string line, newLine, sentence, paragraph, firstWord, secondWord, txtText;
            bool endOfSentence, endOfParagraph, endOfLine, ItsAList, ListItemEndsWithFullStop, HitAColon, FirstLine, firstWordAllCapitals, delimited, LastLineWasAHeading, SkipNextCharacter, SkipTheFollowingText, WordEndsWithDelimiter, WordEndsWithFullStop, WordIsAInteger, WordIsAHexNumber, WordAllCapitals, Format, HitTextYet, WaitTillAngleDelim;

            DebugText = "";

            // Get the text that were formatting

            txtText = this.TheText;
            noOfChars = txtText.Length;

            // First up ")." is the preferred end of a sentence not ".)" etc

            txtText = txtText.Replace(".)", ").");
            txtText = txtText.Replace("?)", ")?");
            txtText = txtText.Replace("!)", ")!");
            txtText = txtText.Replace(".}", "}.");
            txtText = txtText.Replace("?}", "}?");
            txtText = txtText.Replace("!}", "}!");
            txtText = txtText.Replace(".]", "].");
            txtText = txtText.Replace("?]", "]?");
            txtText = txtText.Replace("!]", "]!");

            // Initial values

            FirstLine = true;
            endOfLine = false;
            endOfSentence = false;
            endOfParagraph = false;
            HitAColon = false;
            LastLineWasAHeading = false;
            ItsAList = false;
            ListItemEndsWithFullStop = false;
            Format = true;
            HitTextYet = false;
            lastChar = (Char)10;
            paragraph = "";
            sentence = "";
            line = "";
            oldLineLength = 0;
            LineLength = 0;
            ParagraphsNoOf = 0;
            SentencesNoOf = 0;
            LinesNoOf = 0;
            SkipNextCharacter = false;
            SkipTheFollowingText = false;
            firstWordPtr = 0;
            secondWordPtr = 0;
            firstWordLength = 0;
            secondWordLength = 0;
            firstWordAllCapitals = false;
            delimited = false;
            WordEndsWithDelimiter = false;
            WordEndsWithFullStop = false;
            WordIsAInteger = false;
            WordIsAHexNumber = false;
            WordAllCapitals = false;
            SentenceLength = 0;
            ParagraphLength = 0;
            WaitTillAngleDelim = false;
            lastCharInLine = (Char)10;

            // Each Character one at a time

            for (txtPtr = 0; txtPtr <= noOfChars - 1; txtPtr++)
            {
                currChar = txtText.Substring(txtPtr, 1).ToCharArray()[0];

                // Some of the decisions below need to know what the next char is

                if (txtPtr < noOfChars - 1)
                {
                    nextChar = txtText.Substring(txtPtr + 1, 1).ToCharArray()[0];
                }
                else
                {
                    nextChar = ' ';
                }

                // Is this character a printable character

                if ((int)currChar > 32 && !HitTextYet)
                {
                    HitTextYet = true;
                }

                // Dont format from <~ to ~>

                // Start Formatting Paragraphs && Sentences

                if (lastChar == '~' && currChar == '>')
                {
                    if (Debug)
                    {
                        DebugText += " - Hitting ~> skipping > Format - ";
                    }
                    Format = true;
                    WaitTillAngleDelim = false;
                    SkipNextCharacter = true;
                    endOfSentence = true;
                    HitTextYet = false;
                    endOfParagraph = true;
                }

                // Stop Formatting Text into Paragraphs && Sentences however keep Formatting it into Lines as 
                // this doesnt actually change the text of the line

                if (lastChar == '<' && currChar == '~')
                {
                    if (Debug)
                    {
                        DebugText += " - Hitting <~ skipping ~ Dont Format - ";
                    }
                    Format = false;
                    WaitTillAngleDelim = true;
                    SkipNextCharacter = true;
                    endOfSentence = true;
                    HitTextYet = false;
                    endOfParagraph = true;
                }
                if (currChar == '~' && nextChar == '>')
                {
                    SkipNextCharacter = true;
                    if (Debug)
                    {
                        DebugText += " - Hitting ~> skipping ~ - ";
                    }
                }
                if (currChar == '<' && nextChar == '~')
                {
                    SkipNextCharacter = true;
                    if (Debug)
                    {
                        DebugText += " - Hitting <~ skipping < - ";
                    }
                }

                // Skip Character in these situations

                // Dont include white space if where eliminating white space && the current char is a space && 
                // the last character was a space

                if (EliminateWhiteSpace && currChar == ' ' && lastChar == ' ' && Format)
                {
                    SkipNextCharacter = true;
                    if (Debug)
                    {
                        DebugText += " - skippng white space - ";
                    }
                }

                // if the current character isnt printable skip it, this includes CR && LF

                // if debugging let us know we skipped them

                // Display LF's && CR's when debugging

                if (currChar == (Char)10 && Debug)
                {
                    DebugText += " - chr is line feed - ";
                }
                if (currChar == (Char)13 && Debug)
                {
                    DebugText += " - chr is carriage return - ";
                }

                // We only want to include CR's + LF's when were not formatting + after we've hit the 1st printable character
                // Also dont skip tabs

                if ((int)currChar < 32)
                {
                    if (HitTextYet && !Format)
                    {
                        SkipNextCharacter = false;
                    }
                    else
                    {
                        if (currChar == (Char)9)
                        {
                            SkipNextCharacter = false;
                            // Convert tabs to spaces on list entries
                            if (ItsAList)
                            {
                                currChar = ' ';
                            }
                            if (Debug)
                            {
                                DebugText += " - Hit a Tab - ";
                            }
                        }
                        else
                        {
                            if (currChar == (Char)10)
                            {
                                if (SplitOnLF)
                                {
                                    SkipNextCharacter = false;
                                }
                                else
                                {
                                    SkipNextCharacter = true;
                                    if (Debug)
                                    {
                                        DebugText += " - skippng line feed - ";
                                    }
                                }
                            }
                            if (currChar == (Char)13)
                            {
                                if (SplitOnLF)
                                {
                                    SkipNextCharacter = false;
                                }
                                else
                                {
                                    SkipNextCharacter = true;
                                    if (Debug)
                                    {
                                        DebugText += " - skippng carriage return - ";
                                    }
                                }
                            }
                        }
                    }
                }

                // The characters we want

                if (!SkipNextCharacter)
                {

                    // if (lastChar is LF were now at a new line

                    if (lastChar == (Char)10)
                    {
                        if (Debug)
                        {
                            DebugText += " - hit new line - ";
                        }
                        ItsAList = false;
                        ListItemEndsWithFullStop = false;
                        lineEnd = WheresNextEndOfLine(txtText.Substring(txtPtr));
                        newLine = txtText.Substring(txtPtr, lineEnd + 1);
                        AnalyseFirstWord(newLine, out firstWordPtr, out secondWordPtr, out firstWordLength, out secondWordLength, out firstWordAllCapitals, out delimited);
                        // these are the positions in the whole text not just the next line
                        firstWordPtr += txtPtr;
                        secondWordPtr += txtPtr;
                        firstWord1stChr = txtText.Substring(firstWordPtr, 1).ToCharArray()[0];
                        firstWord = "";
                        if (firstWordLength > 0)
                        {
                            firstWord = txtText.Substring(firstWordPtr, firstWordLength);
                        }
                        secondWord = "";
                        if (secondWordLength > 0)
                        {
                            secondWord = txtText.Substring(secondWordPtr, secondWordLength);
                        }
                        SkipTheFollowingText = DontFormat(firstWord, secondWord);
                        lastCharInLine = (Char)10;
                        lastCharInLine = lastNonBlankChar(newLine);
                        AnalyseWord(firstWord, out WordEndsWithDelimiter, out WordEndsWithFullStop, out WordIsAInteger, out WordIsAHexNumber, out WordAllCapitals);
                        if (Debug)
                        {
                            DebugText += " - first word is - " + firstWord.ToString() + " - first word 1st char is - " + firstWord1stChr.ToString() + " ";
                        }
                        if (Format)
                        {
                            // Is It A List
                            if ((firstWord == "•" || firstWord == "o" || firstWord == "-" || firstWord == "v" || firstWord == "*"))
                            {
                                ItsAList = true;
                            }
                            if (WordIsAInteger && WordEndsWithFullStop)
                            {
                                ItsAList = true;
                            }
                            if ((int)firstWord1stChr >= (int)'a' && (int)firstWord1stChr <= (int)'z' && delimited && firstWordLength == 2) // <=== Shouldnt this be 1 need to test!!
                            {
                                ItsAList = true;
                            }
                            if (ItsAList && WordEndsWithFullStop)
                            {
                                ListItemEndsWithFullStop = true;
                            }
                            if (!FirstLine && ItsAList)
                            {
                                endOfParagraph = true;
                                endOfSentence = true;
                                if (Debug)
                                {
                                    DebugText += " - its a list - ";
                                }
                            }
                            if (!FirstLine && currChar == ':' && (int)lastChar >= (int)'a' && (int)lastChar <= (int)'z' && SplitOnColon)
                            {
                                endOfParagraph = true;
                                endOfSentence = true;
                                if (Debug)
                                {
                                    DebugText += " - split on colon - ";
                                }
                            }
                            // Is this new line a new paragraph (and hence a new sentence)

                            // Basically its a new paragraph if the 1st char of the 1st word on a new line is a capital 

                            // I have added to this but this alone pretty well works in 99% of the cases

                            // The LineWidth stuff isnt being used LineWidth is always 0 but it is still possible to 
                            // specify a LineWidth so leaving this in for the time being

                            // HitTextYet is required as we dont want to start a new paragraph until weve reached the 
                            // 1st character of the new paragraph

                            // Included " as there were quite a few cases where a new paragraph started with a word in quotes

                            // SkipTheFollowingText is basically checking for code e.g. C#, HTML etc. which is treated 
                            // as a new paragraph but isnt formatted, the setting is determined above when we hit a new line

                            if (!FirstLine && HitTextYet &&
                                (oldLineLength + firstWordLength < LineWidth || oldLineLength > LineWidth || LineWidth == 0) &&
                                (((int)firstWord1stChr >= (int)'A' && (int)firstWord1stChr <= (int)'Z') || firstWord1stChr == '"' || SkipTheFollowingText))
                            {
                                endOfParagraph = true;
                                endOfSentence = true;
                                if (Debug)
                                {
                                    DebugText += " - its a new paragraph - ";
                                }
                                if (SkipTheFollowingText)
                                {
                                    Format = false;
                                    if (Debug)
                                    {
                                        DebugText += " - Dont Format - ";
                                    }
                                }
                            }
                        }
                        // End of if Format, so else is for !Format
                        else if (!WaitTillAngleDelim && !FirstLine && HitTextYet && StartFormatting(firstWord1stChr, lastCharInLine))
                        {
                            Format = true;
                            SkipTheFollowingText = false;
                            endOfSentence = true;
                            endOfParagraph = true;
                            if (Debug)
                            {
                                DebugText += " - its a new paragraph (Formatting again) - ";
                            }
                        }
                        if (Debug)
                        {
                            DebugText += " - old line length = " + LineLength.ToString() + " ";
                        }
                        // Next LF wont be on the First Line and becuase lastChar was LF this is the end of a line
                        if (FirstLine)
                        {
                            FirstLine = false;
                        }
                        else
                        {
                            endOfLine = true;
                            oldLineLength = LineLength;
                        }

                    }

                    // End of Last Char was a LF so we do the following for every character

                    // Start Newline if (we've reached the end of a line

                    if (endOfLine)
                    {
                        endOfLine = false;
                        StartNewLine(ref LinesNoOf, ref Lines, ref line, currChar, ref LineLength, Debug, DebugText);
                    }
                    else
                    {
                        line += currChar;
                        LineLength += 1;
                    }

                    // Start new Sentence if we've hit a fullstop and we've now hit text following the full stop

                    if (endOfSentence && HitTextYet)
                    {
                        endOfSentence = false;
                        StartNewSentence(ParagraphsNoOf, ref SentencesNoOf, ref Sentences, ref SentenceInParagraph, ref sentence, ref SentenceLength, currChar, Debug, DebugText, Format);
                    }
                    else
                    {
                        if (!endOfSentence)
                        {
                            sentence += currChar;
                            SentenceLength += 1;
                        }
                    }

                    // Start New Pragraph if we've reached the 1st printable character after the end of the last paragraph

                    if (endOfParagraph && HitTextYet)
                    {
                        endOfParagraph = false;
                        StartNewParagraph(ref ParagraphsNoOf, ref Paragraphs, sentence, ref paragraph, currChar, ref ParagraphLength, Debug, DebugText, Format);
                    }
                    else
                    {
                        paragraph += currChar;
                        ParagraphLength += 1;
                        if (Debug)
                        {
                            DebugText += currChar;
                        }
                    }

                    // Have we reached the end of a sentence

                    // Basically if we've hit a full stop the next char is a space (or non-printable) and the previous char 
                    // was alphanumeric or a closing bracket weve reached the end of a sentence

                    // The one case where this isnt the end of a sentence is the full-stop follows a list item in a  
                    // list (i.e. the 1st word in a line is delimited by a fullstop)
                    // so dont indicate its an end of sentence in this case??

                    if (Format && currChar == '.' && (int)nextChar <= 32 &&
                       ((int)lastChar >= (int)'a' && (int)lastChar <= (int)'z' ||
                       (int)lastChar >= (int)'A' && (int)lastChar <= (int)'Z' ||
                       (int)lastChar >= (int)'0' && (int)lastChar <= (int)'9' ||
                       lastChar == '>' ||
                       lastChar == ')' ||
                       lastChar == '}' ||
                       lastChar == ']'))
                    {
                        if (ListItemEndsWithFullStop)
                        {
                            ListItemEndsWithFullStop = false;
                            if (Debug)
                            {
                                DebugText += " - hit full stop but not treating it as an end of sentence - ";
                            }

                        }
                        else
                        {
                            endOfSentence = true;
                            HitTextYet = false;
                            if (Debug)
                            {
                                DebugText += " - hit full stop at end of sentence - ";
                            }
                        }
                    }
                }

                // End of Dont skip this character

                lastChar = currChar;
                SkipNextCharacter = false;
            }

            // End of Character Loop i.e. there are no more characters in the text

            if (Debug)
            {
                DebugText += " - Reached the End of the Text - ";
            }

            if (paragraph.Length > 0)
            {
                ParagraphsNoOf += 1;
                Paragraphs.Add(paragraph);
                if (Debug)
                {
                    DebugText += " - Adding Last Paragraph - ";
                }
            }
            if (sentence.Length > 0)
            {
                SentencesNoOf += 1;
                Sentences.Add(sentence);
                SentenceInParagraph.Add(ParagraphsNoOf);
                if (Debug)
                {
                    DebugText += " - Adding Last Sentence - ";
                }
            }
            if (line.Length > 0)
            {
                LinesNoOf += 1;
                Lines.Add(line);
                if (Debug)
                {
                    DebugText += " - Adding Last Line - ";
                }
            }
        }
    }
}