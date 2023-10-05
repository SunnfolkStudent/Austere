using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDialogue
{
    public string name;

    [TextArea(3, 10)] 
    public List<string> sentences;
}
