## CLASES DE EQUIVALENCIA
### MÉTODOS MENÚ
~~~~
public class Check
    {
        public const string StatsFail = "Has fallado 3 veces creando la stat y se te ha asignado los valores mínimos de la stat";
        public static bool MenuChoiceInput(int menuChoice, ref int menuTries)
        {
            const string MenuWrongChoice = "Elegiste un valor no permitido prueba otra vez, te quedan estos intentos: {0} ";
            const string Bye = "Hasta pronto! :D ";
            const string Play = "Perfecto, vamos a jugar!";

            if (menuChoice == 0)
            {
                Console.WriteLine(Bye);
                return true;
            }
            else if (menuChoice == 1)
            {
                Console.WriteLine(Play);
                return true;
            }
            else
            {
                Console.WriteLine(MenuWrongChoice, menuTries - 1);
                menuTries--;
                return menuTries > 0;
            }
        }
~~~~
DOMINIO  |  CLASE  |  TIPO  | RESULTADO  | LÍMITE INF  | LÍMITE SUP      
-------------------------------------------------------------------      
-------- | ------  | Válida | ---------- | ----------- | ----------      
-------- | ------  | Válida | ---------- | ----------- | ----------      
-------- | ------  | Válida | ---------- | ----------- | ----------      

