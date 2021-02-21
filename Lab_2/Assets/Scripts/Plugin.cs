using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plugin : MonoBehaviour
{
    const string pluginName = "com.exanple.unity2.MyPlugin";

    static AndroidJavaClass _pluginClass;
    static AndroidJavaObject _pluginInstance;

    public static AndroidJavaClass PluginClass
    {
        get
        {
            if (_pluginClass==null)
            {
                _pluginClass = new AndroidJavaClass(pluginName);
            }
            return _pluginClass;
        }
    }

    public static AndroidJavaObject PluginInstance
    {
        get
        {
            if (_pluginInstance == null)
            {
                _pluginInstance = PluginClass.CallStatic<AndroidJavaObject>("getInstance");
            }
            return _pluginInstance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Output: " + getOutput());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int getOutput()
    {
        if (Application.platform == RuntimePlatform.Android)
            return PluginInstance.Call<int>("getOutput", new object[] { 1, 2 });
        else return 0;
    }
}
