#if UNITY_IOS

using System.Runtime.InteropServices;

public class HelloIOS : IHello {
    [DllImport("__Internal")]
    private static extern void _Print(string message);

    [DllImport("__Internal")]
    private static extern void _ShowDialog();

    public void Print(string message) {
        _Print(message);
    }

    public void ShowDialog() {
        _ShowDialog();
    }
}

#endif