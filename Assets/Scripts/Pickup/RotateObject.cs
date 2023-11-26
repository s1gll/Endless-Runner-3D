using UnityEngine;

public class RotateObject : MonoBehaviour
{
   private readonly int _rotateSpeed = 1;
   
   private void Update()
    {
        transform.Rotate(0, _rotateSpeed,0,Space.World);
    }
}
