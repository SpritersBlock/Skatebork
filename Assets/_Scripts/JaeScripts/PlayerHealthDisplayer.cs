using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplayer : MonoBehaviour {

    public Text healthText;

    // Use this for initialization
    void Start () {
        UpdateHealthText(5);
    }

    // Update is called once per frame
    void Update () {

    }

    public void UpdateHealthText (int newHealth)
    {
        healthText.text = "YOUR HP: " + newHealth;
    }
}
