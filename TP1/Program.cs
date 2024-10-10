class Program
{
    #region LOGOS
    const string MAIN_APP_LOGO = @"
__________         __    __                       
\______   \_____ _/  |__/  |_  ___________ ___.__.
 |    |  _/\__  \\   __\   __\/ __ \_  __ <   |  |
 |    |   \ / __ \|  |  |  | \  ___/|  | \/\___  |
 |______  /(____  /__|  |__|  \___  >__|   / ____|
        \/      \/                \/       \/     
 ";
    #endregion

    #region BATTERY_DISPLAY_CONSTANTS
    const int BATTERY_STARTING_COLUMN = 3;
    const int BATTERY_STARTING_ROW = 1;
    const int NB_BATTERY_CHARGE_ROWS = 10;
    const int TEXT_COLOR_CHARGE_THRESHOLD = 30;

    const string BATTERY_TOP = " ___====___ ";
    const string BATTERY_FILL = "          ";
    const string BATTERY_SIDE = "|";
    const string BATTERY_BOTTOM = " ~~~~~~~~~~ ";
    #endregion

    public static void Main(string[] args)
    {
        // Il n'est pas possible de quitter le Main car on y retourne
        // systématiquement après une sortie du menu des opérations
        // C'est inhabituel de faire un while(true) mais ça se peut
        // dans certaines circonstances, dont celle-ci.
        while (true)
        {
            // TODO : Gérer l'authentification



            // TODO : Gérer le menu principal (celui des opérations)

        }
    }

    // TODO : créer les fonctions nécessaires ici


    #region UTILITY_FUNCTIONS  
    /// <summary>
    /// Permet d'écrire du texte à la console à un endroit précis
    /// </summary>
    /// <param name="text">Le texte à écrire</param>
    /// <param name="x">La colonne à laquelle écrire le texte</param>
    /// <param name="y">La ligne à laquelle écrire le texte.  La première ligne est en haut et le numéro de ligne augmente en descendant</param>
    static void WriteText(string text, int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(text);
    }
    /// <summary>
    /// Permet de signaler une erreur à la console à un endroit précis
    /// </summary>
    /// <param name="text">Le texte à écrire</param>
    /// <param name="x">La colonne à laquelle écrire le texte</param>
    /// <param name="y">La ligne à laquelle écrire le texte.  La première ligne est en haut et le numéro de ligne augmente en descendant</param>
    static void WriteError(string text, int x, int y)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        WriteText(text, x, y);
        Console.ForegroundColor = ConsoleColor.White;
    }

    /// <summary>
    /// Permet d'afficher la batterie dans la console à un endroit prédéterminé (vous pourriez le changer).
    /// </summary>
    /// <param name="chargePercentage">Le pourcentage de charge courant de la batterie. Vous devriez le garder à quelque part dans votre application et le passer en paramètre ici</param>
    static void PrintBattery(int chargePercentage)
    {
        const int BATTERY_CONTENT_START = BATTERY_STARTING_ROW + 1;
        int nbFilledLines = Math.Min(NB_BATTERY_CHARGE_ROWS, chargePercentage / NB_BATTERY_CHARGE_ROWS);
        int nbEmptyLines = Math.Max(0, NB_BATTERY_CHARGE_ROWS - nbFilledLines);

        WriteText(BATTERY_TOP, BATTERY_STARTING_COLUMN, BATTERY_STARTING_ROW);
        for (int i = 0; i < nbEmptyLines; i++)
        {
            WriteBatteryEmptyLine(BATTERY_STARTING_COLUMN, BATTERY_CONTENT_START + i);
        }
        for (int i = nbEmptyLines; i < NB_BATTERY_CHARGE_ROWS + 1; i++)
        {
            WriteBatteryChargedLine(chargePercentage, BATTERY_STARTING_COLUMN, BATTERY_CONTENT_START + i);
        }
        WriteText(BATTERY_BOTTOM, BATTERY_STARTING_COLUMN, BATTERY_CONTENT_START + NB_BATTERY_CHARGE_ROWS);
    }

    // PROF : fonctions utilitaires pour rendre la fonction d'affichage de la batterie plus concis.
    static void WriteBatteryChargedLine(int chargePercentage, int x, int y)
    {
        ConsoleColor color = ConsoleColor.White;
        if (chargePercentage >= TEXT_COLOR_CHARGE_THRESHOLD)
            color = ConsoleColor.Green;
        else
            color = ConsoleColor.Red;

        WriteText(BATTERY_SIDE, x, y);
        Console.BackgroundColor = color;
        WriteText(BATTERY_FILL, x + 1, y);
        Console.BackgroundColor = ConsoleColor.Black;
        WriteText(BATTERY_SIDE, x + BATTERY_FILL.Length + 1, y);
    }

    static void WriteBatteryEmptyLine(int x, int y)
    {
        string line = string.Format("{0}{1}{0}", BATTERY_SIDE, BATTERY_FILL);
        WriteText(line, x, y);
    }

    // TODO : vous pouvez ajouter d'autres fonctions utilitaires

    #endregion
}