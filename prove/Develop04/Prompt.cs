public class Prompt
{
    private bool _used;
    private string _prompt;

    public Prompt(string prompt)
    {
        _used = false;
        _prompt = prompt;
    }

    public bool IsUsed()
    {
        return _used;
    }

    public string GetPrompt()
    {
        return _prompt;
    }

    public void MarkUsed()
    {
        _used = true;
    }

    public void MarkUnused()
    {
        _used = false;
    }

    public static List<Prompt> GetUnused (List<Prompt> sourceList)
    {
        List<Prompt> result = new List<Prompt>();
        foreach (Prompt prompt in sourceList)
        {
            if (!prompt.IsUsed())
            {
                result.Add(prompt);
            }
        }

        // If the new list is empty (all prompts have been used), reset it
        if (result.Count == 0)
        {
            foreach (Prompt prompt in sourceList)
            {
                prompt.MarkUnused();
                result.Add(prompt);
            }
        }
        return result;
    }
}