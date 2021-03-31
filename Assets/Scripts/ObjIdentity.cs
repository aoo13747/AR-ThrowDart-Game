using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjIdentity : MonoBehaviour
{
    public int scoreAmount = 10;
    public GameObject destroyEffect;
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 10f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            PlayerStat.AddScore(scoreAmount);
            Destroy(gameObject);
            GameObject effect = (GameObject)Instantiate(destroyEffect, transform.position, Quaternion.identity);
            effect.transform.localScale = transform.localScale;
            Destroy(effect, 2f);
        }
    }
}
