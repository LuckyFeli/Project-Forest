using System.Collections;
using UnityEngine;
using TMPro;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogObject[] allDialog;

    private Typewritereffect typewritereffect;
    public void writeText(int i)
    {
        typewritereffect = GetComponent<Typewritereffect>();
        CloseDialog();
        ShowDialogue(allDialog[i]);
    }

    public void ShowDialogue(DialogObject dialogObject)
    {
        dialogBox.SetActive(true);
        StartCoroutine(StepThroughDialog(dialogObject));
    }

    private IEnumerator StepThroughDialog(DialogObject dialogObject)
    {
           foreach (string dialog in dialogObject.Dialogue)
        {
            yield return typewritereffect.Run(dialog, textLabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.G));
        }

        CloseDialog();
    }

    private void CloseDialog()
    {
        dialogBox.SetActive(false);
        textLabel.text = string.Empty;
    }
    
}
