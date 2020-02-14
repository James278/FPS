using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour, IPointerEnterHandler
{

    //Variables
    public bool empty;
    public Texture itemTexture;
    public Texture slotTexture;
    public GameObject item;

    //Functions


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //change item texture if there is an item
        if(item){
            this.GetComponent<RawImage>().texture = itemTexture;
            empty = false;
        }else{
            this.GetComponent<RawImage>().texture = slotTexture;
            empty = true;
        }
    }

    public void OnPointerEnter(PointerEventData eventData){
        print(this.gameObject.name);
    }


    public void onTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Grenade")){
            addItem(other.gameObject);
        }
    }

    public void addItem(GameObject item)
    {
        GameObject rootItem;
        rootItem = item.GetComponent<ItemPickUp>().rootItem;
    }
}
