using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private Button serverBtn; 
    [SerializeField] private Button hostBtn;
    [SerializeField] private Button clientBtn;
    [SerializeField] private Button CenterClientButton;
    public InputReader Inputs;
    private bool hasStartedNetworkManager; //false

    private void Awake()
    {
        serverBtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartServer();
        });
        hostBtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
        });
        clientBtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        });
        CenterClientButton.onClick.AddListener(() => 
        { 
            NetworkManager.Singleton.StartClient(); 
        });
    }

    /// <summary>
    /// called every frame
    /// </summary>
    private void Update()
    {
        if (!hasStartedNetworkManager)
        { }
        if (Inputs.ButtonA)
        {
            NetworkManager.Singleton.StartHost();
            hasStartedNetworkManager = true;
        }
        else if (Inputs.ButtonB)
        {
            NetworkManager.Singleton.StartClient();
            hasStartedNetworkManager = true;
        }
    } //from if hasn't already started network manager host or client

}
