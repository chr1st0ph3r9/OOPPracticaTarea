using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
   void Jugar()
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   void Salir()
   {
    Console.WriteLine("Saliendo del juego...");
    Application.Quit();
   }
    
}
