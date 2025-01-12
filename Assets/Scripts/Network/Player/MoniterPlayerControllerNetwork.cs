using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class MoniterPlayerControllerNetwork : NetworkBehaviour
{
    [SerializeField] public Image AP_1;
    [SerializeField] public Image AP_2;
    [SerializeField] public Image AP_3;

    [SerializeField] public TextMeshProUGUI dayText;
    [SerializeField] public TextMeshProUGUI workingPointText;

    [SerializeField] private TextMeshProUGUI idOfPlayerText;

    [SerializeField] private TextMeshProUGUI numberDayText;

    private TurnSystemNetwork turnSystemNetwork;
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        turnSystemNetwork = FindObjectOfType<TurnSystemNetwork>();
        if (turnSystemNetwork == null)
        {
            Debug.LogError("Can't find TurnSystemNetwork");
        }
    }

    private void Update()
    {
        if (!IsOwner) return;

        if (turnSystemNetwork != null)
        {
            numberDayText.text = turnSystemNetwork.day.ToString();
        }

        idOfPlayerText.text = (NetworkManager.Singleton.LocalClientId+1).ToString();
    }
}
