using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime; // ✅ This is the Photon Player we need
using ExitGames.Client.Photon;
using Hashtable = ExitGames.Client.Photon.Hashtable; // ✅ Force the correct Hashtable to avoid conflicts

public class LeaderboardManager : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    public TextMeshProUGUI leaderboardText;

    private void Start()
    {
        UpdateLeaderboard();
        PhotonNetwork.AddCallbackTarget(this);
    }

    private void OnDestroy()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, Hashtable changedProps)
    {
        if (changedProps.ContainsKey("Score"))
        {
            UpdateLeaderboard();
        }
    }

    private void UpdateLeaderboard()
    {
        string leaderboard = "<b>LEADERBOARD</b>\n";

        foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
        {
            object scoreObj;
            int score = 0;

            if (player.CustomProperties.TryGetValue("Score", out scoreObj))
            {
                score = (int)scoreObj;
            }

            if (player.ActorNumber == PhotonNetwork.LocalPlayer.ActorNumber) // ✅ Proper way to compare players
                leaderboard += $"<color=yellow>{player.NickName}: {score}</color>\n";
            else
                leaderboard += $"{player.NickName}: {score}\n";
        }

        leaderboardText.text = leaderboard;
    }

    // Required IInRoomCallbacks implementations (can stay empty)
    public void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer) { }
    public void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer) { }
    public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged) { }
    public void OnMasterClientSwitched(Photon.Realtime.Player newMasterClient) { }
}
