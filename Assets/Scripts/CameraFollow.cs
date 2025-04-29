using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float minY = 2f;
    public float maxY = 10f;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void LateUpdate()
    {
        if (target == null) return;

        float targetY = Mathf.Clamp(target.position.y, minY, maxY);

        transform.position = new Vector3(
            initialPosition.x,
            targetY,
            initialPosition.z
        );
    }
}
