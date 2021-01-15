using UnityEngine;

public class MultiplatformCameraRig : MonoBehaviour
{
    private bool prevIsXR;
    public GameObject xrRig;
    public GameObject nonXRRig;

    void Start()
    {
        UpdateRigs();
    }
    void Update()
    {
        if (XRInit.IsXREnabled != prevIsXR)
        {
            UpdateRigs();
            prevIsXR = XRInit.IsXREnabled;
        }
    }

    private void UpdateRigs()
    {
        xrRig.SetActive(XRInit.IsXREnabled);
        nonXRRig.SetActive(!XRInit.IsXREnabled);
    }
}
