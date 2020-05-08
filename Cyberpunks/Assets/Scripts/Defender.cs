using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int donutCost = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddDonuts(int amount)
    {
        FindObjectOfType<DonutDisplay>().AddDonuts(amount);
    }

    public int GetDonutCost()
    {
        return donutCost;
    }
}
