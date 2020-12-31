using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraCentroler : MonoBehaviour
{
    [SerializeField] Transform player;

    Vector3 offset;
    void Start()
    {
        offset=transform.position-player.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 nextPos = new Vector3(transform.position.x, transform.position.y, offset.z+player.position.z);
        transform.position=Vector3.Lerp(transform.position, nextPos, 80);
    }
  
}
