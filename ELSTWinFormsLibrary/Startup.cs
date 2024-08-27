using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELSTWinFormsLibrary;

public class Startup()
{

    public static List<string> Search(string dir, string fileName, IProgress<int> progress = null, CancellationToken cancellationToken = default)
    {
        int processedDirectories = 1;
        return searchDirectory(dir, fileName, CountTotalDirectories(dir), ref processedDirectories, progress, cancellationToken);
    }

    private static List<string> searchDirectory(string dir, string fileName, int totalDirectories, ref int processedDirectories, IProgress<int> progress = null, CancellationToken cancellationToken = default)
    {
        List<string> filePaths = new List<string>();

        try
        {
            // Check for cancellation
            cancellationToken.ThrowIfCancellationRequested();

            // Process the current directory
            foreach (string file in Directory.GetFiles(dir, fileName))
            {
                filePaths.Add(file);
            }

            // Report progress after processing the current directory
            processedDirectories++;
            int progressPercentage = (processedDirectories * 100) / totalDirectories;
            progress?.Report(progressPercentage);

            // Recursively search in subdirectories
            foreach (string subDir in Directory.GetDirectories(dir))
            {
                filePaths.AddRange(searchDirectory(subDir, fileName, totalDirectories, ref processedDirectories, progress, cancellationToken));
            }
        }
        catch (UnauthorizedAccessException) { /* Handle or skip inaccessible directories */ }
        catch (Exception ex) { Console.WriteLine($"Error searching files: {ex.Message}"); }

        return filePaths;
    }


    private static int CountTotalDirectories(string dir)
    {
        int count = 1; // Start with 1 to include the current directory

        try
        {
            foreach (string subDir in Directory.GetDirectories(dir))
            {
                count += CountTotalDirectories(subDir); // Recursively count subdirectories
            }
        }
        catch (UnauthorizedAccessException) { /* Handle or skip inaccessible directories */ }
        catch (Exception ex) { Console.WriteLine($"Error counting directories: {ex.Message}"); }

        return count;
    }
}
