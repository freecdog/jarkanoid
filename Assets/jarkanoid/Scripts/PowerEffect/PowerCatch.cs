using GamePlatform;
using UnityEngine;

public class PowerCatch : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Platform")
        {
            var platform = FindObjectOfType<PlatformControl>();
            if (platform != null)
            {
                Debug.Log("platform speed increased");
                platform.speed *= 1.25f;
            }
            
            Destroy(this.gameObject);
        }
    }
}
