using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace SardinesInMyPocket
{
    public class MultiplayerManager : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        private string roomName;

        [SerializeField]
        private string sceneName;

        [SerializeField]
        private GameObject playerPrefab;

        void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        #region MonoBehaviourPunCallbacks Callbacks
        public override void OnJoinedRoom()
        {
            Debug.Log("Joined room " + PhotonNetwork.CurrentRoom);
            int numPlayers = PhotonNetwork.PlayerList.Length;
            float xCoord;
            float zCoord;
            if(numPlayers == 1)
            {
                xCoord = 0f;
                zCoord = 5f;
            } else
            {
                xCoord = -5f;
                zCoord = -5f;
            }
            PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(xCoord, 2f, zCoord), Quaternion.identity, 0);
        }

        public override void OnCreatedRoom()
        {
            Debug.Log("Created room with name " + roomName);
            PhotonNetwork.LoadLevel(sceneName);
            Debug.Log("Loaded " + sceneName);
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("Connected to master");
            PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions { MaxPlayers = 2 }, new TypedLobby());
        }

        #endregion
    }
}

