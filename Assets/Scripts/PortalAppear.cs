using UnityEngine;

public class PortalAppear : MonoBehaviour
{
    public GameObject portal; // The portal to appear after the delay
    public float delay = 6f; // The delay in seconds

    void Start()
    {
        // Initially hide the portal
        if (portal != null)
        {
            portal.SetActive(false);
        }
        
        // Invoke the method to show the portal after the delay
        Invoke("ShowPortal", delay);
    }

    void ShowPortal()
    {
        if (portal != null)
        {
            portal.SetActive(true);
        }
    }
}
