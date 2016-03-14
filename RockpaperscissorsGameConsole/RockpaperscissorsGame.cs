using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockpaperscissorsGameConsole
{
    enum Status
    {
        Scissors = 0,
        Rock = 1,
        Paper = 2
    }



    enum Results
    {
        Win = 0, 
        Draw = 1,
        Lose = 2
    }

    class RockpaperscissorsGame
    {
        static void Main(string[] args)
        {
            RockpaperscissorsGame Game = new RockpaperscissorsGame();
            
            int UserChoice = 2;                 // 사용자의 선택값
            Results Result;                 // 게임 결과

            UserChoice = Game.Input();
            Result = Game.Play(UserChoice);
            Game.Output(Result);
            
            
        }



        /// <summary>
        /// 함수 이름 : Output
        /// 기    능 : 게임 결과를 화면에 출력한다.
        /// 입    력 : 게임 결과
        /// 출    력 : 없음
        /// </summary>
        /// <param name="Result">게임 결과</param>
        private void Output(Results Result)
        {
            switch(Result)
            {
                case Results.Win:
                    Console.WriteLine("당신은 승리했습니다.");
                    break;
                case Results.Draw:
                    Console.WriteLine("당신은 비겼습니다.");
                    break;
                case Results.Lose:
                    Console.WriteLine("당신은 졌습니다.");
                    break;
                default:
                    break;
            }
            Console.ReadKey();
        }



        /// <summary>
        /// 함수 이름 : Input
        /// 기    능 : 사용자에게 사용자의 선택을 입력받는다.
        /// 입    력 : 없음
        /// 출    력 : 사용자의 선택
        /// </summary>
        /// <returns>사용자의 선택</returns>
        int Input()
        {
            int UserChoice;

            Console.WriteLine("숫자를 선택하세요.");
            Console.WriteLine("1. 가위");
            Console.WriteLine("2. 바위");
            Console.WriteLine("3. 보");
            UserChoice = Int32.Parse(Console.ReadLine());

            return UserChoice;
        }



        /// <summary>
        /// 함수 이름 : Play
        /// 기    능 : 가위바위보 게임을 진행한다.
        /// 입    력 : 사용자의 선택값
        /// 출    력 : 게임 결과
        /// </summary>
        /// <param name="UserChoice">사용자의 선택값</param>
        /// <returns>게임 결과</returns>
        Results Play(int UserChoice)
        {
            Status Status;                                    // 가위바위보 상태
            Results Results = Results.Draw;                   // 게임 결과
            int ComputerChoice;                               // 컴퓨터의 선택값
            Status ExchangedUserChoice = Status.Scissors;     // 사용자 선택의 변환값
            Status ExchangedComputerChoice = Status.Scissors; // 컴퓨터 선택의 변환값

            // 사용자 선택의 변환값을 구한다.
            switch(UserChoice)
            {
                case 0:
                    ExchangedUserChoice = Status.Scissors;
                    break;
                case 1:
                    ExchangedUserChoice = Status.Rock;
                    break;
                case 2:
                    ExchangedUserChoice = Status.Paper;
                    break;
                default:
                    break;
            }

            // 컴퓨터의 선택을 구한다.
            Random Random = new Random();
            ComputerChoice = Random.Next(0, 3);

            // 컴퓨터 선택의 변환값을 구한다.
            switch (ComputerChoice)
            {
                case 0:
                    ExchangedComputerChoice = Status.Scissors;
                    break;
                case 1:
                    ExchangedComputerChoice = Status.Rock;
                    break;
                case 2:
                    ExchangedComputerChoice = Status.Paper;
                    break;
                default:
                    break;
            }
            // 가위바위보 게임을 한다.
            if(ExchangedUserChoice == Status.Scissors)
            {
                switch(ExchangedComputerChoice)
                {
                    case Status.Scissors:
                        Results = Results.Draw;
                        break;
                    case Status.Rock:
                        Results = Results.Lose;
                        break;
                    case Status.Paper:
                        Results = Results.Win;
                        break;
                    default:
                        break;
                }
            }
            if (ExchangedUserChoice == Status.Rock)
            {
                switch (ExchangedComputerChoice)
                {
                    case Status.Scissors:
                        Results = Results.Win;
                        break;
                    case Status.Rock:
                        Results = Results.Draw;
                        break;
                    case Status.Paper:
                        Results = Results.Lose;
                        break;
                    default:
                        break;
                }
            }
            if(ExchangedUserChoice == Status.Paper)
            {
                switch(ExchangedComputerChoice)
                {
                    case Status.Scissors:
                        Results = Results.Lose;
                        break;
                    case Status.Rock:
                        Results = Results.Win;
                        break;
                    case Status.Paper:
                        Results = Results.Draw;
                        break;
                    default:
                        break;
                }
            }

            return Results;
        }
    }
}
