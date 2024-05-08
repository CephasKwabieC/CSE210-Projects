public class PromptGenerator
{
    private List<string> _prompts;
    private Random _random;

    public PromptGenerator()
    {
        _prompts = new List<string>();
        _random = new Random();
    }

    public void AddPrompt(string prompt)
    {
        _prompts.Add(prompt);
    }

    public string GetRandomPrompt()
    {
        if (_prompts.Count == 0)
        {
            return "No prompts available.";
        }

        int index = _random.Next(0, _prompts.Count);
        return _prompts[index];
    }
}