using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
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
            itemTexture = item.GetComponent<Item>().itemTexture;
            this.GetComponent<RawImage>().texture = itemTexture;
            empty = false;
        }else{
            this.GetComponent<RawImage>().texture = slotTexture;
            empty = true;
        }
    }

    public void OnPointerEnter(PointerEventData eventData){
        
    }
    public void OnPointerDown(PointerEventData eventData){
        if(item){
            item.SetActive(true);
        }
    }

}
