using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryMgr : MonoBehaviour
{
    public KeyCode cycleInventoryKey;
    public int currentIndex;
    public Sprite[] allIcons;
    public GameObject[] allPrefabs;
    public bool[] allOwned;

    Image iconImg;

    // Start is called before the first frame update
    void Start()
    {
        iconImg = transform.Find("Icon").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentIndex < 0)
        {
            iconImg.enabled = false;
        }
        else
        {
            iconImg.enabled = true;
            iconImg.sprite = allIcons[currentIndex];
        }

        if (currentIndex >= 0 && Input.GetKeyDown(cycleInventoryKey))
        {
            int nextIndex = currentIndex + 1;
            while (nextIndex != currentIndex)
            {
                if (nextIndex == allIcons.Length)
                    nextIndex = 0;
                if (allOwned[nextIndex] == true)
                {
                    setCurrentIndex(nextIndex);
                    break;
                }
                nextIndex += 1;
            }
        }

    }

    public GameObject getCurrentPrefab()
    {
        if (currentIndex < 0)
            return null;
        return allPrefabs[currentIndex];
    }

    public void setCurrentIndex(int i)
    {
        currentIndex = i;
        allOwned[i] = true;
    }
}
