using PlainFiles.Core;

Console.Write("Digite el nombre de la lista: ");
var listName = Console.ReadLine();
var manualCsv = new ManualCsvHelper();
var people = manualCsv.ReadCsv($"{listName}.csv");
var option = string.Empty;

do
{
    option = MyMenu();
    switch (option)
    {
        case "1":
            Console.Write("Digite el nombre: ");
            var name = Console.ReadLine();
            Console.Write("Digite el apellido: ");
            var lastName = Console.ReadLine();
            Console.Write("Digite la edad: ");
            var age = Console.ReadLine();
            people.Add([name ?? string.Empty, lastName ?? string.Empty, age ?? string.Empty]);
            break;

        case "2":
            Console.WriteLine("Lista de personas:");
            Console.WriteLine($"Nombres|Apellidos|Edad");
            foreach (var person in people)
            {
                Console.WriteLine($"{person[0]}|{person[1]}|{person[2]}");
            }
            break;

        case "3":
            SaveFile(people, listName);
            Console.WriteLine("Archivo guardado.");
            break;

        case "0":
            Console.WriteLine("Saliendo...");
            break;

        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
} while (option != "0");

string MyMenu()
{
    Console.WriteLine("1. Adicionar.");
    Console.WriteLine("2. Mostrar.");
    Console.WriteLine("3. Grabar.");
    Console.WriteLine("0. Salir.");
    Console.Write("Seleccione una opción: ");
    return Console.ReadLine() ?? string.Empty;
}
SaveFile(people, listName);

void SaveFile(List<string[]> people, string? listName)
{
    manualCsv.WriteCsv($"{listName}.csv", people);
}