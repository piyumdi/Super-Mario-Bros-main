using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviourPunCallbacks
{
    void Start()
    {
        // Random position to spawn
        Vector3 randomPos = new Vector3(Random.Range(-5f, 5f), 2, 0);

        // Instantiate the player prefab via Photon
        PhotonNetwork.Instantiate("Mario", randomPos, Quaternion.identity);
    }
}
