using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.Demo.Cockpit;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI LogText;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.NickName = "Player" + Random.Range(1000, 9999);
        Log("Player's name is set to " + PhotonNetwork.NickName);

        //автоматическое переключение между сценами у всех игроков
        PhotonNetwork.AutomaticallySyncScene = true;
        //задаем версию игры, чтобы игроки с разными версиями не смогли попасть в одну и ту же комнату
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();
    }

    //public override void OnConnecti

    public override void OnConnectedToMaster()
    {
        Log("Connected to Master-server");
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions() {MaxPlayers = 2});
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Log("Joined the room");

        PhotonNetwork.LoadLevel("Game");
    }

    private void Log(string message)
    {
        Debug.Log(message);
        LogText.text += "\n";
        LogText.text += message;
    }

}
