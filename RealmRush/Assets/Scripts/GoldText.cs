using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldText : MonoBehaviour
{
    Bank bank;
    TextMeshProUGUI goldText;
    // Start is called before the first frame update
    void Start()
    {
        goldText = GetComponent<TextMeshProUGUI>();
        bank = FindObjectOfType<Bank>();
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = bank.CurrentBalance.ToString("Gold: 00000");
    }
}
