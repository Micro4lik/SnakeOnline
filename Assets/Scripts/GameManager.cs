using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject PlayerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(Random.Range(-2f, 2f), Random.Range(-2.5f, 7f));
        PhotonNetwork.Instantiate(PlayerPrefab.name, pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //вызывать при проигрыше
    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        // Когда текущий игрок покидает комнату
        SceneManager.LoadScene(0);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("Player {0} entered room", newPlayer.NickName);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogFormat("Player {0} left room", otherPlayer.NickName);
    }

}
