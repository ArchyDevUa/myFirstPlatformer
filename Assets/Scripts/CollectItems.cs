using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private int cherryCount = 0;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Cherry"))
        {
            Destroy(col.gameObject);
            cherryCount++;
            text.text = "Cherrys : " + cherryCount;
        }
    }
}
