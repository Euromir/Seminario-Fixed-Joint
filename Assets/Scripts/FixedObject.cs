using UnityEngine;
using System.Collections;

public class FixedObject : MonoBehaviour
{
    public int requiredClicks = 3;
    private int currentClicks = 0;
    private FixedJoint fixedJoint;
    private Vector3 originalPosition;
    private bool isShaking = false;
    public float shakeAmount = 0.1f;
    public float shakeDuration = 0.2f;
    public bool disableCollision;

    void Start()
    {
        fixedJoint = GetComponent<FixedJoint>();
        originalPosition = transform.position;
    }

    void OnMouseDown()
    {
        if (currentClicks < requiredClicks)
        {
            currentClicks++;

            if (!isShaking)
            {
                StartCoroutine(Shake());
            }

            if (currentClicks >= requiredClicks)
            {
                ReleaseObject();
            }
        }
    }

    void ReleaseObject()
    {
        if (fixedJoint != null)
        {
            Destroy(fixedJoint);
        }

        if (disableCollision)
        {
            Collider collider = GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = false;
            }
        }
    }

    private IEnumerator Shake()
    {
        isShaking = true;

        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            transform.position = originalPosition + Random.insideUnitSphere * shakeAmount;
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.position = originalPosition;
        isShaking = false;
    }
}
