using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityStandardAssets.Characters.FirstPerson;

namespace SardinesInMyPocket
{
    public class PlayerManager : MonoBehaviourPun
    {
        public static GameObject LocalPlayerInstance;

        public void Awake()
        {
            if(photonView.IsMine)
            {
                PlayerManager.LocalPlayerInstance = this.gameObject;
                gameObject.GetComponent<FirstPersonController>().enabled = true;
            }
            DontDestroyOnLoad(this.gameObject);
        }
    }
}

