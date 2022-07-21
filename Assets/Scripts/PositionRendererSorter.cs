using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PositionRendererSorter : MonoBehaviour
{
    /*[SerializeField]
    private int sortingOrderBase = 5000;*/
    [SerializeField]
    private int offset = 0;
    [SerializeField]
    private bool runOnlyOnce = false;
    private SortingGroup myRenderer;

    private void Awake()
    {
        myRenderer = GetComponent<SortingGroup>();
    }
    private void LateUpdate()
    {
        myRenderer.sortingOrder = (int)(transform.position.y * -100) - offset;
        if (runOnlyOnce)
        {
            Destroy(this);
        }
    }
}
