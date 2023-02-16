using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class Parachute : NetworkBehaviour
{
    public GameObject fakepackage;
    public GameObject gift;
    public GameObject clothChute;
    public string sceneName;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            fakepackage.SetActive(false);
            clothChute.SetActive(true);
            clothChute.transform.parent = null;
            this.gameObject.SetActive(false);
            if (isServer)
            {
                SpawnGift();
            }
        }
    }

    [Server]
    public void SpawnGift()
    {
        GameObject giftClone = Instantiate(gift, fakepackage.transform.position, fakepackage.transform.rotation);
        NetworkServer.Spawn(giftClone);
        SceneManager.MoveGameObjectToScene(giftClone, SceneManager.GetSceneByName(sceneName));
    }
}
