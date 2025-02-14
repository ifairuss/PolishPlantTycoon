using UnityEngine;

public class PlayerStuck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.position = Vector3.zero;
        }
    }
}
