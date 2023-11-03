namespace Category5ScoutingBot;

public static class Utils
{
    public static string GetParentDirectoryRecursive(string path, int i = 1)
    {
        i--;

        string parent = Directory.GetParent(path)!.FullName;

        if (i <= 0)
        {
            return parent;
        }

        return GetParentDirectoryRecursive(parent, i);
    }
}