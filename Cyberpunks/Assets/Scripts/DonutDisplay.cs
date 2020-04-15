using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DonutDisplay : MonoBehaviour
{
    [SerializeField] int donuts = 10;
    [SerializeField] TextMeshProUGUI donutText;

    // Start is called before the first frame update
    void Start()
    {
        donutText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void UpdateDisplay()
    {
        donutText.text = donuts.ToString();
    }

    public void AddDonuts(int amount)
    {
        donuts += amount;
        UpdateDisplay();
    }

    public void SpendDonuts(int amount)
    {
        if (donuts - amount >= 0)
        {
            donuts -= amount;
            UpdateDisplay();
        }
    }
}