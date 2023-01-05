using UnityEngine;
using UnityEngine.UI;

public class DataSave : MonoBehaviour
{
    [SerializeField] private InputField UserName;
    [SerializeField] private Slider Volume;

    [SerializeField] private string DefaulUserName = "";
    [SerializeField] private float DefaulVolume = 1f;
    
    public void Start()
    {
       loadPrefs(); 
    }

    public void loadPrefs()
    {
        if(PlayerPrefs.HasKey("KeyUserName"))
        {
            UserName.text = PlayerPrefs.GetString("KeyUserName");
        }
        else
        {
            UserName.text = DefaulUserName;
            PlayerPrefs.SetString("KeyUserName", DefaulUserName);
        }

        if(PlayerPrefs.HasKey("KeyVolume"))
        {
            Volume.value = PlayerPrefs.GetFloat("KeyVolume");
        }
        else
        {
            Volume.value = DefaulVolume;
            PlayerPrefs.SetFloat("KeyVolume", DefaulVolume);
        }
    }

    public void SetUserName()
    {
        PlayerPrefs.SetString("KeyUserName", UserName.text);
    }

    public void SetVolume()
    {
        PlayerPrefs.SetFloat("KeyVolume", Volume.value);
    }

}
