using System;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        foreach (var word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int hiddenCount = 0;

        // Loop until we've hidden the required number of words or all words are hidden
        while (hiddenCount < numberToHide)
        {
            // Find all non-hidden words
            List<int> nonHiddenIndices = new List<int>();
            for (int i = 0; i < _words.Count; i++)
            {
                if (!_words[i].IsHidden())
                {
                    nonHiddenIndices.Add(i);
                }
            }

            // If no non-hidden words are left, exit the loop
            if (nonHiddenIndices.Count == 0)
            {
                break;
            }

            // Hide a random word from the list of non-hidden indices
            int randomIndex = random.Next(nonHiddenIndices.Count);
            int wordIndex = nonHiddenIndices[randomIndex];
            _words[wordIndex].Hide();
            hiddenCount++;

            // If the number of non-hidden words is less than the number to hide,
            // adjust the loop to hide only the remaining words
            if (nonHiddenIndices.Count <= numberToHide - hiddenCount)
            {
                foreach (int index in nonHiddenIndices)
                {
                    if (!_words[index].IsHidden())
                    {
                        _words[index].Hide();
                        hiddenCount++;
                    }
                }
                break; 
            }
        }
    }

    public string GetDisplayText()
    {
        string text = "";
        foreach (var word in _words)
        {
            text += word.GetDisplayText() + " ";
        }
        return $"{_reference.GetDisplayText()} - {text.Trim()}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (var word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}