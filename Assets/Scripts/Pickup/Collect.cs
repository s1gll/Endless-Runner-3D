using UnityEngine;

 public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(gameObject);
            
        }
    }
}
