using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private Random _random;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();
            _random = new Random();

            foreach (string word in text.Split(' '))
            {
                _words.Add(new Word(word));
            }
        }

        public void Display()
        {
            Console.WriteLine(_reference.ToString());
            Console.WriteLine(string.Join(" ", _words));
        }

        public void HideRandomWords(int count)
        {
            List<int> availableIndices = Enumerable.Range(0, _words.Count)
                                                   .Where(i => !_words[i].IsHidden())
                                                   .ToList();

            if (availableIndices.Count == 0)
                return;

            int hiddenCount = 0;
            int attempts = 0;

            while (hiddenCount < count && attempts < 100)
            {
                int randomIndex = availableIndices[new Random().Next(availableIndices.Count)];
                if (!_words[randomIndex].IsHidden())
                {
                    _words[randomIndex].Hide();
                    hiddenCount++;
                    availableIndices.Remove(randomIndex);
                }
                attempts++;
            }
        }

        public bool AllWordsHidden()
        {
            return _words.All(w => w.IsHidden());
        }
    }
}
