using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowScenes : MonoBehaviour
{
    public int index;
    public bool SceneStatus;

    void Update()
    {
        if(SceneStatus)
        {
            ShowScene(index);
        }
                
    }

    public void ShowScene(int index)
    {
        SceneManager.LoadScene(index);   
    }
}
