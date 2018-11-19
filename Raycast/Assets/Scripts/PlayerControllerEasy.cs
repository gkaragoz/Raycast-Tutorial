using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerEasy : MonoBehaviour {

    public float movementSpeed = 2f;
    public float rotationSpeed = 60f;

    public float shootDistance = 2f;

    public Transform target;

    private void Update() {
        Vector3 axises = GetInputs();

        if (axises != Vector3.zero) {
            Move(axises);
        }

        Rotate();

        if (Input.GetKeyDown(KeyCode.Space)) {
            KickTarget();
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, Vector3.one * shootDistance);
    }

    private Vector3 GetInputs() {
        return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    public void Move(Vector3 direction) {
        transform.Translate(direction * movementSpeed * Time.deltaTime);
    }

    public void Rotate() {
        if (Input.GetKey(KeyCode.Q)) {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.E)) {
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        }
    }

    public void KickTarget() {
        if (IsAvailableToKick()) {
            Debug.Log("I kicked the ball.");
        } else {
            Debug.Log("You need to go closer to the target.");
        }
    }

    public bool IsAvailableToKick() {
        float distance = Vector3.Distance(transform.position, target.position);

        return distance <= shootDistance ? true : false;
    }

}
