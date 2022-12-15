using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private GameObject playerSecretHead;

    private void Start()
    {
        playerSecretHead = GameObject.FindWithTag("Player").transform.Find("Rob_pfp").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerSecretHead.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
