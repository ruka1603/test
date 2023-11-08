using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public InputField nameInput;
    public GameObject bestData;
    public Text bestUserData;

    public void GoPlay()
    {
        PlayerPrefs.SetString("UserName", nameInput.text);
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainPlay");
    }

    public void BestScore()
    {
        
        if (PlayerPrefs.HasKey("BestPlayer"))
        {
            bestUserData.text = string.Format(
                "{0}:{1:N0}",
                PlayerPrefs.GetString("BestPlayer"),
                PlayerPrefs.GetFloat("BestScore"));

            bestData.SetActive(true);
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit()'
#endif
    }
}
