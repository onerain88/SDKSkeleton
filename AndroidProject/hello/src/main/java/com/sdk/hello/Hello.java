package com.sdk.hello;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.os.Handler;
import android.os.Looper;
import android.util.Log;

import com.unity3d.player.UnityPlayer;

import java.util.Random;

public class Hello {
    static final String TAG = "HELLO";

    public static void print(String message) {
        Log.i(TAG, message);
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

    public static void call() {
        Log.i(TAG, String.format("%d, %d",
                Looper.getMainLooper().getThread().getId(),
                Thread.currentThread().getId()));
        Handler handler = new Handler(Looper.getMainLooper());
        handler.post(new Runnable() {
            @Override
            public void run() {
                Log.i(TAG, String.format("runnable: %d, %d",
                        Looper.getMainLooper().getThread().getId(),
                        Thread.currentThread().getId()));
            }
        });
    }

    public static void callback(HelloCallback callback) {
        Handler handler = new Handler(Looper.myLooper());
        handler.post(new Runnable() {
            @Override
            public void run() {
                Log.i(TAG, String.format("%d, %d",
                        Looper.getMainLooper().getThread().getId(),
                        Thread.currentThread().getId()));
                callback.onMessage("I am from android...");
            }
        });
    }

    public static void callAsync(RandomCallback callback) {
        Handler handler = new Handler(Looper.myLooper());
        handler.post(new Runnable() {
            @Override
            public void run() {
                Random random = new Random();
                callback.onRandom(random.nextInt());
            }
        });
    }
}
