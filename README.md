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
Nanturales   |  0 - 1      | Válida     |   TRUE         |     0           |      1 
Nanturales   |-infinito / 0| Válida     |   FALSE        | - infinito      |     -1
Nanturales   |2 / infinito | Válida     |   FALSE        |       2         |   infinito

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

~~~
public static void CreateNoTries(ref int tries, ref bool statCreated, ref float stat, int MinStat)
{
    if (tries == 0)
    {
        Console.WriteLine(StatsFail);
        stat = MinStat;
        tries = 3;
        statCreated = true;
    }
}
~~~
DOMINIO      |  CLASE      |  TIPO      | RESULTADO      | LÍMITE INF      | LÍMITE SUP    
|------------|-------------|------------|----------------|-----------------|------------|
Nanturales   |      0      | Válida     |   TRUE         |     0           |      0 
Nanturales   |-infinito / 0| Válida     |   FALSE        | - infinito      |     -1
Nanturales   |0 / infinito | Válida     |   FALSE        |       1         |   infinito
~~~
public static bool CDs (int cdSecs)
{
    const string CDText = "La habilidad esta en enfriamiento";

    if (cdSecs > 0)
    {
        Console.WriteLine(CDText);
        Console.WriteLine();
        return false;
    }
    return true;
}
~~~
DOMINIO      |  CLASE      |  TIPO      | RESULTADO      | LÍMITE INF      | LÍMITE SUP    
|------------|-------------|------------|----------------|-----------------|------------|
Nanturales   |infinito - 0 | Válida     |   FALSE        |        0        |   infinito 
Nanturales   |-infinito / 1| Válida     |   TRUE         | - infinito      |     0

### MÉTODOS CREAR STATS ### 
~~~
public static float Stat(ref int tries, ref bool statCreated, float valueStat, int MinStat, int MaxStat)
{
    statCreated = false;

    if (valueStat >= MinStat && valueStat <= MaxStat)
    {
        Console.ResetColor();
        Console.Write(StatConfirmation);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(Correctly);
        Console.ResetColor();
        Console.WriteLine();
        statCreated = true;
        return valueStat;
    }
    else
    {
        Console.Write(WrongNum);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(TryAgain);
        Console.WriteLine();
        Console.ResetColor();
        Console.WriteLine();
        tries--;
        Console.Write(triesIndicator);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(tries);
        Console.ResetColor();
        return 0;
    }
}
~~~
DOMINIO      |        CLASE      |    TIPO    |    RESULTADO   |    LÍMITE INF   | LÍMITE SUP    
|------------|-------------------|------------|----------------|-----------------|------------|
Nanturales   |MinStat - MaxStat  |   Válida   |   ValueStat    |     MinStat     |   MaxStat
Nanturales   |-infinito - MinStat|   Válida   |       0        |    -infinito    |  MinStat
Nanturales   | infinito - MaxStat|   Válida   |       0        |    MaxStat-1    |   infinito
~~~
public static int RandStat(int minStat, int maxStat)
{
    Random random = new Random();
    return random.Next(minStat, maxStat + 1);
}
~~~
DOMINIO      |        CLASE      |    TIPO    |    RESULTADO   |    LÍMITE INF   | LÍMITE SUP    
|------------|-------------------|------------|----------------|-----------------|------------|
Nanturales   |MinStat < MaxStat  |   Válida   |     RANDOM     |     MinStat     |  MaxStat-1
Nanturales   |-infinito - MinStat|   Válida   |       0        |    -infinito    |  MinStat
Nanturales   | infinito - MaxStat|   Válida   |       0        |    MaxStat-1    |   infinito

### MÉTODOS PELEA ###
~~~
public static bool IsCritic ()
{
    int luckyCritic = 7;
    Random rnd = new Random();
    int random = rnd.Next(1, 11);

    return luckyCritic == random;
}
~~~
DOMINIO      |        CLASE      |    TIPO    |    RESULTADO   |    LÍMITE INF   | LÍMITE SUP    
|------------|-------------------|------------|----------------|-----------------|------------|
Nanturales   |     Min < Max     |   Válida   |     RANDOM     |     MinStat     |  MaxStat-1
Nanturales   |-infinito - MinStat|   Válida   |       0        |    -infinito    |  MinStat
Nanturales   | infinito - MaxStat|   Válida   |       0        |    MaxStat-1    |   infinito
