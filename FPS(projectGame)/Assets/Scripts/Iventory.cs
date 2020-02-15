using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iventory : MonoBehaviour
{

    //Variables
    public bool inventoryEnabled;
    public GameObject inventory;
    public GameObject itemDatabase;
    private Transform[] slot;
    public GameObject slotHolder;

    //private bool pickedUpItem;

   // public Camera playerCamera; //camera component for player


    //Functions


    // Start is called before the first frame update
    public void Start()
    {
        GetAllSlots();
    }

   

    // Update is called once per frame
    public void Update()
    {
        //enabling and disabling the inventory
        if(Input.GetKeyDown(KeyCode.I)){
            inventoryEnabled = !inventoryEnabled;
        }

        if(inventoryEnabled){
            inventory.SetActive(true);
        }else {
            inventory.SetActive(false);
        }

    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Grenade")){
            if(other.gameObject.GetComponent<ItemPickUp>().pickedUp == false){
                addItem(other.gameObject);
            }
        }
    }

    public void addItem(GameObject item)
    {
        GameObject rootItem;
        rootItem = item.GetComponent<ItemPickUp>().rootItem;

        for(int i = 0; i < 12; i++){
            if(slot[i].GetComponent<Slot>().empty == true && item.gameObject.GetComponent<ItemPickUp>().pickedUp == false){
                //add item
                slot[i].GetComponent<Slot>().item = rootItem;
               item.GetComponent<ItemPickUp>().pickedUp = true;
               Destroy(item);
                
            }
        }
    }

     public void GetAllSlots()
    {
       slot = new Transform[12];
       for(int i = 0; i < 12; i++){
           slot[i] = slotHolder.transform.GetChild(i); 
           
       }
    }


}
