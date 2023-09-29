namespace MoveFilesToFolder.Kernel.Controller;

public class FilesController
{
    public static void MoveFiles(string sourceFolderPath, string destinationFolderPath)
    {
        int countMoved = 0;
        int countNotMoved = 0;

        foreach (string filePath in Directory.GetFiles(sourceFolderPath, "*", SearchOption.AllDirectories))
        {
            string destinationFilePath = Path.Combine(destinationFolderPath, Path.GetFileName(filePath));

            if (File.Exists(destinationFilePath))
            {
                Console.WriteLine($"O arquivo {Path.GetFileName(filePath)} já existe no diretório de destino. Não foi movido.");
                countNotMoved++;
            }
            else
            {
                File.Move(filePath, destinationFilePath);
                Console.WriteLine($"Arquivo {Path.GetFileName(filePath)} movido para {destinationFilePath}");
                countMoved++;
            }
        }

        Console.WriteLine("Todos os arquivos foram movidos com sucesso.");
        Console.WriteLine($"Total de arquivos movidos: {countMoved}");
        Console.WriteLine($"Total de arquivos não movidos: {countNotMoved}");
    }

    public static void DeleteInvalidFiles(string sourceFolderPath, string extension)
    {
        string[] pathInvalidFiles = Directory.GetFiles(sourceFolderPath, $"*.{extension}", SearchOption.AllDirectories);

        int countDeleted = 0;

        foreach (string filePath in pathInvalidFiles)
        {
            File.Delete(filePath);
            Console.WriteLine($"[INFO] Arquivo {filePath} apagado com sucesso.");
            countDeleted++;
        }
        Console.WriteLine($"Todos os arquivos com a extensão .{extension} foram apagados com sucesso.");
        Console.WriteLine($"Total de arquivos apagados: {countDeleted}");
    }

    public static void IsValidPath(string path)
    {
        if (!Directory.Exists(path))
            throw new DirectoryNotFoundException($"O diretório {path} não existe.");
    }
}