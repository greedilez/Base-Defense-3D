using UnityEngine;

public class MenuOpener : MonoBehaviour
{
    public void SwapMenuState(GameObject targetMenu) => targetMenu.SetActive(!targetMenu.activeSelf);
}
