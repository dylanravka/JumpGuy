using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] platforms;

    public SpriteRenderer firstPlatform;


    private List<SpriteRenderer> platformList = new List<SpriteRenderer>();
    // Start is called before the first frame update
    void Start()
    {
        platformList.Add(firstPlatform);
        for (int i = 0; i < 10; i++)
        {
            int randomPlatformNum = Random.Range(0, platforms.Length);
            int randomGapWidthNum = Random.Range(2, 6);
            SpriteRenderer prevPlatform = platformList[i];


            GameObject platform = Instantiate(platforms[randomPlatformNum], prevPlatform.transform.localPosition + new Vector3((prevPlatform.size.x * 0.5f) + (platforms[randomPlatformNum].GetComponent<SpriteRenderer>().size.x * 0.5f) + randomGapWidthNum, 0.0f, 0.0f), Quaternion.identity);
            Debug.Log("PLATFORM NAME: " + platform.name + "   PREV PLATFORM POS: " + prevPlatform.transform.localPosition + "   PREV PLATFORM SIZE X * 0.5F: " + (prevPlatform.size.x * 0.5f));


            platformList.Add(platform.GetComponent<SpriteRenderer>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
