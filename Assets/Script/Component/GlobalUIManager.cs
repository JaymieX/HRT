using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalUIManager : MonoBehaviour
{
    public static GlobalUIManager Instance { get; private set; }

    public Canvas ui;

    public List<GameObject> elementList;

    // Start is called before the first frame update
    private void Awake() {

        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        }
        else {
            Instance = this;
        }

        if (!ui) Debug.Log("No canvas set for the UIManager!");
        else {
            for (int i = 0; i < ui.transform.childCount; i++) {
                elementList.Add(ui.transform.GetChild(i).gameObject);
            }
        }
    }
}
