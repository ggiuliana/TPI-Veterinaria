using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class Consulta
    {
        public int IdConsulta { get; private set; }
        public string Diagnostico { get; private set; } = string.Empty;
        public string Tratamiento { get; private set; } = string.Empty;
        public float Peso { get; private set; }
        public string? Observaciones { get; private set; }
        public int IdTurno { get; private set; }
        public Turno Turno { get; private set; } = null!;
        public ICollection<Estudio>? Estudios { get; private set; } = null!;
        public ICollection<MedicamentoConsulta> MedicamentoConsulta { get; private set; } = new List<MedicamentoConsulta>();

        public Consulta() { }

        public Consulta(int idConsulta, string diagnostico, string tratamiento, float peso, Turno turno)
        {
            SetIdConsulta(idConsulta);
            SetDiagnostico(diagnostico);
            SetTratamiento(tratamiento);
            SetPeso(peso);
            SetTurno(turno);
        }

        public void SetIdConsulta(int idConsulta)
        {
            IdConsulta = idConsulta;
        }
        public void SetDiagnostico(string diagnostico)
        {
            Diagnostico = diagnostico;
        }
        public void SetTratamiento(string tratamiento)
        {
            Tratamiento = tratamiento;
        }
        public void SetPeso(float peso)
        {
            Peso = peso;
        }
        public void SetTurno(Turno turno)
        {
            Turno = turno;
        }
        public void SetObservaciones(string observaciones)
        {
            Observaciones = observaciones;
        }

        public void SetEstudios(ICollection<Estudio> estudios)
        {
            Estudios = estudios;
        }

        public void SetMedicamentoConsulta(ICollection<MedicamentoConsulta> medicamentoConsulta)
        {
            MedicamentoConsulta = medicamentoConsulta;
        }
    }
}
