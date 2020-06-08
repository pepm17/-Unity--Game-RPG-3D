using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    private Transform dialogueBox;
    private Text dialogueBoxTextBody;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        this.dialogueBox = UIController.instance.Canvas.Find("Dialogue Box");
        this.dialogueBoxTextBody = UIController.instance.Canvas.Find("Dialogue Box/Background/Text").GetComponent<Text>();
    }

   public void PrintDialogueBox(string dialogue)
    {
        this.dialogueBox.gameObject.SetActive(true);
        this.dialogueBoxTextBody.text = dialogue;
        InputManager.OnPressUp += CloseDialogueBoxCallBack;
    }

    public void CloseDialogueBox()
    {
        this.dialogueBox.gameObject.SetActive(false);
    }

    public void CloseDialogueBoxCallBack()
    {
        CloseDialogueBox();
        InputManager.OnPressUp -= CloseDialogueBoxCallBack;
    }
}
