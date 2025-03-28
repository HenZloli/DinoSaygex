using System.Runtime.InteropServices;
using UnityEngine;

public class LoadScreen : MonoBehaviour
{
    private Material materialLoad;
    [SerializeField] private float parallaxFactorMenu = 0.01f;
    private float offsetMenu;
    public float menuSpeed = 5f;
    void Start()
    {
        materialLoad = GetComponent<Renderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        ParallaxScrollMenu();
    }
    private void ParallaxScrollMenu()
    {
        float speedMenu = menuSpeed * parallaxFactorMenu;
        offsetMenu += Time.deltaTime * speedMenu;
        materialLoad.SetTextureOffset("_MainTex", Vector2.right * offsetMenu);
    }
}
