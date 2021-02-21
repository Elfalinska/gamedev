package com.example.unity2;

import android.util.Log;

public class MyPlugin {
    private static final MyPlugin ourInstance = new MyPlugin();

    public static MyPlugin getInstance() {
        return ourInstance;
    }

    private MyPlugin() {
        Log.i("MyOutput", "Created plugin");
    }

    public int getOutput(int a, int b) {
       return a+b;
    }
}
