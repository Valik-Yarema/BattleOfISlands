using Hashtable = ExitGames.Client.Photon.Hashtable;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour, IPunObservable
{
    protected PhotonView photonView;

    public List<GameObject> ShipsPrefabs;
    public List<GameObject> Ships;
    public ShipMenu panelShip;
    public IslandMenu panelIsland;
    public GameObject panelResources;
    public IslandSelectMenu panelSelectIsland;
    public List<GameObject> PlayerIslands;
    protected ListResources listResources;
     

    private new Renderer renderer;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
    }

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        renderer = GetComponent<Renderer>();
        listResources = panelResources.GetComponent<ListResources>();
        listResources.SetPlayerController(this);
        panelSelectIsland.SetPlayerController(this);
        
        
        foreach (var item in ShipsPrefabs)
        {
            item.GetComponent<ShipController>().playerController = this;
        }

        foreach (var item in listResources.TextObjects)
        {
            item.text = Random.Range(0, 100).ToString();
        }
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            return;
        }

        
    }

    public  void AddShip(int index)
    {
        //float angularStart = (360.0f / PhotonNetwork.CurrentRoom.PlayerCount) * Random.Range(0, 8);// PhotonNetwork.LocalPlayer.GetPlayerNumber();
        //float x = 20.0f * Mathf.Sin(angularStart * Mathf.Deg2Rad);
        //float z = 20.0f * Mathf.Cos(angularStart * Mathf.Deg2Rad);
        //Vector3 position = new Vector3(x, 0.0f, z);

        index = Random.Range(0, ShipsPrefabs.Count() - 1);
        
        GameObject ship = PhotonNetwork.Instantiate(ShipsPrefabs[index], ShipsPrefabs[index].transform.position, ShipsPrefabs[index].transform.rotation, 0);
        Ships.Add(ship);
    }

    public void AddShip(int index, Transform transform)
    {
        GameObject ship = PhotonNetwork.Instantiate(ShipsPrefabs[index], transform.position, transform.rotation, 0);
        Ships.Add(ship);
    }
    public void AddShip(string nameShip, Transform transform)
    {
        GameObject ship = PhotonNetwork.Instantiate(ShipsPrefabs.First(s=>s.name==nameShip), transform.position, transform.rotation, 0);
        Ships.Add(ship);
    }


}
