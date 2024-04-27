using System;

class board
//peramiters for board BACKEND 
{

    // Defines how many rows and collums then connect 4 grid will have 
    private const int Rows = 6;
    private const int Columns = 7;

 
    
    private char[,]playarea = new char[Rows, Columns];// , seperetes the vaules so they arn't just one long char
    private char initialplayer = 'o';

    public void Intialboard()
    //setting up array and intialize BACKEND
    {

    // this will initalize the 2d array with the peremamters that we set above , at this point the boear is empty as it doesn't have any uinputs
     for (int i = 0; i<Rows; i++)
        {
            for (int j = 0; j< Columns; j++)
            {
                //The spliter between rows 
                playarea[i, j] = '-';
            }
        }
    }
    //runs the vaules we gave beofre x amount of times till the array is "populated"

    public void displayoard() {
        //display the board to the player - this is what the player will see , not backend FRONTEND 

        //looping in how many rowns are needed 
        for (int i = 0; i < Rows; i++)
        {
            //looping in how many collumns are neededd 
            for (int j = 0; j < Columns; j++)
            {
                //display to user 
                Console.Write(playarea[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("---------------");
    }
    public bool OUTOFBOUNDS(int j)
        // ensuring the player can't place out of bounds - BACKEND
    {
        return playarea[0, j] != '-';
    }

    public void PlayToken(int j)
    // this is the backend code resposable for the droppping of the token
    {
        for (int i = Rows - 1; i >= 0; i--)//does i(current rows) == to what is set in our permaniters
        {
            if (playarea[i, j] == '-')
            {
                playarea[i, j] = initialplayer;
                break;
            }

        }

    }

    //Has the user won? lets check BACKEND
    public bool WinCondition()
    {

        //checking if the win conidtion is met Virtically (up)
         for (int j = 0; j < Columns; j++)
         {
             for (int i = 0; i <= Rows - 4; i++)
             {
                 if (playarea[i, j] != '-' &&
                     playarea[i, j] == playarea[i + 1,j] &&
                     playarea[i, j] == playarea[i  + 2,j] &&
                     playarea[i, j] == playarea[i  + 3,j])
                 {
                     return true;
                 }
             }


         }

    
        //checking win condition horizontally (Side to side)
        for (int i = 0; i< Rows; i++)
        {
            for(int j=0; j<= Columns - 4; j++)
            {
                
                    if (playarea[i,j]!= '-'&&
                    playarea[i,j]== playarea[i,j + 1]&&
                    playarea[i,j]== playarea[i,j + 2]&&
                    playarea[i,j]== playarea[i,j + 3])
                {
                    return true;
                }
            }
            

        }

        //Checking win condition Diagonal South
        for(int i = 0; i <=Rows - 4; i++)
        {
            for( int j=3; j< Columns; j++)
            {
                if (playarea[i,j]!= '-'&&
                    playarea[i,j] == playarea[i,j + 1]&&
                    playarea[i,j] == playarea[i,j + 2]&&
                    playarea[i,j] == playarea[i,j + 3])
                {
                    return true;
                }
            }
        }

        //checking win condition Diagonal North
        for(int i = 0; i <=Rows - 4; i ++) { 
            for(int j=0; j <=Columns-4; j++)
            {
                if (playarea[i,j]!= '-' &&
                    playarea[i, j] == playarea[i,j + 1]&&
                    playarea[i, j] == playarea[i,j + 2]&&
                    playarea[i, j] == playarea[i,j + 3]
                    )
                {
                    return true;
                }
            }
        }
        return false;
    }


    // ensuring players cannot ovefill the board
    public bool stailemate()
    {
        for(int i = 0;i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (playarea[i, j] == '-')
                {
                    return false;
                }
            }
        }
        return true;
    }

    //BACKEND
    public void SwitchPlayer()//allowing for their to be 2 players rathet than one, this is really just changing which char is used from x to o
    {
        initialplayer = (initialplayer == 'o') ? 'x' : 'o';
        //This first checks who is the current player , then will switch it acordingly 

    }

    //FRONTEND Bringing all the code we have done before this into a class which can be called upon, the entire workings brought togther
    public void start()
    {
        //calls the board peram 
        Intialboard();

        //Game loops , loops until break  win/fill
        while (true)
        {
            //displayig the board to the user
            displayoard();

            //This console.writeline () displays to the user to begin their turn , this will loop every turn
            Console.WriteLine($"Player {initialplayer} it's your turn. Enter a number from 1-7");
            
                int j=int.Parse(Console.ReadLine()) -1;

            if(j<0 || j >= Columns)
            {
                Console.WriteLine("invlaid play");
                continue;
            }
            if (OUTOFBOUNDS(j))
            {
                Console.WriteLine("Invalid play");
                continue;
            }

            PlayToken(j);


            //This has to loop every turn to ensure that after every turn either play has won/ hasn't won 
            if (WinCondition())
            {
                displayoard();
                Console.WriteLine($"Connect 4 game finished player{initialplayer} has won ");
                break;
            }


            SwitchPlayer();






        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            board game = new board();
            game.start();
        }
    }

}
