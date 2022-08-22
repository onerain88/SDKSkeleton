#if UNITY_ANDROID

using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

class HelloCallback : AndroidJavaProxy {
    public HelloCallback() : base("com.sdk.hello.HelloCallback") {}

    void onMessage(string message) {
        Debug.Log($"{Thread.CurrentThread.ManagedThreadId} : {message}");
    }
}

class RandomCallback : AndroidJavaProxy {
    internal TaskCompletionSource<int> Tcs;

    public RandomCallback() : base("com.sdk.hello.RandomCallback") {}

    void onRandom(int rand) {
        Debug.Log($"{Thread.CurrentThread.ManagedThreadId} : {rand}");
        Tcs?.TrySetResult(rand);
    }
}

internal class HelloAndroid : IHello {
    public void Print(string message) {
        using (AndroidJavaClass javaCls = new AndroidJavaClass("com.sdk.hello.Hello")) {
            javaCls.CallStatic("print", message);
        }
    }

    public void ShowDialog() {
        using (AndroidJavaClass javaCls = new AndroidJavaClass("com.sdk.hello.Hello")) {
            javaCls.CallStatic("showDialog");
        }
    }

    public void Call() {
        using (AndroidJavaClass javaCls = new AndroidJavaClass("com.sdk.hello.Hello")) {
            javaCls.CallStatic("call");
        }
    }

    public void Callback() {
        using (AndroidJavaClass javaCls = new AndroidJavaClass("com.sdk.hello.Hello")) {
            javaCls.CallStatic("callback", new HelloCallback());
        }
    }

    public Task<int> CallAsync() {
        TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
        using (AndroidJavaClass javaCls = new AndroidJavaClass("com.sdk.hello.Hello")) {
            javaCls.CallStatic("callAsync", new RandomCallback {
                Tcs = tcs
            });
        }
        return tcs.Task;
    }
}

#endif