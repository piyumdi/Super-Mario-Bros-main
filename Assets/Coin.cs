using UnityEngine;
using Photon.Pun;

public class Coin : MonoBehaviourPun
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Mario")) return;

        PhotonView playerPhotonView = collision.GetComponent<PhotonView>();

        if (playerPhotonView != null && playerPhotonView.IsMine)
        {
            collision.GetComponent<PlayerScore>().AddScore(1);

            // Destroy the coin across the network
            Destroy(gameObject);
        }
    }
}
