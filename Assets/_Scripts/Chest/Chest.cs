using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    [SerializeField] private Item[] items;

    private PlayerStatsManager playerStatsManager;
    private Item activeItem;
    
    [HideInInspector]
    public GameObject PlayerStatsManager
    {
        set 
        {
            PlayerStatsManager val = value.GetComponent<PlayerStatsManager>();
            if (val != null)
            {
                playerStatsManager = val;
            }
        }
    }


    private void OnEnable()
    {
        activeItem = items[Random.Range(0,items.Length - 1)];
    }

    protected override void Interact()
    {
        if (playerStatsManager != null)
        {
            Open();
        }
    }

    private void Open()
    {
        playerStatsManager.UpdateStats(activeItem);

        //Opening animation

        this.gameObject.SetActive(false);
    }

}
