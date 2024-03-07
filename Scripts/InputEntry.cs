using System;

[Serializable]
public class InputEntry
{
    public string playerName;
    public int score;

    public InputEntry(string name, int score) // This is the constructor for the InputEntry class
    {
        playerName = name;
        this.score = score;
    }
}

