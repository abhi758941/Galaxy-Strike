using TMPro;
using UnityEngine;

public class DialogueLines : MonoBehaviour
{
    [SerializeField] string[] timelineTextline;
    [SerializeField] TMP_Text dialougeText;
    int currentLine = 0;

    public void NextDialougeLine()
    {
        currentLine++;
        dialougeText.text = timelineTextline[currentLine];

    }

}
