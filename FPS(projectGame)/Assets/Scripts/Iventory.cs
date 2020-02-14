using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iventory : MonoBehaviour
{

    //Variables
    public bool inventoryEnabled;
    public GameObject inventory;
    public GameObject itemDatabase;


    //Functions


    // Start is called before the first frame update
    public void Start()
    {
        
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

        //check for slots

        
        
    }

void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Grenade")){
            other.gameObject.SetActive(false);
        }
        
    }

    


}
