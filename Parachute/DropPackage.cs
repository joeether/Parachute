using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class DropPackage : NetworkBehaviour
{
    public GameObject pack;
    public string sceneName;


    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                CmdSpawnParachute();
            }
        }
    }

    [Command]
    void CmdSpawnParachute()
    {
        GameObject dropClone = (GameObject)Instantiate(pack, new Vector3(93, 30, 100), transform.rotation);
        NetworkServer.Spawn(dropClone);
        SceneManager.MoveGameObjectToScene(dropClone, SceneManager.GetSceneByName(sceneName));
    }
}
