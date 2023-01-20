using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovePanel : MonoBehaviour
{
    public GameObject HomenPanel;
    public GameObject TetsPanel;

    public void Start()
    {
        TetsPanel.SetActive(false);
    }
    
    public void ShowTestPanel()
    {
        TetsPanel.SetActive(true);
        HomenPanel.SetActive(false);
    }
}
