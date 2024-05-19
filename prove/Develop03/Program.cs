// using System;

// class Program
// {
//     static void Main(string[] args)
//     {
//         Fraction f1 = new Fraction();
//         Console.WriteLine(f1.GetFractionString());
//         Console.WriteLine(f1.GetDecimalValue());

//         Fraction f2 = new Fraction(5);
//         Console.WriteLine(f2.GetFractionString());
//         Console.WriteLine(f2.GetDecimalValue());

//         Fraction f3 = new Fraction(3, 4);
//         Console,WriteLine(f3.GetFractionString());
//         Console.WriteLine(f3.GetDecimalValue());

//         Fraction f4 = new Fraction(1, 3);
//         Console.WriteLine(f4.GetFractionString());
//         Console.WriteLine(f4.GetDecimalValue());
//     }
// }

using System;
using System.Collections.Generic;
using System.Linq;

{
    class Program
    {
        static void Main()
        {
            // Create a sample scripture
            var reference = new Reference("John 3:16");
            var scripture = new Scripture(reference, "For God so loved the world...");

            // Display the complete scripture
            Console.WriteLine(scripture.GetFullScripture());

            // Prompt the user
            Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");
            while (true)
            {
                var input = Console.ReadLine();
                if (input.ToLower() == "quit")
                    break;

                scripture.HideRandomWord();
                Console.Clear();
                Console.WriteLine(scripture.GetFullScripture());
            }
        }
    }

    class Word
    {
        public string Text { get; }
        public bool IsHidden { get; private set; }

        public Word(string text)
        {
            Text = text;
            IsHidden = false;
        }

        public void Hide()
        {
            IsHidden = true;
        }
    }

    class Reference
    {
        public string Text { get; }

        public Reference(string text)
        {
            Text = text;
        }
    }

    class Scripture
    {
        private readonly Reference reference;
        private readonly List<Word> words;
        private readonly Random random;

        public Scripture(Reference reference, string text)
        {
            this.reference = reference;
            this.words = text.Split(' ').Select(word => new Word(word)).ToList();
            this.random = new Random();
        }

        public string GetFullScripture()
        {
            return $"{reference.Text}: {string.Join(" ", words.Select(w => w.IsHidden ? "______" : w.Text))}";
        }

        public void HideRandomWord()
        {
            var visibleWords = words.Where(w => !w.IsHidden).ToList();
            if (visibleWords.Count > 0)
            {
                var index = random.Next(visibleWords.Count);
                visibleWords[index].Hide();
            }
        }
    }
}
