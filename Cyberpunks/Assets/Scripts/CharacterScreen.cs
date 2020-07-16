using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

[CreateAssetMenu(fileName = "New Cop", menuName = "Cop")]
public class CharacterScreen : ScriptableObject
{
    public new string name;
    public Color nameTopColor;
    public Color nameBottomColor;

    public Sprite artwork;

    public float power;
    public float health;
    public float time;
}
