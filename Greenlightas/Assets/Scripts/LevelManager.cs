using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject gems;
    public Transform leftBound;
    public Transform rightBound;
    public Transform upperBound;
    public Transform lowerBound;
    public GameObject enemy;
    int[] xs = { 4, 8, 12, 16, 20, 24, 28, 32 };
    int[] ys = { 4,5,6 };
    // Start is called before the first frame update
    void Start()
    {

        againBtn();
    }
    public void againBtn()
    {
        enemy.SetActive(false);
        GameObject[] gemstoClear = GameObject.FindGameObjectsWithTag("Gems");
        for(int i = 0; i < gemstoClear.Length; i++)
        {
            Destroy(gemstoClear[i].gameObject);
        }

        for (int i = 0; i < 8; i++)
        {

            float x = leftBound.position.x + xs[i];
            float y = lowerBound.position.y + ys[Random.Range(0, ys.Length)];
            float z = 0;
            Vector3 position = new Vector3(x, y, z);
            Instantiate(gems, position, Quaternion.Euler(90, 0, 0));
        }

        PlayerController.pc.score = 0;
        PlayerController.pc.hit = false;
        PlayerController.pc.gameEndPanel.SetActive(false);

        enemy.SetActive(true);
    }
}
