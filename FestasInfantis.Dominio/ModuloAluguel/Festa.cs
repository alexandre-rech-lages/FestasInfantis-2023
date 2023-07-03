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
            Endereco = new Endereco();
            Data = DateTime.Now;
            HorarioInicio = TimeSpan.Zero;
            HorarioTermino = TimeSpan.Zero;
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

            if (HorarioInicio == TimeSpan.Zero)
                erros.Add("O horário de início não pode ser 00:00!");

            if (HorarioTermino == TimeSpan.Zero)
                erros.Add("O horário de término não pode ser 00:00!");

            if (HorarioTermino < HorarioInicio)
                erros.Add("O horário de término não pode ser antes do início!");   
            
            if (Endereco != null)
                erros.AddRange(Endereco.Validar());


            return erros.ToArray();
        }
    }
}