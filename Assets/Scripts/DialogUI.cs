using System.Collections;
using UnityEngine;
using TMPro;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogObject testDialog;

    private Typewritereffect typewritereffect;
    void Start()
    {
        typewritereffect = GetComponent<Typewritereffect>();
        ShowDialogue(testDialog);
    }

    public void ShowDialogue(DialogObject dialogObject)
    {
        StartCoroutine(StepThroughDialog(dialogObject));
    }

    private IEnumerator StepThroughDialog(DialogObject dialogObject)
    {
           foreach (string dialog in dialogObject.Dialogue)
        {
            yield return typewritereffect.Run(dialog, textLabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.G));
        }
    }
    
}
