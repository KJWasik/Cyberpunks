using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] AudioClip buttonSound;
    [SerializeField] [Range(0, 1)] float buttonSoundVolume = 0.3f;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => PlayClickSound());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PlayClickSound()
    {
        if (buttonSound)
        {
            AudioSource.PlayClipAtPoint(buttonSound, Camera.main.transform.position, buttonSoundVolume);
        }
    }
}
