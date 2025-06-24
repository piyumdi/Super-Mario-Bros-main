using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class UserName : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject UsernamePage;
    public TMP_Text MyUsername;

    void Start()
    {
        if(PlayerPrefs.GetString("Username") == "" || PlayerPrefs.GetString("Username") == null)
        {
            UsernamePage.SetActive(true);

        }
        else
        {
            PhotonNetwork.NickName = PlayerPrefs.GetString("Username");

            MyUsername.text = PlayerPrefs.GetString("Username");

            UsernamePage.SetActive(false);
        }
    }

    public void SaveUsername()
    {
        Debug.Log("11");
        
        PhotonNetwork.NickName = inputField.text;

        PlayerPrefs.SetString("Username", inputField.text);

        MyUsername.text = inputField.text;

        UsernamePage.SetActive(false);
        
    }
}
