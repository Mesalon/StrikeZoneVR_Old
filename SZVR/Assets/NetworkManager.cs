using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks {
    void Start() {
        Connect();
    }

    public void Connect() {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void Play() {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message) {
        print("Connecting to room failed");
        PhotonNetwork.CreateRoom("Sussy Mobum", new RoomOptions { MaxPlayers = 4 });
    }

    public override void OnJoinedRoom() {
        print("Joined a room successfully");
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.E)) { PhotonNetwork.LeaveRoom(); }
    }
}
