using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sample : MonoBehaviour {
    private void Awake() {
        Button printBtn = transform.Find("Container/Print").GetComponent<Button>();
        printBtn.onClick.AddListener(OnPrintClicked);

        Button dialogBtn = transform.Find("Container/Dialog").GetComponent<Button>();
        dialogBtn.onClick.AddListener(OnDialogClicked);

        Button runInBackgroundBtn = transform.Find("Container/Call").GetComponent<Button>();
        runInBackgroundBtn.onClick.AddListener(OnCallClicked);

        Button callbackBtn = transform.Find("Container/Callback").GetComponent<Button>();
        callbackBtn.onClick.AddListener(OnCallbackClicked);

        Button callAsyncBtn = transform.Find("Container/CallAsync").GetComponent<Button>();
        callAsyncBtn.onClick.AddListener(OnCallAsyncClicked);
    }

    private void OnPrintClicked() {
        Hello.Print("Hello, world.");
    }

    private void OnDialogClicked() {
        Hello.ShowDialog();
    }

    private void OnCallClicked() {
        Hello.Call();
    }

    private void OnCallbackClicked() {
        Hello.Callback();
    }

    private async void OnCallAsyncClicked() {
        int rand = await Hello.CallAsync();
        Debug.Log($"Call async rand: {rand}");
    }
}
