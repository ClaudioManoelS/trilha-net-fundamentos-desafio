namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            var placa = new Placa(Console.ReadLine());

            if (placa.Invalida())
            {
                Console.WriteLine("Placa inválida. Não foi possível adicionar o veículo");
                return;
            }

            if (VeiculoExiste(placa))
            {
                Console.WriteLine("Veículo já estacionado. Não foi possível adicionar o veículo");
                return;
            }

            veiculos.Add(placa.valor);
            Console.WriteLine("Veículo adicionado com sucesso");
        }


        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            var placa = new Placa(Console.ReadLine());

            if (placa.Invalida())
            {
                Console.WriteLine("Placa inválida. Não foi possível remover o veículo");
                return;
            }

            if (VeiculoExiste(placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = 0;
                if (!int.TryParse(Console.ReadLine(), out horas))
                {
                    Console.WriteLine("Quantidade de horas inválida. Não foi possível remover o veículo");
                    return;
                }

                decimal valorTotal = precoInicial + (precoPorHora * horas);

                veiculos.Remove(placa.valor);

                Console.WriteLine($"O veículo {placa.valor} foi removido e o preço total foi de: R$ {valorTotal.ToString("0.00")}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                veiculos.ForEach(x => Console.WriteLine(x));
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private bool VeiculoExiste(Placa placa)
        {
            return veiculos.Any(x => x == placa.valor);
        }
    }
}
