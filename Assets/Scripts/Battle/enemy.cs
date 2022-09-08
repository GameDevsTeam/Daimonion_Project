using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public EnemyData enemyData;

    // Start is called before the first frame update
    void Start()
    {
        if(enemyData != null)
        {
            LoadEnemy(enemyData);
        }
    }

    private void LoadEnemy(EnemyData data)
    {
        GameObject visuals = Instantiate(data.enemyModel);
        visuals.transform.SetParent(transform);
        visuals.transform.localPosition = Vector3.zero;
        visuals.transform.rotation = Quaternion.identity;
        visuals.transform.localScale = new Vector2(data.scaleX, data.scaleY);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
