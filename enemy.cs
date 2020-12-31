using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    gameManager gm;
    private void Start() {
        gm=FindObjectOfType<gameManager>();
    }
    private void OnTriggerEnter(Collider collision) {
        if(collision.transform.tag=="bullet") {
            gm.addKill();
            gameObject.SetActive(false);
        }
    }
}
