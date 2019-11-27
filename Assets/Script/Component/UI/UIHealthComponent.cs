using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthComponent : MonoBehaviour {

    private HealthComponent component; // target for the healthbar to read from

    // Start is called before the first frame update
    private void Start() {
        component = GlobalManager.Instance.player.GetComponent<HealthComponent>();
        if (!component) Debug.Log("Could not find a UIHealthComponent! Does GameManager 'player' have a HealthComponent?");
        else {
            GetComponent<Slider>().value = component.GetHealthPercent();
        }
    }

    // Update is called once per frame
    private void Update() {
        GetComponent<Slider>().value = component.GetHealthPercent();
    }
}
