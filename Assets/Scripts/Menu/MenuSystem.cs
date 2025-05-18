using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
   public void Jugar()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   public void Salir()
   {
      debug.log("Saliendo del juego...");
      Application.Quit();
   }
    
}
