namespace Dialogue
{
    [System.Serializable]
    public class DialogueLineList
    {
        // DialogueLineList exists so that I can serialize an array
        // of dialogue lines in the json file :)
        public DialogueLine[] dialogue;
    }
}