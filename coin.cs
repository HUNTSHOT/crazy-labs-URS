using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    [SerializeField] int coinAmunt;
    gameManager gm;
    private void Awake() {
        gm=FindObjectOfType<gameManager>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Player") {
            gm.addCoin(coinAmunt);
            gameObject.SetActive(false);
        }
    }
}
