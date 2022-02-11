using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject player;
    public GameObject bombs;

    public bool canBomb;
    public static Enemy en;
    private void Awake()
    {
        en = this;
    }
    private void OnEnable()
    {
        canBomb = true;
    }
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 targetPosForEnemy = new Vector3(player.transform.position.x, transform.position.y, 0);


        transform.position = Vector3.Lerp(transform.position, targetPosForEnemy, Time.deltaTime*3);

        if (canBomb)
        {

            Instantiate(bombs, transform.position, Quaternion.identity);
            canBomb = false;
            StartCoroutine(Timer());
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.8f);
        canBomb = true;
    }
}
