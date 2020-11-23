using SistemaEducativo.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaEducativo.Models.General
{
    public class ObDepartamento
    {
        public string CodDepartamento { get; set; }
        public string NomDepartamento { get; set; }
    }
    public class ObjMunicipio
    {
        public string CodDepartamento { get; set; }
        public string CodMunicipio { get; set; }
        public string NomMunicipio { get; set; }
    }
    public class MunicipioControlador
    {
        public static List<ObDepartamento> ConsultaListaDepartamentos()
        {
            //List<ObjEstudiante> Estudiantes = null;
            using (GeneralModelDataContext db = new GeneralModelDataContext())
            {
                var consulta = from D in db.Departamento
                               select new ObDepartamento
                               {
                                   CodDepartamento=D.CodDepartamento,
                                   NomDepartamento= D.NomDepartamento
                               };
                return consulta.ToList();
            }
        }
        public static List<ObjMunicipio> ConsultaListaMunicipio()
        {
            //List<ObjEstudiante> Estudiantes = null;
            using (GeneralModelDataContext db = new GeneralModelDataContext())
            {
                var consulta = from M in db.Municipio
                               select new ObjMunicipio
                               {
                                   CodDepartamento = M.CodDepartamento,
                                   CodMunicipio= M.CodMunicipio,
                                   NomMunicipio = M.NomMunicipio
                               };
                return consulta.ToList();
            }
        }
        public static List<ObjMunicipio> ConsultaListaMunicipioPorDepartamento(string CodDepartamento)
        {
            //List<ObjEstudiante> Estudiantes = null;
            using (GeneralModelDataContext db = new GeneralModelDataContext())
            {
                var consulta = from M in db.Municipio
                               where M.CodDepartamento.Equals(CodDepartamento)
                               select new ObjMunicipio
                               {
                                   CodDepartamento = M.CodDepartamento,
                                   CodMunicipio = M.CodMunicipio,
                                   NomMunicipio = M.NomMunicipio
                               };
                
                return consulta.ToList();
            }
        }
    }
}