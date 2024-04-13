using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetSwitcher : MonoBehaviour
{
    public void LoadMercury()
    {
        SceneManager.LoadScene("Assets/Scenes/Mercury.unity");
    }
    public void LoadVenus()
    {
        SceneManager.LoadScene("Assets/Scenes/Venus.unity");
    }
    public void LoadEarth()
    {
        SceneManager.LoadScene("Earth");
    }
    public void LoadMars()
    {
        SceneManager.LoadScene("Mars");
    }
    public void LoadJupiter()
    {
        SceneManager.LoadScene("Jupiter");
    }
    public void LoadSaturn()
    {
        SceneManager.LoadScene("Saturn");
    }
    public void LoadUranus()
    {
        SceneManager.LoadScene("Uranus");
    }
    public void LoadNeptune()
    {
        SceneManager.LoadScene("Neptune");
    }
}
