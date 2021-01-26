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
        var pod = GetComponent<UnityHelpers.PodPhysics>();
        pod.strafeStick = new Vector2(player.GetAxis("MoveHor"), player.GetAxis("MoveVer"));
        pod.brake = player.GetAxis("Brake");
        pod.rotate = player.GetAxis("Rotate");
        pod.fly = player.GetAxis("Fly");
        // Debug.Log(pod.rotateCW + ", " + pod.rotateCCW);
    }
}
