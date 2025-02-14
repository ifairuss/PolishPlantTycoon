using UnityEngine;

public class MachineBoxStorage : MonoBehaviour
{
    public int BoxInStorage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NewBox" || other.gameObject.tag == "Box")
        {
            BoxInStorage++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "NewBox" || other.gameObject.tag == "Box")
        {
            BoxInStorage--;
        }
    }
}
