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
        setEmpty();
    }

    public void setEmpty()
    {
        currentIndex = -1;
        iconImg.enabled = false;
    }

    public int countOwned()
    {
        int count = 0;
        for (int i = 0; i < allOwned.Length; i++)
        {
            if (allOwned[i] == true)
                count += 1;
        }
        return count;
    }

    public int getNextIndex()
    {
        if (countOwned() == 0)
        {
            return -1;
        }

        int nextIndex = currentIndex + 1;
        while (nextIndex != currentIndex)
        {
            if (nextIndex == allIcons.Length)
                nextIndex = 0;
            if (allOwned[nextIndex] == true)
                return nextIndex;
            nextIndex += 1;
        }
        return currentIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (countOwned() > 1 && Input.GetKeyDown(cycleInventoryKey))
        {
            int ni = getNextIndex();
            setCurrentIndex(ni);
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
        iconImg.enabled = true;
        iconImg.sprite = allIcons[currentIndex];
    }

    public void pickupItem(int i)
    {
        allOwned[i] = true;
        setCurrentIndex(i);
    }

    public void removeItem(int i)
    {
        allOwned[i] = false;
        if (countOwned() == 0)
        {
            setEmpty();
        }
        else if (i == currentIndex)
        {
            int ni = getNextIndex();
            setCurrentIndex(ni);
        }
    }
}
