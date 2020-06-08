using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField]
    private string[] dialogues;
    private int dialogueIndex;
    // Start is called before the first frame update

    public void ShowDialogue()
    {
        if(this.dialogueIndex >= (this.dialogues.Length))
        {
            DialogueManager.instance.CloseDialogueBox();
            this.dialogueIndex = 0;
        }
        else
        {
            DialogueManager.instance.PrintDialogueBox(name + ": " + this.dialogues[this.dialogueIndex]);
            this.dialogueIndex++;
        }
    }
}
