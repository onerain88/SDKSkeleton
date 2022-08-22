using System.Threading.Tasks;

public class Hello
{
    static IHello platformWrapper;

    static Hello() {
#if UNITY_EDITOR || UNITY_STANDALONE
        platformWrapper = new HelloStandalone();
#elif UNITY_IOS
        platformWrapper = new HelloIOS();
#elif UNITY_ANDROID
        platformWrapper = new HelloAndroid();
#endif
    }

    public static void Print(string message) {
        platformWrapper?.Print(message);
    }

    public static void ShowDialog() {
        platformWrapper?.ShowDialog();
    }

    public static void Call() {
        platformWrapper?.Call();
    }

    public static void Callback() {
        platformWrapper?.Callback();
    }

    public static Task<int> CallAsync() {
        return platformWrapper?.CallAsync();
    }
}
