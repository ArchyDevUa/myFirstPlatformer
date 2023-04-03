using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private int cherryCount = 0;
    [SerializeField] private AudioSource collectItemSound;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Cherry"))
        {
            collectItemSound.Play();
            Destroy(col.gameObject);
            cherryCount++;
            text.text = "Cherrys : " + cherryCount;
        }
    }
}
