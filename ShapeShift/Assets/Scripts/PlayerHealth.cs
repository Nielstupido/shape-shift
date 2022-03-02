using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int Health { set {GetComponent<Slider>().value = value;}}
}
