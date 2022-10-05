using System;
using System.Threading;

class Program {
    static void Main() {

        int size1 = 40, size2 = 40;

        int[,] tab1 = new int[size1+2, size2+2];
       

        tab1 = _Init_(tab1.GetLength(0), tab1.GetLength(1));

        display(tab1);

        Console.ForegroundColor = ConsoleColor.White;
        sasiedzi(1, 1, tab1);
        while(true){
            
            int[,] tab2 = new int[size1+2, size2+2];
            for (int x = 1; x < tab1.GetLength(0) - 2; x++) {
            for (int y = 1; y < tab1.GetLength(1) - 2; y++) {
                int s = sasiedzi(x, y, tab1);
                if (s == 3)
                {
                    tab2[x, y] = 1;
                }
                else if (s == 2)
                    tab2[x, y] = tab1[x, y];
                else {
                    tab2[x, y] = 0;
                }
            }
        }
        Console.Clear();
        display(tab2);
        Thread.Sleep(100);
            tab1 = tab2;
    }
        Console.SetCursorPosition(0, 0);
        Console.ReadKey();

    }
    
    /*
        zasady gry:
            - 3 sąsiedzi: ożywa
            - 2 bez zmian
            - inne umiera
     */

    static int sasiedzi(int x, int y, int[,] tab) {
        int suma = tab[x - 1, y - 1] +
        tab[x, y - 1] +
        tab[x + 1, y - 1] +
        tab[x - 1, y] +
        tab[x + 1, y] +
        tab[x - 1, y + 1] +
        tab[x, y + 1] +
        tab[x + 1, y + 1];
        return suma;
    }
    static void display (int[,] tab) {
        ConsoleColor cellColor;
        for (int x = 0; x < tab.GetLength(0); x++) {
            string alive = "";
            for (int y = 0; y < tab.GetLength(1); y++) {
                alive = (tab[x, y] == 0) ? " " : "■";
                cellColor = (tab[x, y] == 0) ? ConsoleColor.White : ConsoleColor.Green;
                Console.ForegroundColor = cellColor;
                Console.Write(alive + " ");
            }
            Console.WriteLine();
        }
            Console.SetCursorPosition(0, 0);
    }
    static int[,] _Init_(int size1, int size2) {
        int[,] newTab = new int[size1, size2];
        Random rng = new();

        for(int x=1; x<size1-2; x++) {
            for(int y = 1; y < size2-2; y++) {
                newTab[x, y] = rng.Next(0, 2);
            }
        }
        return newTab;
    }
}
