#if UNITY_ANDROID

using UnityEngine;

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
}

#endif