using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    PlayerController controller;
    TMP_Text text;

    void Start()
    {
        controller = GameObject.Find("Player_Place").GetComponent<PlayerController>();
        Debug.Log(controller.name);
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        text.text = "HP: " + controller.getPlayerHealth();
    }
}