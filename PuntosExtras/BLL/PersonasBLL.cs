using System;
using System.Collections.Generic;
using System.Text;
using PuntosExtras.Entidades;
using PuntosExtras.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace PuntosExtras.BLL
{
    public class PersonasBLL
    {
        public static bool Guardar(Personas persona)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Personas.Add(persona) != null)
                    paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Personas persona)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(persona).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var Eliminar = db.Personas.Find(id);
                db.Entry(Eliminar).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Personas Buscar(int id)
        {
            Personas producto = new Personas();
            Contexto db = new Contexto();

            try
            {
                producto = db.Personas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return producto;
        }

        public static List<Personas> GetList(Expression<Func<Personas, bool>> persona)
        {
            List<Personas> Lista = new List<Personas>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Personas.Where(persona).ToList(); 
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }
    }
}
