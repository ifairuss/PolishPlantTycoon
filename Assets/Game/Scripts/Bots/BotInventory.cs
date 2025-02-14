using UnityEngine;

public class BotInventory : MonoBehaviour
{
    [HideInInspector] public int BoxsInStorageBot;

    [HideInInspector] public bool BotWalkingToMachine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NewBox" && !BotWalkingToMachine && BoxsInStorageBot < 3)
        {
            BoxsInStorageBot++;
            other.transform.SetParent(transform);
            other.transform.position = transform.position;
            other.transform.localRotation = Quaternion.Euler(0, 90, 0);
            other.gameObject.tag = "Box";

            if (BoxsInStorageBot == 1) { other.transform.position = transform.position + Vector3.up * 0.75f; }
            if (BoxsInStorageBot == 2) { other.transform.position = transform.position + Vector3.up * 1.90f; }
            if (BoxsInStorageBot == 3) { other.transform.position = transform.position + Vector3.up * 2.90f; }
        }
    }
}
