using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeleType : MonoBehaviour
{
    public float letterPause = 0.2f;
    string message;
    TextMeshProUGUI textComp;

    // Start is called before the first frame update
    void Start()
    {
        textComp = GetComponent<TextMeshProUGUI>();
        message = textComp.text;
        textComp.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        while (true)
        {
            foreach (char letter in message.ToCharArray())
            {
                textComp.text += letter;
                yield return new WaitForSeconds(letterPause);
            }
            textComp.text = "";
        }
    }
}
