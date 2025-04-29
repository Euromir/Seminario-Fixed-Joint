using UnityEngine;

public class Victory : MonoBehaviour
{
    [SerializeField] private GameObject victoryCanvas;
    private string playerTag = "Player";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            victoryCanvas.SetActive(true);
        }
    }
}
