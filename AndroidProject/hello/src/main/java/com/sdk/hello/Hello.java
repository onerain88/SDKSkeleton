package com.sdk.hello;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.util.Log;

import com.unity3d.player.UnityPlayer;

public class Hello {
    public static void print(String message) {
        Log.i("Hello", message);
    }

    public static void showDialog() {
        // TODO 优化 Context
        new AlertDialog.Builder(UnityPlayer.currentActivity)
                .setTitle("Hello Dialog")
                .setMessage("I am from unity.")
                .setPositiveButton(android.R.string.yes, new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int which) {
                        // Continue with delete operation
                    }
                })
                .setNegativeButton(android.R.string.no, null)
                .show();
    }
}
