using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELSTWinFormsLibrary;

/*public class Startup()
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
        catch (UnauthorizedAccessException) { *//* Handle or skip inaccessible directories *//* }
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
        catch (UnauthorizedAccessException) { *//* Handle or skip inaccessible directories *//* }
        catch (Exception ex) { Console.WriteLine($"Error counting directories: {ex.Message}"); }

        return count;
    }
}
*/

/*public class Startup()
{

    public static List<string> Search(string dir, string fileName, IProgress<int> progress = null, CancellationToken cancellationToken = default)
    {
        int processedDirectories = 1;
        return searchDirectory(dir, fileName,ref processedDirectories, progress, cancellationToken);
    }

    private static List<string> searchDirectory(string dir, string fileName, ref int processedDirectories, IProgress<int> progress = null, CancellationToken cancellationToken = default)
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
            int progressPercentage = (processedDirectories / 3000) ;
            progress?.Report(progressPercentage);

            // Recursively search in subdirectories
            foreach (string subDir in Directory.GetDirectories(dir))
            {
                filePaths.AddRange(searchDirectory(subDir, fileName, ref processedDirectories, progress, cancellationToken));
            }
        }
        catch (UnauthorizedAccessException) { *//* Handle or skip inaccessible directories *//* }
        catch (Exception ex) { Console.WriteLine($"Error searching files: {ex.Message}"); }

        return filePaths;
    }
}*/

public class Startup
{
    public static List<string> Search(string dir, string fileName, IProgress<int> progress = null, CancellationToken cancellationToken = default)
    {
        int totalDirectories = CountTotalDirectories(dir);
        //MessageBox.Show(totalDirectories.ToString());
        ConcurrentBag<int> processedDirs = [];
        return searchDirectory(dir, fileName, processedDirs, totalDirectories, progress, cancellationToken);
    }

    private static List<string> searchDirectory(string dir, string fileName, ConcurrentBag<int> processedDirectories, int totalDirectories, IProgress<int> progress = null, CancellationToken cancellationToken = default)
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

            // Add to the ConcurrentBag in a thread-safe manner
            processedDirectories.Add(1);

            // Calculate the total number of processed directories
            int currentProcessedDirectories = processedDirectories.Count;

            // Report progress in a thread-safe manner
            //System.Diagnostics.Debug.WriteLine(currentProcessedDirectories);
            int percent = (currentProcessedDirectories * 100) / totalDirectories;
            //System.Diagnostics.Debug.WriteLine(percent);
            progress?.Report(percent);

            // Get subdirectories and process them in parallel
            string[] subDirs = Directory.GetDirectories(dir);
            Parallel.ForEach(subDirs, new ParallelOptions { CancellationToken = cancellationToken }, subDir =>
            {
                // Recursively search in subdirectories
                filePaths.AddRange(searchDirectory(subDir, fileName, processedDirectories, totalDirectories, progress, cancellationToken));
            });
        }
        catch (UnauthorizedAccessException) { /* Handle or skip inaccessible directories */ }
        catch (OperationCanceledException) { /* Handle cancellation */ }
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
        catch (UnauthorizedAccessException)
        {
            /* Handle or skip inaccessible directories */ }
        catch (Exception ex) { Console.WriteLine($"Error counting directories: {ex.Message}"); }

        return count;
    }

    /*private static int CountTotalDirectories(string dir)
    {
        // Use a thread-safe collection to accumulate the count
        ConcurrentBag<int> directoryCounts = new ConcurrentBag<int>();
        directoryCounts.Add(1); // Start with 1 to include the current directory

        try
        {
            Parallel.ForEach(Directory.GetDirectories(dir), subDir =>
            {
                try
                {
                    directoryCounts.Add(CountTotalDirectories(subDir)); // Recursively count subdirectories
                }
                catch (UnauthorizedAccessException) { *//* Handle or skip inaccessible directories *//* }
                catch (Exception ex) { Console.WriteLine($"Error counting directories: {ex.Message}"); }
            });
        }
        catch (UnauthorizedAccessException) { *//* Handle or skip inaccessible directories *//* }
        catch (Exception ex) { Console.WriteLine($"Error counting directories: {ex.Message}"); }

        return directoryCounts.Sum();
    }*/
}

