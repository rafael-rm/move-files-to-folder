using MoveFilesToFolder.Kernel.Controller;

namespace MoveFilesToFolder.Console;

abstract class Program
{
    static void Main()
    {
         string sourceFolderPath = "C:\\Users\\rafae\\Pictures\\Photos";
         string destinationFolderPath = "C:\\Users\\rafae\\Pictures\\All Files";
         
         FilesController.IsValidPath(sourceFolderPath);
         FilesController.IsValidPath(destinationFolderPath);

         FilesController.DeleteInvalidFiles(sourceFolderPath, "json");
         FilesController.DeleteInvalidFiles(sourceFolderPath, "htm*");

         FilesController.MoveFiles(sourceFolderPath, destinationFolderPath);
    }
}