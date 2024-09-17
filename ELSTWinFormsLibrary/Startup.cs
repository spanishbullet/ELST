using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELSTWinFormsLibrary;

/*//Non threaded drive search with non threaded directory count
 * 
 * public class Startup()
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

/*//Non threaded search w/o directory count
 * 
 * public class Startup()
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

/*//Threaded search with threaded or non threaded directory count
 * 
 * public class Startup
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
        catch (UnauthorizedAccessException) { *//* Handle or skip inaccessible directories *//* }
        catch (OperationCanceledException) { *//* Handle cancellation *//* }
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
            *//* Handle or skip inaccessible directories *//* }
        catch (Exception ex) { Console.WriteLine($"Error counting directories: {ex.Message}"); }

        return count;
    }

    *//*private static int CountTotalDirectories(string dir)
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
    }*//*
}*/

public class Startup
{
    public static List<string> Search(string dir, string fileName, IProgress<int> progress = null, CancellationToken cancellationToken = default)
    {
        //MessageBox.Show(totalDirectories.ToString());
        ConcurrentBag<int> processedDirs = [];
        return searchDirectory(dir, fileName, processedDirs, progress, cancellationToken);
    }

    private static List<string> searchDirectory(string dir, string fileName, ConcurrentBag<int> processedDirectories, IProgress<int> progress = null, CancellationToken cancellationToken = default)
    {
        List<string> filePaths = new List<string>();

        try
        {
            // Check for cancellation
            cancellationToken.ThrowIfCancellationRequested();

            // Process the current directory
            foreach (string file in Directory.GetFiles(dir, fileName))
            {
                cancellationToken.ThrowIfCancellationRequested();
                filePaths.Add(file);
            }

            // Add to the ConcurrentBag in a thread-safe manner
            processedDirectories.Add(1);

            // Calculate the total number of processed directories
            int currentProcessedDirectories = processedDirectories.Count;

            // Report progress in a thread-safe manner
            //System.Diagnostics.Debug.WriteLine(currentProcessedDirectories);
            int numdirs = currentProcessedDirectories;
            //System.Diagnostics.Debug.WriteLine(percent);
            if (numdirs % 100 == 0)
            {
                progress?.Report(numdirs);
            }

            // Get subdirectories and process them in parallel
            string[] subDirs = Directory.GetDirectories(dir);
            try
            {
                Parallel.ForEach(subDirs, new ParallelOptions
                {
                    CancellationToken = cancellationToken,
                    MaxDegreeOfParallelism = Environment.ProcessorCount // Optional parallelism control
                }, subDir =>
                {
                    try
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        filePaths.AddRange(searchDirectory(subDir, fileName, processedDirectories, progress, cancellationToken));
                    }
                    catch (OperationCanceledException ex)
                    {
                        // Handle cancellation exception in parallel task
                        //System.Diagnostics.Debug.WriteLine($"Parallel task canceled: {ex.Message}");
                        throw; // Re-throw if needed to ensure cancellation is propagated
                    }
                    catch (Exception ex)
                    {
                        // Handle other exceptions in parallel task
                        //System.Diagnostics.Debug.WriteLine($"Parallel task error: {ex.Message}");
                        // Optionally, handle or re-throw other exceptions as needed
                    }
                });
            }
            catch (AggregateException aggEx)
            {
                // Handle AggregateException and rethrow non-cancellation exceptions
                foreach (var ex in aggEx.InnerExceptions)
                {
                    if (ex is OperationCanceledException)
                    {
                        // Ensure cancellation is propagated
                        throw;
                    }
                    else
                    {
                        // Log other exceptions
                        //System.Diagnostics.Debug.WriteLine($"Error processing directory {dir}: {ex.Message}");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Handle or log cancellation specifically if needed
                //System.Diagnostics.Debug.WriteLine("Operation was canceled.");
                // Optionally, rethrow or handle cancellation exception if needed
                throw;
            }
            catch (Exception ex)
            {
                // Handle other unexpected exceptions
                //System.Diagnostics.Debug.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
        catch (UnauthorizedAccessException) { /* Handle or skip inaccessible directories */ }
        catch (OperationCanceledException) 
        {
            throw;
            //return filePaths; 
        }
        catch (Exception ex) 
        { 
            //Console.WriteLine($"Error searching files: {ex.Message}");
        }

        return filePaths;
    }
}

