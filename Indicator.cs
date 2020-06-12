using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIndicator : MonoBehaviour
{
    public GameObject[] item;
    public GameObject Pointer;
    public GameObject Indicator;

    Vector3 ModelScale;

    public float offset;
    private float rotZ;
    private float scaleFX;
    private float scaleFZ;
    private float scaleFY;


    public SpriteRenderer SpRenderer;
    private SpriteRenderer ItemSpRenderer;

    public Sprite none;
    private Sprite itemSprite;


    void Start()
    {
        scaleFX = Indicator.transform.localScale.x;
        scaleFY = Indicator.transform.localScale.y;
        scaleFZ = Indicator.transform.localScale.z;
    }

    void Update()
    {
        item = GameObject.FindGameObjectsWithTag("Item");

        if (rotZ < -90 || rotZ > 90)
        {
            ModelScale.y = scaleFY * -1;
            Indicator.transform.localScale = new Vector3(scaleFX, ModelScale.y, scaleFZ);
        }
        else
        {
            ModelScale.y = scaleFY;
            Indicator.transform.localScale = new Vector3(scaleFX, ModelScale.y, scaleFZ);
        }

        if (item.Length <= 0)
        {
            A_.DeActivate(Pointer);
            SpRenderer.sprite = none;
        }

        if(item.Length > 0)
        {
            A_.Activate(Pointer);
            Vector3 difference = item[0].transform.position - transform.position;
            ItemSpRenderer = item[0].GetComponent<SpriteRenderer>();
            itemSprite = ItemSpRenderer.sprite;
            SpRenderer.sprite = itemSprite;
            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        }

    }
}
