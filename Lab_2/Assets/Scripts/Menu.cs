using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_InputField inputField;

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }

    public void PlayGame ()
    {
        if (!inputField.text.Equals(""))
        {
            PlayerPrefs.SetString("Name", inputField.text);
            PlayerPrefs.Save();
            SceneManager.LoadScene(1);
        }
    }
}
