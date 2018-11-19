using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistakeRay : MonoBehaviour {

    public float rayDistance;
    public Transform targetObject;

    private void Update() {
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1)) {
            targetObject = hit.transform;
        } else {
            targetObject = null;
        }
    }

}
