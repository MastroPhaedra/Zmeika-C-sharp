using System.Collections.Generic;
using Snake.Properties;
// то всё пример, который нужно доработать
//namespace Snake
//{
public class Walls
{
    private List<Figure> wallList;

    public Walls(int mapWidth, int mapHeight)
    {
        wallList = new List<Figure>();

        int widthScoreWall = 30;

        // Draw box
        HorizontalLine upLine = new HorizontalLine(0, mapWidth + widthScoreWall, 0, '+');
        HorizontalLine downLine = new HorizontalLine(0, mapWidth + widthScoreWall, mapHeight - 1, '+');
        VerticalLine leftLine = new VerticalLine(0, mapHeight - 1, 0, '+');
        VerticalLine rightLine = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '+');
        VerticalLine scoreRightWall = new VerticalLine(0, mapHeight - 1, mapWidth + widthScoreWall, '+');
        wallList.Add(upLine);
        wallList.Add(downLine);
        wallList.Add(leftLine);
        wallList.Add(rightLine);
        wallList.Add(scoreRightWall);
    }

    internal bool IsHit(Figure figure)
    {
        foreach (var wall in wallList)
        {
            if (wall.IsHit(figure))
            {
                return true;
            }
        }

        return false;
    }

    public void Draw()
    {
        foreach (var wall in wallList)
        {
            wall.Draw();
        }
    }
}
//}