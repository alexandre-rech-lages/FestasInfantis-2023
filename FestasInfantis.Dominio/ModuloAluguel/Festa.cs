namespace FestasInfantis.Dominio.ModuloAluguel
{
    [Serializable]
    public class Festa
    {
        public Endereco Endereco { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HorarioInicio { get; set; }
        public TimeSpan HorarioTermino { get; set; }

        public Festa()
        {            
        }

        public Festa(Endereco endereco, DateTime data, TimeSpan horarioInicio, TimeSpan horarioTermino)
        {
            Endereco = endereco;
            Data = data;
            HorarioInicio = horarioInicio;
            HorarioTermino = horarioTermino;
        }

        public string[] Validar()
        {
            List<string> erros = new List<string>();

            if (Data < DateTime.Today)
                erros.Add("A data da festa não pode ser no passado!");

            if (HorarioTermino < HorarioInicio)
                erros.Add("O horário de término não pode ser antes do início!");

            if (string.IsNullOrEmpty(Endereco.Cidade))
                erros.Add("O campo 'Cidade' é obrigatório!");

            if (string.IsNullOrEmpty(Endereco.Estado))
                erros.Add("O campo 'Estado' é obrigatório!");

            if (string.IsNullOrEmpty(Endereco.Rua))
                erros.Add("O campo 'Rua' é obrigatório!");
            
            if (string.IsNullOrEmpty(Endereco.Bairro))
                erros.Add("O campo 'Bairro' é obrigatório!");

            if (string.IsNullOrEmpty(Endereco.Numero))
                erros.Add("O campo 'Número' é obrigatório!");

            return erros.ToArray();
        }
    }
}
