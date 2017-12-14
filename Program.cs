using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
/*Desarrollado por IDEAN*/
/*Programa para formatear archivos de cualquier formato a formato UTF-8 por medio de carpetas IN y OUT. Por tiempo indeterminado.*/

namespace convertidor
{
    class Program
    {
        static void Main(string[] args)
        {
            string prefijo = "UTF-8-";
            string dirNew;
            string dirNew2;
            string ArgDir1 = "";
            string ArgDir2 = "";
            string path1 = "";
            string path2 = "";
            Boolean result;
            string horaInicioP = DateTime.Now.ToString("hh:mm:ss");
            string fechaInicioP = DateTime.Now.ToString("dd/MM/yyyy");

            /*Asignacion de variables por medio de command line. para la creacion de carpetas automaticamente.*/
            if (args.Length == 2)
            {
                ArgDir1 = args[0];
                ArgDir2 = args[1];
            }
            Console.WriteLine("\t\t    Creado por IDEAN Innovacion de negocios");
            Console.WriteLine("\t\t\tBienvenido a Formating Convert");
            Console.WriteLine("\n\n\t\t\tEstamos preparando para usted!");
            System.Threading.Thread.Sleep(4000);
            Console.Clear();
            Console.WriteLine("\t\t\t\t\tListo!!");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("\t\t\tConvertidor de formato (ANSII - UTF-8)");
            Console.WriteLine("\t\t\t\tDesarrollado por IDEAN");
            Console.WriteLine("\t\t\t\t\tVersion 1.0");
            Console.WriteLine("Inicio del programa: " + fechaInicioP + "-" + horaInicioP);
            Console.WriteLine("\n\n\n Escriba la ruta donde quiere procesar los archivos: ");
            Console.WriteLine("\nEjemplo: C:\\ArchivosParaProcesar\\");
            /*Asignacion de variables , si no se mandan parametros por medio de bash, el usuario puede asignarlas por medio de la linea de comandos.*/
            if (ArgDir1 == "")
            {
                path1 = Convert.ToString(Console.ReadLine());
                path1 = path1 + "\\";
            }
            else
                path1 = ArgDir1;
            Console.Clear();
            Console.WriteLine("\t\t\tConvertidor de formato (ANSII - UTF-8)");
            Console.WriteLine("\t\t\t\tDesarrollado por IDEAN");
            Console.WriteLine("\t\t\t\t\tVersion 1.0");
            Console.WriteLine("Inicio del programa: " + fechaInicioP + "-" + horaInicioP);
            Console.WriteLine("Escriba la ruta donde quiere guardar los archivos procesados: ");
            Console.WriteLine("Ejemplo: C:\\ArchivosProcesados\\");
            /*Asignacion de variables , si no se mandan parametros por medio de bash, el usuario puede asignarlas por medio de la linea de comandos.*/
            if (ArgDir2 == "")
            {
                path2 = Convert.ToString(Console.ReadLine());
                path2 = path2 + "\\";
            }
            else
                path2 = ArgDir2;
            Console.Clear();

            /*Creacion de directorios para procesar archivos*/
            dirNew = Convert.ToString(Directory.CreateDirectory(path1 + "\\"));
            dirNew2 = Convert.ToString(Directory.CreateDirectory(path2 + "\\"));

            if (Directory.Exists(path1))
                Console.WriteLine("Directorio de entrada creado correctamente en:" + dirNew);
            else if (Directory.Exists(path2))
                Console.WriteLine("Directorio de salida creado correctamente en:" + dirNew2);
            else
                Console.WriteLine("Error al crear los directorios!");

            /*Metemos este pedazo de codigo en un blucle infinito con la variable bool r que siempre sea true.*/
            Boolean r = true;
            while (r == true)
            {
                string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
                string horaActual = DateTime.Now.ToString("hh:mm:ss");
                Console.Clear();
                Console.WriteLine("\t\t\tConvertidor de formato (ANSII - UTF-8)");
                Console.WriteLine("\t\t\t\tDesarrollado por IDEAN");
                Console.WriteLine("\t\t\t\t\tVersion 1.0");
                Console.WriteLine("Inicio del programa: " + fechaInicioP + "-" + horaInicioP);
                Console.WriteLine("Fecha y hora actual: " + fechaActual + "-" + horaActual);
                Console.WriteLine("Carpeta de lectura: " + path1 + "\\");
                Console.WriteLine("Carpeta de escritura: " + path2 + "\\");
                System.Threading.Thread.Sleep(10000);
                /*Se guardan en un arreglo los archivos para despues ser procesados.*/
                string[] ubicacion = Directory.GetFiles(path1);
                for (int i = 0; i < ubicacion.Length; i++) { }
                string[] filePaths = Directory.GetFiles(path1, "*.yaml");
                Boolean cantidad = Convert.ToBoolean(filePaths.Length);
                result = Convert.ToBoolean(cantidad);

                /*Se recorre el arreglo que contiene la ruta de los archivos para su evaluacion*/
                foreach (var file in filePaths)
                {
                    String[] fileSegments = file.Split('\\');
                    string fileName = fileSegments[fileSegments.Length - 1];
                    System.Console.Write("Procesando " + " " + fileSegments[fileSegments.Length - 1] + " --> " + fileName + "\n");
                    /*Guarda y crea el archivo , se le agrega un prefijo para diferenciar el archivo ya formateado*/
                    File.WriteAllText(path2 + '\\' + prefijo + fileName, readFileAsUtf8(file));
                }

                System.Console.Write("\n\nProceso de conversión finalizado.");
            }
        }

        /*Funcion para codificacion de archivo nuevo UTF-8*/
        /*Recibe como parametro la variable "fileName"*/
        public static String readFileAsUtf8(string fileName)
        {
            Encoding encoding = Encoding.Default;
            String original = String.Empty;

            using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
            {
                original = sr.ReadToEnd();
                encoding = sr.CurrentEncoding;
                sr.Close();
            }

            if (encoding == Encoding.UTF8)
                return original;

            byte[] encBytes = encoding.GetBytes(original);
            byte[] utf8Bytes = Encoding.Convert(encoding, Encoding.UTF8, encBytes);
            return Encoding.UTF8.GetString(utf8Bytes);
        }
    }
}

