
    [System.Serializable]
    public class DialogueSlimeSpawn
    {
        public bool r;
        public bool g;
        public bool b;

        public int slimeNumber;

        public DialogueSlimeSpawn(bool r, bool g, bool b, int slimeNumber)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.slimeNumber = slimeNumber;
        }
    }
