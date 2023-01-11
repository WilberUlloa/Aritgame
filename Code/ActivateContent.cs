using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateContent : MonoBehaviour
{
    public GameObject panel;
    public GameObject[] interfacesScroll;
    public int index;
    public bool interfaceStuatus;

    public void ActivatePanel(){panel.SetActive(true);}
    public void NoActivatePanel()
    {
        panel.SetActive(false);
        NoActivateInterfaces(0);
        NoActivateInterfaces(1);
        NoActivateInterfaces(2);
        NoActivateInterfaces(3);
        NoActivateInterfaces(4);
    }

    void Update()
    {
        if(interfaceStuatus)
        {
            ActivateInterfaces(index);
        }
    }
    
    public void ActivateInterfaces(int index)
    {
        ActivatePanel();
        interfacesScroll[index].SetActive(true);
    }

    public void NoActivateInterfaces(int index)
    {
        interfacesScroll[index].SetActive(false);
    }

}
