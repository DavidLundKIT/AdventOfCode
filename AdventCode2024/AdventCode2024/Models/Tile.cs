namespace AdventCode2024.Models;

public class Tile
{
    public Compass Direction { get; set; } = Compass.East;
    public int X { get; set; }
    public int Y { get; set; }
    public int Cost { get; set; }
    public int Distance { get; set; }
    public int CostDistance => Cost + Distance;
    public Tile? Parent { get; set; }

    //The distance is essentially the estimated distance, ignoring walls to our target. 
    //So how many tiles left and right, up and down, ignoring walls, to get there. 
    public void SetDistance(int targetX, int targetY)
    {
        this.Distance = Math.Abs(targetX - X) + Math.Abs(targetY - Y);
    }

    public void SetDistanceAndCost(int targetX, int targetY)
    {
        this.Distance = Math.Abs(targetX - X) + Math.Abs(targetY - Y);
        if (Parent != null)
        {
            if (Y == Parent.Y - 1)
                Direction = Compass.North;
            else if (Y == Parent.Y + 1)
                Direction = Compass.South;
            else if (X == Parent.X - 1)
                Direction = Compass.West;
            else if (X == Parent.X + 1)
                Direction = Compass.East;
            else
                throw new Exception("direction mix up!");

            switch (Parent.Direction)
            {
                case Compass.North:
                    switch (Direction)
                    {
                        case Compass.North:
                            Cost = Parent.Cost + 1;
                            break;
                        case Compass.East:
                            Cost = Parent.Cost + 1001;
                            break;
                        case Compass.South:
                            Cost = Parent.Cost + 2001;
                            break;
                        case Compass.West:
                            Cost = Parent.Cost + 1001;
                            break;
                        default:
                            throw new Exception("Cost mix up!");
                    }
                    break;
                case Compass.East:
                    switch (Direction)
                    {
                        case Compass.North:
                            Cost = Parent.Cost + 1001;
                            break;
                        case Compass.East:
                            Cost = Parent.Cost + 1;
                            break;
                        case Compass.South:
                            Cost = Parent.Cost + 1001;
                            break;
                        case Compass.West:
                            Cost = Parent.Cost + 2001;
                            break;
                        default:
                            throw new Exception("Cost mix up!");
                    }
                    break;
                case Compass.South:
                    switch (Direction)
                    {
                        case Compass.North:
                            Cost = Parent.Cost + 2001;
                            break;
                        case Compass.East:
                            Cost = Parent.Cost + 1001;
                            break;
                        case Compass.South:
                            Cost = Parent.Cost + 1;
                            break;
                        case Compass.West:
                            Cost = Parent.Cost + 1001;
                            break;
                        default:
                            throw new Exception("Cost mix up!");
                    }
                    break;
                case Compass.West:
                    switch (Direction)
                    {
                        case Compass.North:
                            Cost = Parent.Cost + 1001;
                            break;
                        case Compass.East:
                            Cost = Parent.Cost + 2001;
                            break;
                        case Compass.South:
                            Cost = Parent.Cost + 1001;
                            break;
                        case Compass.West:
                            Cost = Parent.Cost + 1;
                            break;
                        default:
                            throw new Exception("Cost mix up!");
                    }
                    break;
                default:
                    throw new Exception("Cost mix up!");
            }
        }
        //Cost = Parent == null? 0: Parent.Cost + 1;
    }
}
