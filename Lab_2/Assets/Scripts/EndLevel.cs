using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class EndLevel : MonoBehaviour
{
    static public string path;

    void Start()
    {
        path = Path.Combine(Application.dataPath, "Save.json");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();
        if (unit && unit is Character)
        {
            this.SaveFileJSON(unit);
            SceneManager.LoadScene("Main");
        }
    }

    private void SaveFileJSON(Unit character)
    {
        string json = JsonUtility.ToJson(character);
        Debug.Log(json);
        File.WriteAllText(path, json);
    }
}
