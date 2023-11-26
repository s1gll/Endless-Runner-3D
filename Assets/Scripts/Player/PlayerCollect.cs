using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [SerializeField] private AudioSource pickupSound;
   
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.TryGetComponent(out ICollectible collectible))
        {
            collectible.Collect();
            pickupSound.Stop();
            pickupSound.Play();
        }
    }
}
