using System.Reflection.Metadata;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference Reference, string text)
    {
        _reference = Reference;

        _words = new List<Word>();

        // Splitting the scripture text into words
        string[] wordsArray = text.Split(' ');

        // Creating Word objects for each word in the scripture
        foreach (string wordText in wordsArray)
        {
            Word word = new Word(wordText);
            _words.Add(word);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        if (_words.Count <= numberToHide)
        {
            // Clear the scripture if the number of words is less than or equal to the numberToHide
            _words.ForEach(word => word.Hide());
        }
        else
        {
            Random random = new Random();

            // List of indices for words that are not already hidden
            List<int> nonHiddenIndices = new List<int>();

            for (int i = 0; i < _words.Count; i++)
            {
                if (!_words[i].IsHidden())
                {
                    nonHiddenIndices.Add(i);
                }
            }

            // Ensure that the number of words to hide is not greater than the number of non-hidden words
            numberToHide = Math.Min(numberToHide, nonHiddenIndices.Count);

            if (numberToHide == 0)
            {
                // If numberToHide is 0, clear the scripture by hiding all words
                _words.ForEach(word => word.Hide());
            }
            else
            {
                // Shuffle the non-hidden indices
                for (int i = nonHiddenIndices.Count - 1; i > 0; i--)
                {
                    int j = random.Next(0, i + 1);
                    int temp = nonHiddenIndices[i];
                    nonHiddenIndices[i] = nonHiddenIndices[j];
                    nonHiddenIndices[j] = temp;
                }

                // Hide the selected number of words
                for (int i = 0; i < numberToHide; i++)
                {
                    _words[nonHiddenIndices[i]].Hide();
                }
            }
        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + " ";

        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }

        return displayText.Trim(); ;
    }

    public bool IsCompletelyHidden()
    {
        return _words.TrueForAll(word => word.IsHidden());
    }
}