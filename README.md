## CLASES DE EQUIVALENCIA ##
### MÉTODOS MENÚ ### 
~~~~
public static bool MenuChoiceInput(int menuChoice, ref int menuTries)
{
    const string MenuWrongChoice = "Elegiste un valor no permitido prueba otra vez, te quedan estos intentos: {0} ";
    const string Bye = "Hasta pronto! :D ";
    const string Play = "Perfecto, vamos a jugar!";

    switch (menuChoice)
    {
        case 0:
            Console.WriteLine(Bye);
            return true;
        case 1:
            Console.WriteLine(Play);
            return true;
        default:
            Console.WriteLine(MenuWrongChoice, menuTries - 1);
            menuTries--;
            return false;
    }
}
~~~~

DOMINIO      |  CLASE      |  TIPO      | RESULTADO      | LÍMITE INF      | LÍMITE SUP    
|------------|-------------|------------|----------------|-----------------|------------|
Nanturals    |  0 - 1      | Válida     |   TRUE         |     0           |      1 
Nanturals    |-infinito / 0| Válida     |   FALSE        | - infinito      |     -1
Nanturals    |2 / infinito | Válida     |   FALSE        |       2         |   infinito

~~~
public static bool NamesInput (string names)
{
    const string CommasWrong = "Ahi no hay 4 nombres separados por comas";
    const string LengthWrong = "Venga hombre, ahí no caben 4 nombres";
    const int MinLength = 12, MinCommas = 3;
    int commas = 0;

    foreach (char c in names)
    {
        if (c ==  ',')
        {
            commas++;
        }
    }

    if (commas < MinCommas)
    {
        Console.WriteLine(CommasWrong);
        return false;
    }
    if (names.Length < MinLength)
    {
        Console.WriteLine(LengthWrong);
        return false;
    }
    return true;
}
~~~
DOMINIO      |  CLASE        |  TIPO      | RESULTADO      | LÍMITE INF          | LÍMITE SUP    
|------------|---------------|------------|----------------|---------------------|------------|
Carácteres   |letras(4comas) |   Válida   |     TRUE       |length (12) comas (4)|  infinito         
Carácteres   |letras(3comas) |   Válida   |     FALSE      |length (12) comas (4)|  infinito  
Carácteres   |letras(11 long)|   Válida   |     FALSE      |length (0) comas (3) |  infinito
