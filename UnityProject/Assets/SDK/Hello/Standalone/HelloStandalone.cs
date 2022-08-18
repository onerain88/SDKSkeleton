#if UNITY_EDITOR || UNITY_STANDALONE

using UnityEngine;

internal class HelloStandalone : IHello {
    public void Print(string message) {
        Debug.Log(message);
    }

    public void ShowDialog() {
        throw new System.NotImplementedException();
    }
}

#endif