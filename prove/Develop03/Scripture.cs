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
