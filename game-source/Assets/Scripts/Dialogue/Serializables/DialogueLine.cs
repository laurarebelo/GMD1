[System.Serializable]
public class DialogueLine
{
    public string name;

    public string line;

    // DialogueLine holds information for a dialogue
    // including who spoke each line and what it said.
    public DialogueLine(string name, string line)
    {
        this.name = name;
        this.line = line;
    }
}