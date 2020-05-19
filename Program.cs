using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab6_MatiasLeguer
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Bienvenido!!\n");
            Thread.Sleep(500);
            bool loop = true;
            string nombre, rut;
            Empresa empresa;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("Si desea Crear un archivo de empresa, escriba 1.\nSi desea Cargar un archivo de empresa, escriba 2.\nSi desea salir del programa, escriba 3.");
                string resp;
                do
                {
                    resp = Console.ReadLine();
                    if (resp != "1" && resp != "2" && resp != "3")
                    {
                        Console.Write("Porfavor escriba un comando correcto (1, 2, 3): ");
                    }
                } while (resp != "1" && resp != "2" && resp != "3");

                Console.Clear();
                Thread.Sleep(500);
                switch (resp)
                {
                    case "1":
                        Console.Write("Porfavor ingrese el nombre de su empresa: "); nombre = Console.ReadLine();
                        Console.Write("Porfavor ingrese el rut de su empresa: ");    rut = Console.ReadLine();
                        empresa = new Empresa(nombre, rut);
                        empresa.Opcion = 0;
                        GuardarDatosEmpresa(empresa, empresa.Opcion);
                        Console.WriteLine("Se han guardado los datos en un archivo!");
                        Thread.Sleep(500);
                        break;

                    case "2":
                        try
                        {
                            empresa = LoadFileCompany();
                            ShowInfoEmpresa(empresa, empresa.Opcion);
                            

                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine("No existe archivo con datos de la empresa.");
                            Console.Write("Porfavor ingrese el nombre de su empresa: ");     nombre = Console.ReadLine();
                            Console.Write("Porfavor ingrese el rut de su empresa: ");        rut = Console.ReadLine();
                            empresa = new Empresa(nombre, rut);
                            empresa.Opcion = 1;
                            GuardarDatosEmpresa(empresa, empresa.Opcion);
                            
                        }
                        Console.Write("ingrese cualquier tecla para continuar: ");
                        string tecla = Console.ReadLine();
                        Thread.Sleep(100);
                        break;

                    case "3":
                        loop = false;
                        Console.WriteLine("Se ha salido del programa");
                        break;
                }
            }
        }


        //METODOS ESTATICOS 
        static void ShowInfoEmpresa(Empresa empresa, int opc)
        {
            Console.WriteLine("Nombre Empresa: {0} \tRUT: {1}", empresa.NameCompany, empresa.RutCompany);
            Console.WriteLine("------------------------------------------------------------------------\n");


            if (opc == 0)
            {
                for(int i = 0; i < empresa.ListaDivision.Count(); i++)
                {
                    Console.WriteLine("División {0}: {1}\n", i+1, empresa.ListaDivision[i].NombreDiv);
                    List<int> listaCount = new List<int>() { empresa.ListaDivision[i].ListaArea.Count(), empresa.ListaDivision[i].ListaDep.Count(), empresa.ListaDivision[i].ListaSec.Count(), empresa.ListaDivision[i].ListaBloque.Count() };
                    for (int j = 0; j < listaCount.Max(); j++)
                    {
                        if(j < listaCount[0])
                        {
                            Persona personaA = empresa.ListaDivision[i].ListaArea[j].Encargado;
                            Console.WriteLine("Nombre encargado de Area " + (j + 1) + ": {0} \tApellido: {1} \tRUT: {2}", personaA.NombreP, personaA.ApellidoP, personaA.RUT);
                        }
                        if (j < listaCount[1])
                        {
                            Persona personaDep = empresa.ListaDivision[i].ListaDep[j].Encargado;
                            Console.WriteLine("Nombre encargado de Departamento " + (j + 1) + ": {0} \tApellido: {1} \tRUT: {2}", personaDep.NombreP, personaDep.ApellidoP, personaDep.RUT);
                        }

                        if (j < listaCount[2])
                        {
                            Persona personaSec = empresa.ListaDivision[i].ListaSec[j].Encargado;
                            Console.WriteLine("Nombre encargado de Seccion " + (j + 1) + ": {0} \tApellido: {1} \tRUT: {2}", personaSec.NombreP, personaSec.ApellidoP, personaSec.RUT);
                        }

                        if (j < listaCount[3])
                        {
                            Persona personaBloque = empresa.ListaDivision[i].ListaBloque[j].Encargado;
                            Console.WriteLine("Nombre encargado de Bloque " + (j + 1) + ": {0} \tApellido: {1} \tRUT: {2}", personaBloque.NombreP, personaBloque.ApellidoP, personaBloque.RUT);
                            Console.WriteLine("\nPersonal del Bloque:\n");
                            for (int k = 0; k < 2; k++)
                            {
                                Console.WriteLine("Nombre Personal {0}: {1} \tApellido: {2} \tRut: {3}", k + 1, empresa.ListaDivision[i].ListaBloque[j].Personal[k].NombreP, empresa.ListaDivision[i].ListaBloque[j].Personal[k].ApellidoP, empresa.ListaDivision[i].ListaBloque[j].Personal[k].RUT);
                            }

                        }
                    }
                    Console.WriteLine("------------------------------------------------------------------------\n");
                }

            }
            else
            {
                Persona personaDep = empresa.ListaDivision[0].ListaDep[0].Encargado;
                Persona personaSec = empresa.ListaDivision[0].ListaSec[0].Encargado;
                Console.WriteLine("División {0}: {1}", 1, empresa.ListaDivision[0].NombreDiv);

                Console.WriteLine("Nombre encargado de Departamento: {0} \tApellido: {1} \tRUT: {2}", personaDep.NombreP, personaDep.ApellidoP, personaDep.RUT);
                Console.WriteLine("Nombre encargado de Sección: {0} \tApellido: {1} \tRUT: {2}", personaSec.NombreP, personaSec.ApellidoP, personaSec.RUT);
                
                for(int i = 0; i < 2; i++)
                {
                    Persona personaBloque = empresa.ListaDivision[0].ListaBloque[i].Encargado;
                    Console.WriteLine("Nombre encargado de Bloque: {0} \tApellido: {1} \tRUT: {2}", personaBloque.NombreP, personaBloque.ApellidoP, personaBloque.RUT);

                    Console.WriteLine("\nPersonal del Bloque:\n");
                    for(int j = 0; j < 2; j++)
                    {
                        Console.WriteLine("Nombre Personal {0}: {1} \tApellido: {2} \tRut: {3}", j + 1, empresa.ListaDivision[0].ListaBloque[i].Personal[j].NombreP, empresa.ListaDivision[0].ListaBloque[i].Personal[j].ApellidoP, empresa.ListaDivision[0].ListaBloque[i].Personal[j].RUT);
                    }
                    Console.WriteLine("\n");
                }
            }

        }

        static void GuardarDatosEmpresa(Empresa empresa, int opc)
        {
            List<Division> listaD = new List<Division>();
            if (opc == 0)
            {
                Console.Write("Cuantas divisiones quiere crear?: ");
                int div = int.Parse(Console.ReadLine());

                for (int i = 0; i < div; i++)
                {
                    Console.Write("Porfavor ingrese el nombre de la División: "); string nombre = Console.ReadLine();
                    listaD.Add(new Division(nombre));
                    bool loop = true;

                    List<Area> listaA = new List<Area>();
                    List<Departamento> listaDep = new List<Departamento>();
                    List<Seccion> listaS = new List<Seccion>();
                    List<Bloque> listaB = new List<Bloque>();

                    while (loop)
                    {
                        Console.WriteLine("Porfavor, seleccione una de estas opciones: Area(1), Departamento(2), Sección(3), Bloque(4), salir del programa(5).");
                        int opcion;
                        do
                        {
                            opcion = int.Parse(Console.ReadLine());
                            if (opcion != 1 && opcion != 2 && opcion != 3 && opcion != 4 && opcion != 5)
                            {
                                Console.Write("Comando incorrecto, escriba uno de los numeros señalados en el menu: ");
                            }
                        } while (opcion != 1 && opcion != 2 && opcion != 3 && opcion != 4 && opcion != 5);

                        switch (opcion)
                        {
                            case 1:
                                Console.Write("Porfavor ingrese el nombre del encargado de Área: "); string nombreA = Console.ReadLine();
                                Console.Write("Porfavor ingrese el apellido del encargado de Área: "); string apellidoA = Console.ReadLine();
                                Console.Write("Porfavor ingrese el rut del encargado de Área: "); string rutA = Console.ReadLine();
                                Persona personaA = new Persona(nombreA, apellidoA, rutA, "Area");
                                listaA.Add(new Area(personaA, nombre));

                                break;
                            case 2:
                                Console.Write("Porfavor ingrese el nombre del encargado de Departamento: "); string nombreD = Console.ReadLine();
                                Console.Write("Porfavor ingrese el apellido del encargado de Departamento: "); string apellidoD = Console.ReadLine();
                                Console.Write("Porfavor ingrese el rut del encargado de Departamento: "); string rutD = Console.ReadLine();
                                Persona personaD = new Persona(nombreD, apellidoD, rutD, "Departamento");
                                listaDep.Add(new Departamento(personaD, nombre));
                                break;

                            case 3:
                                Console.Write("Porfavor ingrese el nombre del encargado de Sección: "); string nombreS = Console.ReadLine();
                                Console.Write("Porfavor ingrese el apellido del encargado de Sección: "); string apellidoS = Console.ReadLine();
                                Console.Write("Porfavor ingrese el rut del encargado de Sección: "); string rutS = Console.ReadLine();
                                Persona personaS = new Persona(nombreS, apellidoS, rutS, "Sección");
                                listaS.Add(new Seccion(personaS, nombre));
                                break;

                            case 4:
                                Console.Write("Porfavor ingrese el nombre del encargado de Bloque: "); string nombreB = Console.ReadLine();
                                Console.Write("Porfavor ingrese el apellido del encargado de Bloque: "); string apellidoB = Console.ReadLine();
                                Console.Write("Porfavor ingrese el rut del encargado de Bloque: "); string rutB = Console.ReadLine();
                                Persona personaB = new Persona(nombreB, apellidoB, rutB, "Bloque");
                                listaB.Add(new Bloque(personaB, nombre));

                                List<string> secuencia = new List<string>() { "Primer", "Segundo" };
                                List<Persona> listaP = new List<Persona>();
                                for (int j = 0; j < 2; j++)
                                {
                                    Console.Write("Porfavor ingrese el nombre del {0} personal: ", secuencia[j]);
                                    string nombrePersonal = Console.ReadLine();
                                    Console.Write("Porfavor ingrese el apellido del {0} personal: ", secuencia[j]);
                                    string apellidoPersonal = Console.ReadLine();
                                    Console.Write("Porfavor ingrese el Rut del {0} personal: ", secuencia[j]);
                                    string rutPersonal = Console.ReadLine();
                                    listaP.Add(new Persona(nombrePersonal, apellidoPersonal, rutPersonal, "Bloque"));

                                }
                                listaB[listaB.Count() - 1].Personal = listaP;
                                break;
                            case 5:
                                loop = false;
                                break;
                        }
                    }
                    listaD[i].ListaArea = listaA;
                    listaD[i].ListaDep = listaDep;
                    listaD[i].ListaSec = listaS;
                    listaD[i].ListaBloque = listaB;
                }
                empresa.ListaDivision = listaD;
                SaveFileCompany(empresa);
            }
            else
            {
                string nombre = "Ing Uandes";
                listaD.Add(new Division(nombre));
                List<Departamento> listaDep = new List<Departamento>();
                List<Seccion> listaS = new List<Seccion>();
                List<Bloque> listaB = new List<Bloque>();
                List<Persona> listaPersonas = new List<Persona>(4) { new Persona("Andres", "Howard", "15666777-8", "Bloque"), new Persona("Carlos", "Diaz", "16333666-7", "Bloque"), new Persona("Vicente", "Namur", "20654444-5", "Bloque"), new Persona("Matias", "Ruz", "20555667-5", "Bloque") };

                listaDep.Add(new Departamento());

                listaS.Add(new Seccion());

                Bloque bloque1 = new Bloque();
                bloque1.Personal.Add(listaPersonas[0]);
                bloque1.Personal.Add(listaPersonas[2]);
                listaB.Add(bloque1);

                Persona personaBloque2 = new Persona("Carmen Gloria", "Ruiz", "20556554-7", "Bloque");
                Bloque bloque2 = new Bloque(personaBloque2);
                bloque2.Personal.Add(listaPersonas[1]);
                bloque2.Personal.Add(listaPersonas[3]);
                listaB.Add(bloque2);

                listaD[0].ListaDep = listaDep;
                listaD[0].ListaSec = listaS;
                listaD[0].ListaBloque = listaB;


                empresa.ListaDivision = listaD;

                SaveFileCompany(empresa);
            }
        }

        static void SaveFileCompany(Empresa empresa)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("empresa.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, empresa);
            stream.Close();
        }

        static Empresa LoadFileCompany()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("empresa.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            Empresa empresa = (Empresa)formatter.Deserialize(stream);
            stream.Close();
            return empresa;
        }

        
 
    }
}
