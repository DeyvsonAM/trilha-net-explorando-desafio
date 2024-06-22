namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        
        public class NumeroDeHospedesNCompativel : System.Exception
        {
            public NumeroDeHospedesNCompativel() { }
            public NumeroDeHospedesNCompativel(string message) : base(message) { }
            public NumeroDeHospedesNCompativel(string message, System.Exception inner) : base(message, inner) { }
            protected NumeroDeHospedesNCompativel(
                System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI* VV
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                // *IMPLEMENTE AQUI* VV
                throw new NumeroDeHospedesNCompativel ($"Capacidade de hospedes:({hospedes.Count}) é maior doque oque a Suite ({Suite.TipoSuite}) suporta que é ({Suite.Capacidade}).");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {

            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // *IMPLEMENTE AQUI*VV
           int QuantidadeDeHospedes = Hospedes.Count;
            return QuantidadeDeHospedes;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
           
            // *IMPLEMENTE AQUI*VV
            decimal ValorDaDiaria = Suite.ValorDiaria * DiasReservados;


            

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            if (DiasReservados > 10)
            {
                Decimal PorcentagemDoValor = ValorDaDiaria * 10/100;
                ValorDaDiaria = ValorDaDiaria - PorcentagemDoValor;
            }

            return ValorDaDiaria;
        }
    }
}