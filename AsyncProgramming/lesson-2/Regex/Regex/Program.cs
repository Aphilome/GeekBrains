using System.Text.RegularExpressions;

string str = "     Предложение   один Теперь      предложение  два   Предложение     три    ";
Console.WriteLine(str);

string singleSpaceStr = Regex.Replace(str.Trim(), "[ ][ ]+", " ");
Console.WriteLine(singleSpaceStr);

string strWithDots = Regex.Replace(singleSpaceStr, "([ ])([А-ЯA-Z]+)", ". $2");
Console.WriteLine($"{strWithDots}.");
