using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public float s = 5f;
    private void an_egg_hien_player()
    {
        gameObject.SetActive(false);
        player.SetActive(true);
    }
}
