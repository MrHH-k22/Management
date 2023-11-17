
public class MyString
{
    public static string Capitalize(string name)
    {
        string[] splits = name.Split(' ');
        string result = "";
        foreach (string word in splits)
        {
            result += word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower() + " ";
        }
        return result.Substring(0, result.Length - 1);
    }


}

