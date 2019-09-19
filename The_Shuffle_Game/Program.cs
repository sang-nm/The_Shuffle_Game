using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace The_Shuffle_Game
{
    //==================================================================== Class Menu
    
    class Menu
    {
        SaveGame s_game = new SaveGame();
        //------------------------------------------------------------------- Public In menu với các dòng màu bằng mảng menu mn (public menu) và thứ tự mảng ch (public menu)
        public void readmenu(string[] mana, int hc)
        {
            for (int i = 0; i < mana.Length; i++)
            {
                if (i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(mana[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (i == hc)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0}", mana[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine(mana[i]);
                }
            }

        }
        public static int ch;
        public void menu()
        {
            string[] mn = new string[6]                                                     //mảng Menu mn
            { "\n\n\n\t\t\t\tTHE SHUFFLE GAME\n\n\n" ,
                "\t\t\t\t    Continue\n" ,
                "\t\t\t\t    Play Game\n" ,
                "\t\t\t\t    Gosu\n" ,
                "\t\t\t\t    About\n" ,
                "\t\t\t\t    Exit" };
            

            ConsoleKeyInfo keyInfo;
            //------------------------------------------------------------------- Do while - lặp việc In mảng với dòng màu nổi đỏ khi di chuyển Lên Xuống
            ch = 1;
            do
            {
                Console.Clear();
                readmenu(mn, ch);                                   // truyền mảng mn và giá trị ch vào Public readmenu() để In mảng
                keyInfo = Console.ReadKey();
                if ((keyInfo.Key == ConsoleKey.UpArrow) && (ch > 0))
                {
                    ch--;
                    if (ch > 0)
                    {
                        Console.Clear();
                        readmenu(mn, ch);

                    }
                    else
                    {
                        ch = 1;
                        Console.Clear();
                        readmenu(mn, ch);

                    }
                    continue;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    ch++;
                    if (ch < 6)
                    {
                        Console.Clear();
                        readmenu(mn, ch);
                    }
                    else
                    {
                        ch = 5;
                        Console.Clear();
                        readmenu(mn, ch);
                    }
                    continue;
                }

            } while (keyInfo.Key != ConsoleKey.Enter); //----------------------------------------- Do while - Kết thúc khi Enter: Nhận vị trí lựa chọn (ch) và thoát do while

            game c_ga = new game();
            //--------------------------------------------------------- Switch - Giá trị vị trí (ch) sau khi đã chọn ở trên sẽ thực hiện tác vụ ở vị trí được chọn (case)
            switch (ch)
            {
                case 1:
                    {
                        Console.Clear();
                        SaveGame.sss = true;
                        s_game.Cont_Game();
                        if (SaveGame.sss == true)
                        {
                            c_ga.NewGame();
                        }
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        c_ga.NewGame();
                        break;
                    }
                case 3:
                    {
                        Score c_score = new Score();
                        c_score.OUTBestScore();
                        Console.Clear();
                        Console.SetCursorPosition(35, 9);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("THE BEST");
                        Console.SetCursorPosition(31, 11);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Player's Name: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(game.OutName);
                        Console.SetCursorPosition(31, 12);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Moves Like Jagger: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(game.moves);
                        Console.ReadLine();
                        break;
                    }
                case 4:
                    {
                        Console.Clear();
                        Random hihi = new Random();
                        int x = 0, y = 0;
                        while (Console.KeyAvailable != true)
                        {
                            x = hihi.Next(75);
                            y = hihi.Next(25);
                            Console.SetCursorPosition(x, y);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("Felis");
                            Thread.Sleep(50);
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey();
                        break;
                    }
                case 5:
                    {
                        char exit;
                        Console.CursorVisible = true;
                        Console.Write("\n Do you want to exit (Y/N)   ");
                        exit = Convert.ToChar(Console.ReadLine().ToUpper());
                        Console.CursorVisible = false;
                        if (exit == 'Y')
                        {
                            Environment.Exit(0);
                        }
                        else if (exit == 'N')
                        {
                            break;
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            Console.Clear();
            menu();
        }
    }
    //==================================================================== Class Matrix
    class Matrix
    {
        public int[,] matrix = new int[3, 3];
        public int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 0 };
        //------------------------------------------------------------------- Mx() - Tạo một ma trận[3,3] có các giá trị random từ 0 đến 8
        public void Mx()
        {
            Random ran = new Random();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int temp = ran.Next(9);
                    matrix[i, j] = temp;
                    for (int i2 = 0; i2 <= i; i2++)
                    {
                        int jj;
                        if (i2 == i)
                        {
                            jj = j;
                        }
                        else
                        {
                            jj = 3;
                        }
                        for (int j2 = 0; j2 < jj; j2++)
                        {
                            if (temp == matrix[i2, j2])
                            {
                                temp = ran.Next(9);
                                matrix[i, j] = temp;
                                i2 = -1;
                                break;
                            }
                        }
                    }
                }
            }
        }
        public void ShowM(int[,] Show_Matrix)
        {
            Console.SetCursorPosition(2, 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("THE BEST");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Player's Name: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(game.OutName);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\t\t\t\t\t\tKey Presses: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(game.count);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Moves Like Jagger: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(game.moves);


            for (int i = 0; i < 3; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\t\t\t\t+=====+=====+=====+");
                Console.WriteLine();
                Console.Write("\t\t\t\t|");
                Console.ForegroundColor = ConsoleColor.Cyan;
                for (int j = 0; j < 3; j++)
                {

                    if (Show_Matrix[i, j] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("  {0}  ", Show_Matrix[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("|");
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("  {0}  ", Show_Matrix[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("|");
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\t\t\t\t+=====+=====+=====+");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\t\t\t\t Move by Arrow Keys");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(60, 20);
            Console.WriteLine("Enter: Done");
            Console.SetCursorPosition(60, 21);
            Console.WriteLine("Esc: Exit");
            Console.SetCursorPosition(60, 22);
            Console.WriteLine("Delete: Reset Game");
        }
    }
    //==================================================================== Class game
    class game
    {
        SaveGame s_game = new SaveGame();
        Score callscore = new Score();
        Matrix call = new Matrix();
        int[] KT = new int[9];
        //------------------------------------------------------------------- ESC(bool esc) - public thực hiện thao tác của phím Esc 

        static int[] arr_save = new int[9];
        public static int[] save_arr
        {
            get
            {
                return arr_save;
            }
        }
        public bool Esc(bool esc)
        {
            Console.CursorVisible = true;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Back to menu? Y/N?   ");
            Console.ForegroundColor = ConsoleColor.Red;
            char choose;
            choose = char.Parse(Console.ReadLine().ToUpper());
            Console.CursorVisible = false;
            if (choose == 'Y')
            {
                Console.Clear();
                Console.SetCursorPosition(30, 10);
                Console.CursorVisible = true;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Save your game? Y/N   ");
                Console.ForegroundColor = ConsoleColor.Red;
                char sg = char.Parse(Console.ReadLine().ToUpper());
                Console.ForegroundColor = ConsoleColor.White;
                Console.CursorVisible = false;
                if (sg =='Y')
                {
                    int c = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            arr_save[c] = matrix_game[i, j];
                            c++;
                        }
                    }
                    Console.Clear();
                    Console.SetCursorPosition(30, 10);
                    s_game.Save_Game();
                    Console.SetCursorPosition(30, 11);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Enter - Back to menu");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                }
                esc = true;
            }
            else if (choose == 'N')
            {
                esc = false;
            }
            return esc;
        }
        //------------------------------------------------------------------- Enter(bool check) - public thực hiện thao tác của phím Enter 
        public static String InName, OutName;
        public bool Enter(bool check)
        {
            int k = 0;
            for (int i = 0; i < 3; i++)                 // for - Kiểm tra mảng đúng sai sau khi enter
            {
                for (int j = 0; j < 3; j++)
                {
                    KT[k] = matrix_game[i, j];
                    k++;
                }
            }
            check = KT.SequenceEqual(call.arr);
            if (check)                                  // if(check) - nếu mảng đúng thì cho lưu điểm
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\t\t\t\t   *_WELL DONE_*");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                if ((count < moves) ^ (moves == 0))                     //if(điểm) - nếu điểm mới tốt hơn điểm cũ thì nhập tên save vào file.txt
                {
                    Console.Clear();
                    Console.SetCursorPosition(30, 9);
                    Console.CursorVisible = true;
                    Console.Write("Your score is the best");
                    Console.SetCursorPosition(30, 10);
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("Enter Name: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    InName = Console.ReadLine();
                                                                        //while(name) - khi ng chơi không nhập tên thì lặp lại thao tác nhập tên
                    while (InName == "")
                    {
                        Console.Clear();
                        Console.SetCursorPosition(30, 10);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("Please! Enter Your Name:   ");
                        Console.ForegroundColor = ConsoleColor.White;
                        InName = Console.ReadLine();
                    }
                    Console.CursorVisible = false;
                    moves = count;
                    Console.SetCursorPosition(30, 11);
                    Console.WriteLine("Your Score: {0}", moves);
                    callscore.INBestScore();
                }
                else                                                     //else(điểm) - nếu điểm mới không tốt hơn điểm cũ thì thông báo
                {
                    Console.Clear();
                    Console.SetCursorPosition(40, 9);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} > {1}", count, moves);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(30, 11);
                    Console.WriteLine("Your score is not the best");
                }
                Console.CursorVisible = true;
                Console.SetCursorPosition(30, 13);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Do you want to play again? Y/N   ");
                Console.ForegroundColor = ConsoleColor.White;
                char pa = Convert.ToChar(Console.ReadLine().ToUpper());
                Console.CursorVisible = false;
                if (pa == 'Y')                                          //is(yes) - chơi lại hoặc không
                {
                    Console.Clear();
                    count=0;
                    NewGame();
                }
            }
            else                                      //else(check) - nếu mảng sai thì tiếp tục chơi
            {
                Console.Clear();
                call.ShowM(matrix_game);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t   *Incomplete*");
            }
            return check;
        }
        //------------------------------------------------------------------- NewGame() - public chạy game
        public static int count = 0, moves;
        public int[,] matrix_game = new int[3, 3];
        public int[] array_game = new int[9];
        public void NewGame()
        {
        reset_game:;
            callscore.OUTBestScore();
            
            if (Menu.ch == 1)
            {
                int value = 0;
                foreach (var item in SaveGame.Cont_array)
                {
                    array_game[value] = item;
                    value++;
                }
                value = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        matrix_game[i, j] = array_game[value];
                        value++;
                    }
                }
            }
            else if(Menu.ch == 2)
            {
                call.Mx();
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        matrix_game[i, j] = call.matrix[i, j];
                    }
                }
                count = 0;
            }
            call.ShowM(matrix_game);
            int row = 0, col = 0, swap;

            while (true)
            {

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (matrix_game[i, j] == 0)
                        {
                            row = i;
                            col = j;
                        }
                    }
                }
                if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    if (col == 0)
                    {
                        continue;
                    }
                    else
                    {
                        swap = matrix_game[row, col];
                        matrix_game[row, col] = matrix_game[row, col - 1];
                        matrix_game[row, col - 1] = swap;
                        Console.Clear();
                        count++;
                        call.ShowM(matrix_game);
                    }
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    if (col == 2)
                    {
                        continue;
                    }
                    else
                    {
                        swap = matrix_game[row, col];
                        matrix_game[row, col] = matrix_game[row, col + 1];
                        matrix_game[row, col + 1] = swap;
                        Console.Clear();
                        count++;
                        call.ShowM(matrix_game);
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (row == 0)
                    {
                        continue;
                    }
                    else
                    {
                        swap = matrix_game[row, col];
                        matrix_game[row, col] = matrix_game[row - 1, col];
                        matrix_game[row - 1, col] = swap;
                        Console.Clear();
                        count++;
                        call.ShowM(matrix_game);
                    }
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (row == 2)
                    {
                        continue;
                    }
                    else
                    {
                        swap = matrix_game[row, col];
                        matrix_game[row, col] = matrix_game[row + 1, col];
                        matrix_game[row + 1, col] = swap;
                        Console.Clear();
                        count++;
                        call.ShowM(matrix_game);
                    }
                }
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    bool esc = true;
                    esc = Esc(esc);
                    if (esc)
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        call.ShowM(matrix_game);
                        continue;
                    }
                }
                if (keyInfo.Key == ConsoleKey.Enter)
                {

                    bool check = true;
                    check = Enter(check);
                    if (check)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (keyInfo.KeyChar == '0')
                {
                    matrix_game = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
                    Console.Clear();
                    call.ShowM(matrix_game);
                    bool check = true;
                    check = Enter(check);
                    break;
                }
                if (keyInfo.Key == ConsoleKey.Delete)
                {
                    Console.Clear();
                    count = 0;
                    Menu.ch = 1;
                    goto reset_game;
                }
            }
        }
    }
    //==================================================================== Class Score
    class Score
    {
        //------------------------------------------------------------------- Luu du lieu vao txt INBestScore()
        public void INBestScore()
        {
            FileStream fs = new FileStream("Best Score.txt", FileMode.Create, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(game.InName);
            sw.WriteLine(game.count);
            sw.Flush();
            sw.Close();
            fs.Close();
            Console.SetCursorPosition(30, 12);
            Console.WriteLine("Save is complete");
        }
        //------------------------------------------------------------------- Xuat du lieu tu txt OUTBestScore()
        public void OUTBestScore()
        {
            string read;
            List<string> data = new List<string>();
            FileStream fs = new FileStream("Best Score.txt", FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);
            StreamReader sr = new StreamReader(fs);
            read = sr.ReadLine();
            while (read != null)
            {
                data.Add(read);
                read = sr.ReadLine();

            }
            if (data.Count > 0)
            {
                game.OutName = data[0];
                game.moves = Convert.ToInt32(data[1]);
            }
            else
            {
                game.OutName = "null";
                game.moves = 0;
            }
            sr.Close();
            fs.Close();
        }
    }
    class SaveGame
    {
        //------------------------------------------------------------------- Luu game Save_Game()
        public void Save_Game()
        {
            FileStream fs = new FileStream("SavedData.txt", FileMode.Create, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(game.count);
            foreach (var item in game.save_arr)
            {
                sw.WriteLine(item);
            }
            sw.Flush();
            sw.Close();
            fs.Close();
            Console.Write("The game has been saved");
        }
        //------------------------------------------------------------------- Tiep tuc game Cont_Game()
        static int[] array_Cont;
        public static bool sss = true;
        public static int[] Cont_array
        {
            get
            {
                return array_Cont;
            }
        }
        public void Cont_Game()
        {
            string readsave;
            int value = 1;
            array_Cont = new int[9];
            List<string> savedata = new List<string>();
            FileStream fs = new FileStream("SavedData.txt", FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);
            StreamReader sr = new StreamReader(fs);
            readsave = sr.ReadLine();
            while (readsave != null)
            {
                savedata.Add(readsave);
                readsave = sr.ReadLine();
            }
            if (savedata.Count > 0)
            {
                
                game.count = Convert.ToInt32(savedata[0]);
                for (int i = 0; i < 9; i++)
                {
                    array_Cont[i] = Convert.ToInt32(savedata[value]);
                    value++;
                }
            }
            else
            {
                Console.SetCursorPosition(30, 10);
                Console.WriteLine("No saved game");
                sss = false;
                Console.ReadLine();
            }
            sr.Close();
            fs.Close();
        }
    }
    //======================================================================================================= Class Program ========================================================================================== Game maked by Felis Sang :)
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            //game c = new game();
            //c.NewGame();
            //Score s = new Score();
            Menu call = new Menu();
            call.menu();
            Console.ReadLine();
        }
    }
}

