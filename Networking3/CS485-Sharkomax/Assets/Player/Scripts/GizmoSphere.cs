using UnityEngine;

public class GizmoSphere : MonoBehaviour {
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.02f);
    }
}