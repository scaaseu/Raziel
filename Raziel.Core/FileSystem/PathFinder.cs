using System.Reflection;

namespace Raziel.Core.FileSystem;

public static class PathFinder
{
    public static string SolutionDir()
    {
        var directory = new DirectoryInfo(Directory.GetCurrentDirectory());

        while (directory != null && !directory.GetFiles("Raziel.sln").Any())
            directory = directory.Parent;

        return directory?.FullName;
    }


    public static string WorkingDir()
    {
        return new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
    }

}