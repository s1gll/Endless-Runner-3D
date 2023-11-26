using UnityEngine;
public class CoinPickup : Pickup, ICollectible
{
    public void Collect()
    {
        CollactableControl.AddCoin();
    }
}

