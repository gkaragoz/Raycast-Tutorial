using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugRay : MonoBehaviour {

    public GameObject targetEnemy;

    private void Update() {
        SetTargetEnemy();
    }

    private void SetTargetEnemy() {
        Debug.DrawRay(gameObject.transform.position, transform.forward * 50, Color.green);

        RaycastHit objectHit;
        // Shoot raycast
        if (Physics.Raycast(transform.position, transform.forward, out objectHit, 50)) {
            targetEnemy = objectHit.collider.gameObject;
        } else {
            targetEnemy = null;
        }
    }
}
