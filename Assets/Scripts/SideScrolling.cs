using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class SideScrolling : MonoBehaviour
{
    private Transform player;

    private void Start()
    {
        foreach (var p in FindObjectsOfType<PhotonView>())
        {
            if (p.IsMine)
            {
                player = p.transform;
                break;
            }
        }
    }

    private void LateUpdate()
    {
        if (player == null) return;

        Vector3 cameraPosition = transform.position;
        cameraPosition.x = Mathf.Max(cameraPosition.x, player.position.x);
        transform.position = cameraPosition;
    }
}

/*
public class SideScrolling : MonoBehaviour
{
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Mario").transform;
    }
    private void LateUpdate()
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = Mathf.Max(cameraPosition.x, player.position.x);
        transform.position = cameraPosition;
    }

}
*/