using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapLoader : MonoBehaviour
{
    public int level;
    public List<GameObject> level1List;
    public List<GameObject> level2List;
    public List<GameObject> level3List;
    public List<GameObject> level4List;
    public List<GameObject> level5List;

    private void Start()
    {
        loadLevel(level);
    }
    private void loadLevel(int level)
    {
        switch (level)
        {
            case 1:
                foreach (GameObject level1 in level1List)
                {
                    Instantiate(level1);
                }
                break;
            case 2:
                foreach (GameObject level1 in level2List)
                {
                    Instantiate(level1);
                }
                break;
            case 3:
                foreach (GameObject level1 in level3List)
                {
                    Instantiate(level1);
                }
                break;
            case 4:
                foreach (GameObject level1 in level4List)
                {
                    Instantiate(level1);
                }
                break;
            case 5:
                foreach (GameObject level1 in level5List)
                {
                    Instantiate(level1);
                }
                break;
        }
        Destroy(gameObject);
    }
}
