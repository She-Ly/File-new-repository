using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Dialogue 
{
    [TextArea(3, 10)]
    public string[] sentences;
    public bool[] hasDifferentInteractions; // Boolean array to indicate if each sentence has different interactions

    public Dialogue(int sentenceCount)
    {
        sentences = new string[sentenceCount];
        hasDifferentInteractions = new bool[sentenceCount];
    }
}
