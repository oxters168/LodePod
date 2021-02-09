using UnityEngine;
using Rewired;

public class PlayerInput : MonoBehaviour
{
    public int playerId = 0;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(playerId);   
    }

    // Update is called once per frame
    void Update()
    {
        var devices = FindObjectsOfType<UnityEngine.XR.Interaction.Toolkit.XRController>();
        float leftTriggerValue = 0;
        float rightTriggerValue = 0;
        Vector2 leftStick = Vector2.zero;
        Vector2 rightStick = Vector2.zero;
        if (devices.Length > 0)
        {
            var leftController = devices[0].controllerNode == UnityEngine.XR.XRNode.LeftHand ? devices[0].inputDevice : devices[1].inputDevice;
            var rightController = devices[0].controllerNode == UnityEngine.XR.XRNode.RightHand ? devices[0].inputDevice : devices[1].inputDevice;
            rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.trigger, out rightTriggerValue);
            leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.trigger, out leftTriggerValue);
            leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out leftStick);
            rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out rightStick);
        }

        var pod = GetComponent<UnityHelpers.PodPhysics>();
        pod.strafeStick = new Vector2(player.GetAxis("MoveHor"), player.GetAxis("MoveVer")) + leftStick;
        pod.brake = player.GetAxis("Brake") + leftTriggerValue;
        pod.rotate = player.GetAxis("Rotate") + rightStick.x;
        pod.fly = player.GetAxis("Fly") + rightTriggerValue;
        // Debug.Log(pod.rotateCW + ", " + pod.rotateCCW);
    }
}
