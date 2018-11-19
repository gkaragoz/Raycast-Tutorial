using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRay : MonoBehaviour {

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
            AnalyseTarget();
        }
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

    public void AnalyseTarget() {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward * shootDistance, Color.red, 0.5f);

        if (Physics.Raycast(ray, out hit, shootDistance)) {
            target = hit.transform;
        } else {
            target = null;
        }
    }

}
