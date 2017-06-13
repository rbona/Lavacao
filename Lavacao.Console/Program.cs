using Lavacao.DAL.Repositorios;
using Lavacao.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavacao.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Incluir();
        }

        private static void Incluir()
        {
            using (var repCarro = new CarroRepositorio())
            {
                try
                {
                    new List<Carro>
                {
                    new Carro() {Marca="Volkswagem",Modelo="Gol G5", Placa="ABC1234" }
                }.ForEach(repCarro.Adicionar);

                    repCarro.Salvar();
                }
                catch { }

                System.Console.WriteLine("Carros Cadastrados: ");
                foreach (Carro carro in repCarro.BuscarTodos())
                    System.Console.WriteLine(string.Format("ID: {0} - Placa: {1} - Marca: {2} - Modelo: {3}", carro.CarroID, carro.Placa, carro.Marca, carro.Modelo));

                System.Console.ReadKey();
            }
        }
    }
}
