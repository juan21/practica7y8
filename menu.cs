using System;

namespace practica7
{
	
	public class menu
	{
		public menu(){
			
		}
		ingreso r=new ingreso();
		public void mostrarmenu(){
			
			string nombre,email,codigo,telefono,men,id;
			Console.WriteLine("Menu principal\n");
			Console.WriteLine("a) Mostrar Datos\n" +
			                  "b) Agregar Datos\n" +
			                  "c) Editar  Datos\n" +
			                  "d) Eliminar Datos\n" +
			                  "e) Terminar apliacion");
			men=Console.ReadLine();
			switch(men){
					
				case "a":
					Console.Clear();
					r.mostrarconexion();
					Console.WriteLine("\n");
					mostrarmenu();
					break;
				case "b":
					Console.Clear();
					Console.Write("Nombre: ");
					nombre= Console.ReadLine();
					Console.Write("Codigo: ");
					codigo = Console.ReadLine();
					Console.Write("Telefono: ");
					telefono= Console.ReadLine();
					Console.Write("Email: ");
					email=Console.ReadLine();
					Console.WriteLine("\n");
					r.agregarregistro(nombre,codigo,telefono,email);
					r.mostrarconexion();
					Console.WriteLine("\n");
					mostrarmenu();
					break;
				case "c":
					Console.WriteLine("ID a editar");
					id=Console.ReadLine();
					Console.Write("Nombre: ");
					nombre= Console.ReadLine();
					Console.Write("Codigo: ");
					codigo = Console.ReadLine();
					Console.Write("Telefono: ");
					telefono= Console.ReadLine();
					Console.Write("Email: ");
					email=Console.ReadLine();
					Console.WriteLine("\n");
					r.editarRegistro(id,nombre,codigo,telefono,email);
					r.mostrarconexion();
					Console.WriteLine("\n");
					mostrarmenu();
					break;
				case "d":
					
					Console.WriteLine("ID del ingreso a eliminar:");
					id=Console.ReadLine();
				    r.eliminarRegistroPorId(id);
					r.mostrarconexion();
					Console.WriteLine("\n");
					mostrarmenu();
					break;
					case "e": System.Environment.Exit(-1);
					break;
			}
		}
	}
}
