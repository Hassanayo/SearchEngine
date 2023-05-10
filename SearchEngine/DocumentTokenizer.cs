namespace SearchEngine
{
    class DocumentTokenizer
    {
        static void Main(string[] args)
        {

            //doc representations
            string doc1 = "I did enact Julius Caesar; I was killed i' the capitol; Brutus julius killed me?.";
            string doc2 = "So let it be with caesar. The noble Brutus hath told you Caesar was ambitious.";

            string newDoc = CleanText(doc1);
            string[] tokens = TokenizeText(newDoc);

            // Print the tokens
            foreach (string token in tokens)
            {
                Console.WriteLine(token);
            }
            Console.WriteLine(newDoc);


        }
        /// <summary>
        /// Cleans the text gotten from the document by removing and formatting unwanted characters and stop words
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Cleaned up text</returns>
        static string CleanText(string text)
        {
            // remove non alphanumeric-characters
            string cleanedText = new string(text.Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)).ToArray());
            cleanedText.ToLower().Trim();

            // Stop words to be excluded
            List<string> stopWords = new List<string>() { "a", "an", "and", "are", "as", "at", "be", "by", "for", "from", "has", "he", "in", "is", "it", "its", "on", "of", "that", "the", "to", "was", "were", "will", "with" };
            string[] words = cleanedText.Split(" ");
            List<string> cleanedWords = new List<string>();
            foreach (string word in words)
            {
                if (!stopWords.Contains(word))
                {
                    cleanedWords.Add(word);
                }
            }
            cleanedText = string.Join(" ", cleanedWords);
            return cleanedText;
        }

        /// <summary>
        /// Tokenizes the text and store in an array for later use in indexing or searching
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Tokenized text</returns>
        static string[] TokenizeText(string text)
        {
            string[] tokens = text.Split(new char[] { ' ', '\t', '\r', '\n', ',', '.', '!', '?', ':', ';', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            return tokens;
        }

    }
}
