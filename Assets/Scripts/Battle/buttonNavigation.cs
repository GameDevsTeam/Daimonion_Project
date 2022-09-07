using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttonNavigation : MonoBehaviour
{
    public GameObject player;
    public float offsetX;
    public float offsetY;

    private void Update()
    {
        // Si bouton en question sélectionné
        if(EventSystem.current.currentSelectedGameObject.name == this.gameObject.name)
        {
            // Placer le coeur au bon endroit devant le choix
            player.transform.position = new Vector2(transform.position.x + offsetX, transform.position.y + offsetY);
        }
    }
}
