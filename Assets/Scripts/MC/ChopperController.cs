using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChopperController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI weighText;

    private float actualMass;
    private float expectedMass;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addMass(float mass)
    {
        actualMass += mass;
        weighText.text = actualMass.ToString("F2");
    }
}
