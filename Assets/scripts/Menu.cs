using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject MenuPanel;
    public void Toggle()
    {
        MenuPanel.SetActive(!MenuPanel.activeSelf);
    }
}
