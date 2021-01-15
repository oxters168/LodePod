using System.Collections;
using UnityEngine;
using UnityEngine.XR.Management;

public class XRInit : MonoBehaviour
{
    public static bool IsXREnabled { get; private set; }

    void Start()
    {
        StartCoroutine(StartXR());
    }

    public IEnumerator StartXR()
    {
        Debug.Log("Initializing XR...");
        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();

        if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.LogError("Initializing XR Failed. Directing to Normal Interaciton Mode...!.");
            // StopXR();
            // DirectToNormal();
        }
        else
        {
            Debug.Log("Initialization Finished.Starting XR Subsystems...");

            //Try to start all subsystems and check if they were all successfully started ( thus HMD prepared).
            IsXREnabled = XRGeneralSettings.Instance.Manager.activeLoader.Start();              
            if(IsXREnabled)
            {
                Debug.Log("All Subsystems Started!");
            }
            else
            {
                Debug.LogError("Starting Subsystems Failed. Directing to Normal Interaciton Mode...!");
                // StopXR();
                // DirectToNormal();
            }
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
 }
