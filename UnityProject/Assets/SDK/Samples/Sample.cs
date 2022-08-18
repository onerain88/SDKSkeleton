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
    }

    private void OnPrintClicked() {
        Hello.Print("Hello, world.");
    }

    private void OnDialogClicked() {
        Hello.ShowDialog();
    }
}
