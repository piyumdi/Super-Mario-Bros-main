/*using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;

public class PlayerScore : MonoBehaviour
{
    public int currentScore = 0;

    public void AddScore(int amount)
    {
        currentScore += amount;

        // Sync the updated score across the network
        Hashtable scoreProp = new Hashtable();
        scoreProp["Score"] = currentScore;
        PhotonNetwork.LocalPlayer.SetCustomProperties(scoreProp);
    }
}
*/

using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;

public class PlayerScore : MonoBehaviour
{
    public int currentScore = 0;

    public void AddScore(int amount)
    {
        currentScore += amount;

        Hashtable scoreProp = new Hashtable();
        scoreProp["Score"] = currentScore;
        PhotonNetwork.LocalPlayer.SetCustomProperties(scoreProp);
    }
}
