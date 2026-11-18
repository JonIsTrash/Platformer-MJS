using UnityEngine;
using UnityEngine.SceneManagement;

public class Meny
{
    using UnityEngine;
using UnityEngine.SceneManagement;

//Main Menu
 void MainMenu()
{
    SceneManager.LoadScene(0);
}

//Quit game/exit play mode if in Editor
void Quit()
{
    Application.Quit(); //Quits the game (only works in build)
# if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false; //Exits play mode (will only be executed in the editor)
# endif

}

    //Ændre på det senere Maria. Skulle bare rykke dit kode til en anden script.
}
