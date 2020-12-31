using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet :MonoBehaviour {
    [SerializeField] float speed;
    [SerializeField] float activeTime;

    private void Start() {
        Destroy(this.gameObject, activeTime);
    }
    private void Update() {
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }
    
    private void OnTriggerEnter(Collider collision) {
        gameObject.SetActive(false);
    }
}
