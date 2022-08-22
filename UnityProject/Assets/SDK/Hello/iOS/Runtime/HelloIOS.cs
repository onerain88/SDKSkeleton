#if UNITY_IOS

using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class HelloIOS : IHello {
    [DllImport("__Internal")]
    private static extern void _Print(string message);

    [DllImport("__Internal")]
    private static extern void _ShowDialog();

    [DllImport("__Internal")]
    private static extern void _Call();

    delegate void OnMessage(string message);

    [AOT.MonoPInvokeCallback(typeof(OnMessage))]
    private static void HelloCallback(string message) {
        Debug.Log($"{Thread.CurrentThread.ManagedThreadId} : {message}");
    }

    [DllImport("__Internal")]
    private static extern void _RegisterHelloCallback(OnMessage func);

    /// <summary>
    /// 异步调用
    /// </summary>
    delegate void OnRandom(int rand);

    [AOT.MonoPInvokeCallback(typeof(OnRandom))]
    private static void OnRandomCallback(int rand) {
        tcs?.TrySetResult(rand);
    }

    [DllImport("__Internal")]
    private static extern void _RegisterRandomCallback(OnRandom func);

    public void Print(string message) {
        _Print(message);
    }

    public void ShowDialog() {
        _ShowDialog();
    }

    public void Call() {
        Task.Run(() => {
            _Call();
        });
    }

    public void Callback() {
        _RegisterHelloCallback(HelloCallback);
    }

    static TaskCompletionSource<int> tcs;

    public Task<int> CallAsync() {
        tcs = new TaskCompletionSource<int>();
        _RegisterRandomCallback(OnRandomCallback);
        return tcs.Task;
    }
}

#endif