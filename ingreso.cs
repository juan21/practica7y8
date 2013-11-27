using MySql.Data.MySqlClient;
using System;

namespace practica7
{
	
	public class ingreso : MySQL
	{
		public ingreso()
		{
			
		}
		public void mostrarconexion(){
			this.abrirConexion();
			MySqlCommand myCommand = new MySqlCommand(this.querySelect(),
			                                          myConnection);
			MySqlDataReader myReader = myCommand.ExecuteReader();
			while (myReader.Read()){
				string id = myReader["id"].ToString();
				string nombre = myReader["Nombre"].ToString();
				string codigo = myReader["Codigo"].ToString();
				string telefono = myReader["Telefono"].ToString();
				string email = myReader["Email"].ToString();
				Console.WriteLine("ID: " + id +
				                  " Nombre: " + nombre +
				                  " Codigo: " + codigo +
				                  " Telefono:" + telefono +
				                  " Email:" + email);
			}
			
			myReader.Close();
			myReader = null;
			myCommand.Dispose();
			myCommand = null;
			this.cerrarConexion();
		}
		public void agregarregistro(string nombre, string codigo, string telefono, string email){
			this.abrirConexion();
			string sql="INSERT INTO `datos`(`nombre`, `codigo`, `telefono`, `email`) VALUES ('"+nombre+"','"+codigo+"','"+telefono+"','"+email+"')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
			Console.WriteLine("Se Ingreso con exito\n");
			
		}
		public void editarRegistro(string id, string nombre,string codigo, string telefono, string email){
			Console.WriteLine("Seguro que desea Editarlo");
	 		Console.WriteLine ("n=No, s=SI");
	 		string opc = Console.ReadLine();
	 			      if (opc!="n"){
			this.abrirConexion();
			string sql = "UPDATE `datos` SET `nombre`='" + nombre + "',`codigo`='" + codigo + "',`telefono`='" + telefono + "',`email`='" + email + "'  WHERE (`id`='" + id + "')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
			Console.WriteLine("Se edito con exito\n");
			}
		}
		public void eliminarRegistroPorId(string id){
			Console.WriteLine("desea eliminarlo");
	 		Console.WriteLine ("n=No, s=SI");
	 		string opc = Console.ReadLine();
	 			      if (opc!="n"){
			this.abrirConexion();
			string sql = "DELETE FROM `datos` WHERE (`id`='" + id + "')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
			Console.WriteLine("Se elimino con exito\n");
			}
		}
		private int ejecutarComando(string sql){
			MySqlCommand myCommand = new MySqlCommand(sql,this.myConnection);
			int afectadas = myCommand.ExecuteNonQuery();
			myCommand.Dispose();
			myCommand = null;
			return afectadas;
		}
		
		
		private string querySelect(){
			return "SELECT * " +
				"FROM  datos";
		}
	}
}
