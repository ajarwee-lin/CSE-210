using System;
using System.Collections.Generic;

// Class representing a word in the scripture
class Word
{
    private string text;
    private bool hidden;

    public Word(string text)
    {
        this.text = text;
        this.hidden = false;
    }

    public void Hide()
    {
        hidden = true;
    }

    public string GetDisplayText()
    {
        return hidden ? "[Hidden]" : text;
    }
}

// Class representing the scripture reference
class ScriptureReference
{
    private string reference;

    public ScriptureReference(string reference)
    {
        this.reference = reference;
    }

    public string GetReference()
    {
        return reference;
    }
}

// Class representing the scripture
class Scripture
{
    private ScriptureReference scriptureReference;
    private List<Word> words;

    public Scripture(ScriptureReference scriptureReference, string[] text)
    {
        this.scriptureReference = scriptureReference;
        this.words = new List<Word>();

        foreach (string wordText in text)
        {
            words.Add(new Word(wordText));
        }
    }

    public void Display()
    {
        Console.WriteLine($"Scripture Reference: {scriptureReference.GetReference()}");
        foreach (Word word in words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }
        Console.WriteLine();
    }

    public bool HideRandomWords()
    {
        bool allWordsHidden = true;

        foreach (Word word in words)
        {
            if (!word.GetDisplayText().Equals("[Hidden]"))
            {
                allWordsHidden = false;
                break;
            }
        }

        if (!allWordsHidden)
        {
            Console.WriteLine("Press Enter to hide more words or type 'quit' to end:");
            string userInput = Console.ReadLine().ToLower();

            if (userInput.Equals("quit"))
            {
                return true;
            }

            HideRandomWord();
            Console.Clear();
            Display();
        }

        return allWordsHidden;
    }

    private void HideRandomWord()
    {
        Random random = new Random();
        int randomIndex = random.Next(words.Count);
        words[randomIndex].Hide();
    }
}

class Program
{
    static void Main()
    {
        // Example usage
        string[] scriptureText = "Remember Lot's Wife.".Split(' ');
        ScriptureReference scriptureReference = new ScriptureReference("Luke 17:33");
        Scripture scripture = new Scripture(scriptureReference, scriptureText);

        bool allWordsHidden = false;

        do
        {
            scripture.Display();
            allWordsHidden = scripture.HideRandomWords();

        } while (!allWordsHidden);
    }
}
