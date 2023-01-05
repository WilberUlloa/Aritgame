using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
   [SerializeField] TextMeshProUGUI textProgress;
   [SerializeField] Slider sliderProgress;

   private void Update()
   {
        StartCoroutine(LoadingProgress());
        
   }
   
   IEnumerator LoadingProgress()
   {
    sliderProgress.gameObject.SetActive(true);
    AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(1);

    while (loadingOperation.isDone == false)
    {
        float vprogress = Mathf.Clamp01(loadingOperation.progress / .09f);
        sliderProgress.value = vprogress;
        textProgress.text = "" + vprogress * 100 + "%";
        yield return null;
    }
   }
}
