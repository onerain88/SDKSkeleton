#if UNITY_EDITOR || UNITY_STANDALONE

using System.Threading.Tasks;
using UnityEngine;

internal class HelloStandalone : IHello {
    public void Print(string message) {
        Debug.Log(message);
    }

    public void ShowDialog() {
        throw new System.NotImplementedException();
    }

    public void Call() {
        throw new System.NotImplementedException();
    }

    public void Callback() {
        throw new System.NotImplementedException();
    }

    public async Task<int> CallAsync() {
        TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
        _ = Task.Run(() => {
            System.Random random = new System.Random();
            int rand = random.Next();
            tcs.TrySetResult(rand);
        });
        return await tcs.Task;
    }
}

#endif