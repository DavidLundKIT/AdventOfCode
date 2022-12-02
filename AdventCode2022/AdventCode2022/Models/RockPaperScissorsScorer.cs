namespace AdventCode2022.Models
{
    public class RockPaperScissorsScorer
    {

        public static int GameScorer(char playerA, char playerB)
        {
            int score = 0;

            switch (playerA)
            {
                case 'A':
                    switch (playerB)
                    {
                        case 'X':
                            // rock - rock
                            score = 1 + 3;
                            break;
                        case 'Y':
                            // rock - paper
                            score = 2 + 6;
                            break;
                        case 'Z':
                            // rock - scissor
                            score = 3 + 0;
                            break;
                        default:
                            break;
                    }
                    break;
                case 'B':
                    switch (playerB)
                    {
                        case 'X':
                            // paper - rock
                            score = 1 + 0;
                            break;
                        case 'Y':
                            // paper - paper
                            score = 2 + 3;
                            break;
                        case 'Z':
                            // paper - scissor
                            score = 3 + 6;
                            break;
                        default:
                            break;
                    }
                    break;
                case 'C':
                    switch (playerB)
                    {
                        case 'X':
                            // scissor - rock
                            score = 1 + 6;
                            break;
                        case 'Y':
                            // scissor - paper
                            score = 2 + 0;
                            break;
                        case 'Z':
                            // scissor - scissor
                            score = 3 + 3;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            return score;
        }

        public static int GameAdjustedScorer(char playerA, char playerB)
        {
            // A = rock, B=Paper, C=Scissor
            // X = lose, Y= draw, Z= win
            int score = 0;

            switch (playerA)
            {
                case 'A':
                    switch (playerB)
                    {
                        case 'X':
                            // rock - lose scissor
                            score = 3 + 0;
                            break;
                        case 'Y':
                            // rock - draw
                            score = 1 + 3;
                            break;
                        case 'Z':
                            // rock - win paper
                            score = 2 + 6;
                            break;
                        default:
                            break;
                    }
                    break;
                case 'B':
                    switch (playerB)
                    {
                        case 'X':
                            // paper - rock
                            score = 1 + 0;
                            break;
                        case 'Y':
                            // paper - paper
                            score = 2 + 3;
                            break;
                        case 'Z':
                            // paper - scissor
                            score = 3 + 6;
                            break;
                        default:
                            break;
                    }
                    break;
                case 'C':
                    switch (playerB)
                    {
                        case 'X':
                            // scissor - lose
                            score = 2 + 0;
                            break;
                        case 'Y':
                            // scissor - draw
                            score = 3 + 3;
                            break;
                        case 'Z':
                            // scissor - win rock
                            score = 1 + 6;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            return score;
        }
    }
}
