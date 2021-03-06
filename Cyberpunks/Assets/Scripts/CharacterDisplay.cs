﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class CharacterDisplay : MonoBehaviour
{
    [SerializeField] CharacterScreen[] characterScreens;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI nameTextShadow;

    public GameObject artworkImage;
    public Image powerBarImage;
    public Image healthBarImage;
    public Image timeBarImage;

    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetCharactersData();
    }

    private void SetCharactersData()
    {
        nameText.text = characterScreens.ElementAt(index).name;
        nameTextShadow.text = characterScreens.ElementAt(index).name;

        nameText.colorGradient = new VertexGradient(
            new Color(characterScreens.ElementAt(index).nameTopColor.r,
            characterScreens.ElementAt(index).nameTopColor.g,
            characterScreens.ElementAt(index).nameTopColor.b),

            new Color(characterScreens.ElementAt(index).nameTopColor.r,
            characterScreens.ElementAt(index).nameTopColor.g,
            characterScreens.ElementAt(index).nameTopColor.b),

            new Color(characterScreens.ElementAt(index).nameBottomColor.r,
            characterScreens.ElementAt(index).nameBottomColor.g,
            characterScreens.ElementAt(index).nameBottomColor.b),

            new Color(characterScreens.ElementAt(index).nameBottomColor.r,
            characterScreens.ElementAt(index).nameBottomColor.g,
            characterScreens.ElementAt(index).nameBottomColor.b));

        artworkImage.GetComponent<SpriteRenderer>().sprite = characterScreens.ElementAt(index).artwork;

        powerBarImage.fillAmount = characterScreens.ElementAt(index).power;
        healthBarImage.fillAmount = characterScreens.ElementAt(index).health;
        timeBarImage.fillAmount = characterScreens.ElementAt(index).time;
    }

    // Update is called once per frame
    void Update()
    {
        SetCharactersData();
        NextCharacter();
        LastCharacter();
    }

    public void NextCharacter()
    {
        if (index + 1 == characterScreens.Length)
        {
            return;
        }
        index += 1;
        characterScreens.ElementAt(index);
    }

    public void LastCharacter()
    {
        if (index == 0)
        {
            return;
        }
        index -= 1;
        characterScreens.ElementAt(index);
    }
}
